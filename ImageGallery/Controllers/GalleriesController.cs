using ImageGallery.Data;
using ImageGallery.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleriesController : ControllerBase
    {
        private IUnitOfWork unitOfWork;
        public GalleriesController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        // POST: api/Galleries
        [HttpPost]
        public async Task<ActionResult<GalleryDto>> PostGalleryAsync(GalleryDto galleryDto)
        {
            await unitOfWork.galleries.PostGalleryAsync(galleryDto);
            return Ok();
        }

        // PUT: api/Galleries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalleryAsync(int id, GalleryDto galleryDto)
        {
            await unitOfWork.galleries.PutGalleryAsync(id, galleryDto);
            return Ok();
        }

        // GET: api/Galleries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GalleryDto>>> GetGalleriesAsync()
        {
            var result = await unitOfWork.galleries.GetGalleriesAsync();
            return Ok(result);
        }

        // DELETE: api/Galleries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalleryAsync(int id)
        {
            await unitOfWork.galleries.DeleteGalleryAsync(id);
            return Ok();
        }
    }
}