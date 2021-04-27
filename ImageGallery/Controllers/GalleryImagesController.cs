using ImageGallery.Data;
using ImageGallery.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryImagesController : ControllerBase
    {

        private IUnitOfWork unitOfWork;
        public GalleryImagesController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        //  Add photo to the current Gallery
        //  POST: api/GalleryImages     
        [HttpPost]
        public async Task<IActionResult> PostGalleryImageAsync([FromQuery] int galleryId, [FromQuery] string title, List<IFormFile> photos)
        {
            await unitOfWork.GalleryImages.CreateAsync(galleryId, title, photos);
            return Ok();
        }

        //  Edit Photo
        //  PUT: api/GalleryImages/5     
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalleryImageAsync(int id, [FromQuery] int galleryId, [FromQuery] string title, IFormFile photo)
        {
            await unitOfWork.GalleryImages.UpdateAsync(id, galleryId, title, photo);
            return Ok();
        }

        //  Get a List Photos of Current Gallery
        //  GET: api/GalleryImages       
        [HttpGet]
        public async Task<ActionResult<IQueryable<GalleryImageDto>>> GetGalleryImagesAsync(int galleryId)
        {
            var result = await unitOfWork.GalleryImages.GetAllAsync(galleryId);
            return Ok(result);
        }

        //  Get one photo
        //  GET: api/GalleryImages/5  
        [HttpGet("{id}")]
        public async Task<ActionResult<GalleryImageDto>> GetGalleryImageAsync(int id)
        {
            var result = await unitOfWork.GalleryImages.GetAsync(id);
            return Ok(result);
        }

        // DELETE: api/GalleryImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalleryImageAsync(int id)
        {
            await unitOfWork.GalleryImages.DeleteAsync(id);
            return Ok();
        }
    }
}