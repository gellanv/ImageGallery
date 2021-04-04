using AutoMapper;
using AutoMapper.QueryableExtensions;
using ImageGallery.CustomMiddleware;
using ImageGallery.Data;
using ImageGallery.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ImageGallery.Services
{
    public class GalleryService : BaseService, IGalleryService
    {
        public GalleryService(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
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
                throw new CustomHttpException(HttpStatusCode.InternalServerError, exeption.Message);
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
                new CustomHttpException(HttpStatusCode.NotFound, "There isn't GalleryImage with such id");
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
                throw new CustomHttpException(HttpStatusCode.BadRequest, exeption.Message);
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
                throw new CustomHttpException(HttpStatusCode.NotFound, "There isn't Gallery with such id");
        }
    }
}