using ImageGallery.Data;
using ImageGallery.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ImageGallery
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryImagesController
    {
        private reaonly IGalleryImageService _service;
        
        public GalleryImagesController(IGalleryImageService service)
        {
            _service = service;
        }

        // POST: api/GalleryImages      //--Add a photo to the current Gallery
        [HttpPost]
        public async Task<IActionResult> PostImageAsync(int galleryId, string title, IFormFile photo)
        {
             await _service.PostImageAsync(galleryId, title, photo);
            return Ok();
        }

        // PUT: api/GalleryImages/5     //--Edit Photo
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImageAsync(int id, int galleryId, string title, IFormFile photo)
        {
            await _service.PutImageAsync(id, galleryId, title, photo);
            return Ok();
        }

        // GET: api/GalleryImages       //--Get a List Photos of Current Gallery
        [HttpGet]
        public async asyncTask<ActionResult<GalleryItemDto>> GetGalleryImagesAsync(int galleryId)
        {
            var result = await _service.GetGalleryImagesAsync(galleryId);
            return Ok(result);
        }

        // GET: api/GalleryImages/5   //--Get one photo
        [HttpGet("{id}")]
        public async Task<ActionResult<GalleryImageDto>> GetImageAsync(int id)
        {
            var result = await _service.GetImageAsync(id);
            return Ok(result);
        }

        // DELETE: api/GalleryImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageAsync(int id)
        {
            await  _service.DeleteImageAsync(id);
            return Ok();
        }
    }
}
