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
        IGalleryImageService _service;
        public GalleryImagesController(IGalleryImageService service)
        {
            _service = service;
        }

        // POST: api/GalleryImages      //--Add a photo to the current Gallery
        [HttpPost]
        public Task<IActionResult> PostImage(int galleryId, string title, IFormFile photo)
        {
            return _service.PostImageAsync(galleryId, title, photo);
        }

        // PUT: api/GalleryImages/5     //--Edit Photo
        [HttpPut("{id}")]
        public Task<IActionResult> PutImage(int id, int galleryId, string title, IFormFile photo)
        {
            return _service.PutImageAsync(id, galleryId, title, photo);
        }

        // GET: api/GalleryImages       //--Get a List Photos of Current Gallery
        [HttpGet]
        public Task<ActionResult<GalleryItemDto>> GetGalleryImagesAsync(int galleryId)
        {
            return _service.GetGalleryImagesAsync(galleryId);
        }

        // GET: api/GalleryImages/5   //--Get one photo
        [HttpGet("{id}")]
        public Task<ActionResult<GalleryImageDto>> GetImage(int id)
        {
            return _service.GetImageAsync(id);
        }

        // DELETE: api/GalleryImages/5
        [HttpDelete("{id}")]
        public Task<IActionResult> DeleteImage(int id)
        {
            return _service.DeleteImageAsync(id);
        }
    }
}