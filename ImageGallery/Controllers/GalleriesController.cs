using ImageGallery.Data;
using ImageGallery.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleriesController : BaseController
    {
        private readonly IGalleryService _service;
        public GalleriesController(IGalleryService service)
        {
            _service = service;
        }

        // POST: api/Galleries
        [HttpPost]
        public async Task<ActionResult<GalleryDto>> PostGalleryAsync(GalleryDto galleryDto)
        {
            await _service.PostGalleryAsync(galleryDto);
            return Ok();
        }

        // PUT: api/Galleries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalleryAsync(int id, GalleryDto galleryDto)
        {
            await _service.PutGalleryAsync(id, galleryDto);
            return Ok();
        }

        // GET: api/Galleries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GalleryDto>>> GetGalleriesAsync()
        {
            var result = await _service.GetGalleriesAsync();
            return Ok(result);
        }

        // DELETE: api/Galleries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalleryAsync(int id)
        {
            await _service.DeleteGalleryAsync(id);
            return Ok();
        }
    }
}