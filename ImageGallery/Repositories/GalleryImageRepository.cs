using AutoMapper;
using AutoMapper.QueryableExtensions;
using ImageGallery.Data;
using ImageGallery.Exceptions;
using ImageGallery.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Services
{
    public class GalleryImageRepository : IGalleryImageRepository
    {

        private ApplicationDbContext Context;
        private IMapper Mapper;
        public GalleryImageRepository(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        public async Task PostGalleryImageAsync(int galleryId, string title, List<IFormFile> photos)
        {
            try
            {
                foreach (var uploadedFoto in photos)
                {
                    GalleryImageDto galleryImageDto = new() { GalleryId = galleryId, Title = title, Photo = ConvertPhoto(uploadedFoto) };
                    var galleryImage = Mapper.Map<GalleryImage>(galleryImageDto);
                    Context.GalleryImages.Add(galleryImage);
                }
                await Context.SaveChangesAsync();
            }
            catch (System.Exception exeption)
            {
                throw new InternalServerErrorException(exeption.Message);
            }
        }
        public async Task PutGalleryImageAsync(int id, int galleryId, string title, IFormFile photo)
        {
            if (Context.GalleryImages.Any(e => e.Id == id))
            {
                GalleryImageDto galleryImageDto = new() { Id = id, GalleryId = galleryId, Title = title, Photo = ConvertPhoto(photo) };
                var galleryImage = Mapper.Map<GalleryImage>(galleryImageDto);
                Context.Entry(galleryImage).State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
            else
                throw new NotFoundException("There isn't GalleryImage with such id");
        }
        public async Task<IQueryable<GalleryImageDto>> GetGalleryImagesAsync(int galleryId)
        {
            try
            {
                var result = Context.GalleryImages
                    .Where(g => g.GalleryId == galleryId)
                    .ProjectTo<GalleryImageDto>(Mapper.ConfigurationProvider);
                return await Task.FromResult(result);
            }
            catch (System.ArgumentNullException)
            {
                throw new NotFoundException("Such gallery don't exist");
            }
        }
        public async Task<GalleryImageDto> GetGalleryImageAsync(int id)
        {
            var result = await Context.GalleryImages
                .Where(g => g.Id == id)
                .ProjectTo<GalleryImageDto>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
            if (result != null)
                return result;
            else
                throw new NotFoundException("There isn't GalleryImage with such id");
        }
        public async Task DeleteGalleryImageAsync(int id)
        {
            var item = await Context.GalleryImages.
               Where(g => g.Id == id).
               SingleOrDefaultAsync();
            if (item != null)
            {
                Context.GalleryImages.Remove(item);
                await Context.SaveChangesAsync();
            }
            else
                throw new NotFoundException("There isn't GalleryImage with such id");
        }
        private byte[] ConvertPhoto(IFormFile galleryPhoto)
        {
            byte[] image = null;
            using (var binaryReader = new BinaryReader(galleryPhoto.OpenReadStream()))
            {
                image = binaryReader.ReadBytes((int)galleryPhoto.Length);
            }
            return image;
        }
    }
}
