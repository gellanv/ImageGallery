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
    public class GalleryService : BaseController, IGalleryService
    {
        public GalleryService(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
        public async Task<ActionResult<GalleryDto>> PostGalleryAsync(GalleryDto galleryDto)
        {
            var gallery = Mapper.Map<Gallery>(galleryDto);
            Context.Galleries.Add(gallery);
            await Context.SaveChangesAsync();
            return Ok(galleryDto);
        }
        public async Task<IActionResult> PutGalleryAsync(int id, GalleryDto galleryDto)
        {
            if (Context.Galleries.Any(e => e.Id == id))
            {
                var gallery = Mapper.Map<Gallery>(galleryDto);
                Context.Entry(gallery).State = EntityState.Modified;
                await Context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
        public async Task<IEnumerable<GalleryDto>> GetGalleriesAsync()
        {
            var result = Mapper.Map<Gallery[], IEnumerable<GalleryDto>>(Context.Galleries.ToArray());
            return await Task.FromResult(result);
        }

        public async Task<IActionResult> DeleteGalleryAsync(int id)
        {
            var item = await Context.Galleries
                .Where(g => g.Id == id)
                .SingleOrDefaultAsync();
            if (item != null)
            {
                Context.Galleries.Remove(item);
                await Context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}