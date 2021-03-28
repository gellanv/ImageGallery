using ImageGallery.Controllers;
using ImageGallery.Data;
using ImageGallery.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryImagesController : ControllerBase
    {
        private readonly IGalleryImageService _service;
        public GalleryImagesController(IGalleryImageService service)
        {
            _service = service;
        }

        //  Add photo to the current Gallery
        //  POST: api/GalleryImages     
        [HttpPost]
        public async Task<IActionResult> PostGalleryImageAsync(int galleryId, string title, IFormFile photo)
        {
            await _service.PostGalleryImageAsync(galleryId, title, photo);
            return Ok();
        }

        //  Edit Photo
        //  PUT: api/GalleryImages/5     
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalleryImageAsync(int id, int galleryId, string title, IFormFile photo)
        {
            await _service.PutGalleryImageAsync(id, galleryId, title, photo);
            return Ok();
        }

        //  Get a List Photos of Current Gallery
        //  GET: api/GalleryImages       
        [HttpGet]
        public async Task<ActionResult<IQueryable<GalleryImageDto>>> GetGalleryImagesAsync(int galleryId)
        {
            var result = await _service.GetGalleryImagesAsync(galleryId);
            return Ok(result);
        }

        //  Get one photo
        //  GET: api/GalleryImages/5  
        [HttpGet("{id}")]
        public async Task<ActionResult<GalleryImageDto>> GetGalleryImageAsync(int id)
        {
            var result = await _service.GetGalleryImageAsync(id);
            return Ok(result);
        }

        // DELETE: api/GalleryImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalleryImageAsync(int id)
        {
            await _service.DeleteGalleryImageAsync(id);
            return Ok();
        }
    }
}