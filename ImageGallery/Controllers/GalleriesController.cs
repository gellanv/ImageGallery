using ImageGallery.Data;
using ImageGallery.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleriesController
    {
        IGalleryService _service;
        public GalleriesController(IGalleryService service)
        {
            _service = service;
        }

        // POST: api/Galleries
        [HttpPost]
        public Task<ActionResult<GalleryDto>> PostGallery(GalleryDto galleryDto)
        {
            return _service.PostGalleryAsync(galleryDto);
        }

        // PUT: api/Galleries/5
        [HttpPut("{id}")]
        public Task<IActionResult> PutGallery(int id, GalleryDto galleryDto)
        {
            return _service.PutGalleryAsync(id, galleryDto);
        }

        // GET: api/Galleries
        [HttpGet]
        public IEnumerable<GalleryDto> GetGalleries()
        {
            return _service.GetGalleries();
        }

        // DELETE: api/Galleries/5
        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteGalleryAsync(int id)
        {
            return _service.DeleteGalleryAsync(id);
        }
    }
}