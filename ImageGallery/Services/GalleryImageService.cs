using AutoMapper;
using AutoMapper.QueryableExtensions;
using ImageGallery.Controllers;
using ImageGallery.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Services
{
    public class GalleryImageService : BaseController, IGalleryImageService
    {
        public GalleryImageService(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
        public async Task<IActionResult> PostGalleryImageAsync(int galleryId, string title, IFormFile photo)
        {
            GalleryImageDto galleryImageDto = new() { GalleryId = galleryId, Title = title, Photo = ConvertPhoto(photo) };
            var galleryImage = Mapper.Map<GalleryImage>(galleryImageDto);
            Context.GalleryImages.Add(galleryImage);
            await Context.SaveChangesAsync();
            return Ok();
        }
        public async Task<IActionResult> PutGalleryImageAsync(int id, int galleryId, string title, IFormFile photo)
        {
            if (Context.GalleryImages.Any(e => e.Id == id))
            {
                GalleryImageDto galleryImageDto = new() { Id = id, GalleryId = galleryId, Title = title, Photo = ConvertPhoto(photo) };
                var galleryImage = Mapper.Map<GalleryImage>(galleryImageDto);
                Context.Entry(galleryImage).State = EntityState.Modified;
                await Context.SaveChangesAsync();
                return Ok();
            }
            else
                return BadRequest();
        }
        public async Task<IQueryable<GalleryImageDto>> GetGalleryImagesAsync(int galleryId)
        {
            var result = Context.GalleryImages
                .Where(g => g.GalleryId == galleryId)
                .ProjectTo<GalleryImageDto>(Mapper.ConfigurationProvider);
            return await Task.FromResult(result);
        }
        public async Task<GalleryImageDto> GetGalleryImageAsync(int id)
        {
            var result = await Context.GalleryImages
                .Where(g => g.Id == id)
                .ProjectTo<GalleryImageDto>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
            return result;
        }
        public async Task<IActionResult> DeleteGalleryImageAsync(int id)
        {
            var item = await Context.GalleryImages.
               Where(g => g.Id == id).
               SingleOrDefaultAsync();
            if (item != null)
            {
                Context.GalleryImages.Remove(item);
                await Context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                throw new System.Exception("There is no GalleryImage with such id");
            }
            //return BadRequest();
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
