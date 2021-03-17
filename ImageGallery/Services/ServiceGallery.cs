using AutoMapper;
using ImageGallery.Controllers;
using ImageGallery.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Services
{
    public class ServiceGallery : BaseController, IGalleryService
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ServiceGallery(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<ActionResult<GalleryDto>> PostGalleryAsync(GalleryDto galleryDto)
        {
            var gallery = _mapper.Map<Gallery>(galleryDto);
            _context.Galleries.Add(gallery);
            if (await _context.SaveChangesAsync() != 0)
            {
                return Ok(galleryDto);
            }
            else
                return BadRequest();
        }
        public async Task<IActionResult> PutGalleryAsync(int id, GalleryDto galleryDto)
        {
            if (id != galleryDto.Id)
            {
                return BadRequest();
            }
            var gallery = _mapper.Map<Gallery>(galleryDto);
            _context.Entry(gallery).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalleryExists(id))
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
        private bool GalleryExists(int id)
        {
            return _context.Galleries.Any(e => e.Id == id);
        }
        public IEnumerable<GalleryDto> GetGalleries()
        {
            List<GalleryDto> galleriesDto = new List<GalleryDto>();
            foreach (Gallery gallery in _context.Galleries)
            {
                var gallerDto = _mapper.Map<GalleryDto>(gallery);
                galleriesDto.Add(gallerDto);
            }
            return galleriesDto;
        }
        public async Task<IActionResult> DeleteGalleryAsync(int id)
        {
            var gallery = await _context.Galleries.FindAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }
            _context.Galleries.Remove(gallery);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
