using AutoMapper;
using AutoMapper.QueryableExtensions;
using ImageGallery.Data;
using ImageGallery.Exceptions;
using ImageGallery.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Services
{
    public class GalleryRepository : IGalleryRepository
    {
        private ApplicationDbContext Context;
        private IMapper Mapper;
        public GalleryRepository(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        public async Task<GalleryDto> PostGalleryAsync(GalleryDto galleryDto)
        {
            try
            {
                var gallery = Mapper.Map<Gallery>(galleryDto);
                Context.Galleries.Add(gallery);
                await Context.SaveChangesAsync();
                return galleryDto;
            }
            catch (System.Exception exeption)
            {
                throw new InternalServerErrorException(exeption.Message);
            }
        }
        public async Task PutGalleryAsync(int id, GalleryDto galleryDto)
        {
            if (Context.Galleries.Any(e => e.Id == id))
            {
                var gallery = Mapper.Map<Gallery>(galleryDto);
                Context.Entry(gallery).State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
            else
                throw new NotFoundException("There isn't Gallery with such id");
        }
        public async Task<IEnumerable<GalleryDto>> GetGalleriesAsync()
        {
            try
            {
                var result = Context.Galleries.ProjectTo<GalleryDto>(Mapper.ConfigurationProvider);
                return await Task.FromResult(result);
            }
            catch (System.Exception exeption)
            {
                throw new BadRequestException(exeption.Message);
            }
        }
        public async Task DeleteGalleryAsync(int id)
        {
            var item = await Context.Galleries
                .Where(g => g.Id == id)
                .SingleOrDefaultAsync();
            if (item != null)
            {
                Context.Galleries.Remove(item);
                await Context.SaveChangesAsync();
            }
            else
                throw new NotFoundException("There isn't Gallery with such id");
        }
    }
}
