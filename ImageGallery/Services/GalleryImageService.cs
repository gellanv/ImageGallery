using AutoMapper;
using AutoMapper.QueryableExtensions;
using ImageGallery.Controllers;
using ImageGallery.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Services
{
    public class GalleryImageService : BaseController, IGalleryImageService
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Photo { get; set; }
        public int GalleryId { get; set; }

        public GalleryImageService(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
        
        public async Task<IActionResult> PostImageAsync(int galleryId, string title, IFormFile photo)
        {
            var gallery = await _context.Galleries.FindAsync(galleryId);
            if (gallery == null)
            {
                return NotFound();
            }
            else
            {
                GalleryImageDto galleryImageDto = new GalleryImageDto();
                galleryImageDto.Title = title;
                galleryImageDto.GalleryId = galleryId;
                galleryImageDto.Photo = ConvertPhoto(photo);
                var galleryImage = _mapper.Map<GalleryImage>(galleryImageDto);
                _context.GalleryImages.Add(galleryImage);
                if (await _context.SaveChangesAsync() != 0)
                {
                    return NoContent();
                }
                else
                    return BadRequest();
            }
        }
        
        public async Task<IActionResult> PutImageAsync(int id, int galleryId, string title, IFormFile photo)
        {
            GalleryImageDto galleryImageDto = new GalleryImageDto();
            galleryImageDto.Id = id;
            galleryImageDto.GalleryId = galleryId;
            galleryImageDto.Title = title;
            galleryImageDto.Photo = ConvertPhoto(photo);

            if (galleryImageDto.Id != id)
            {
                return BadRequest();
            }
            else
            {
                var galleryImage = _mapper.Map<GalleryImage>(galleryImageDto);
                _context.Entry(galleryImage).State = EntityState.Modified;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalleryImageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool GalleryImageExists(int id)
        {
            return _context.GalleryImages.Any(e => e.Id == id);
        }

        public async Task<ActionResult<IQueryable<GalleryImageDto>>> GetGalleryImagesAsync(int galleryId)
        {

            var result = context.GalleryImages
                .Where(g => g.GalleryId == galleryId)
                .ProjectTo<GalleryImageDto>(_mapper.ConfigurationProvider);
            return await Task.FormResult(result);
        }


        public async Task<ActionResult<GalleryImageDto>> GetGalleryImageAsync(int id)
        {
            var result = await context.GalleryImages
                .Where(g => g.id == id)
                .ProjectTo<GalleryImageDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
             return result;
        }
        
        public async Task<IActionResult> DeleteGalleryImageAsync(int id)
        {
            var item  = await context.GalleryImages
                .Where(g => g.id == id)
                .SingleOrDefaultAsync();
            if (item != null)
            {
               _context.GaleryImages.Remove(item);
               await _context.SaveChangesAsync()
            }
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
