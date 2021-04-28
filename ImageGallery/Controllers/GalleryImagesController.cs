using ImageGallery.Commands;
using ImageGallery.Data;
using ImageGallery.Queries;
using MediatR;
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
        private readonly IMediator mediator;
        public GalleryImagesController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        //  Add photo to the current Gallery
        //  POST: api/GalleryImages     
        [HttpPost]
        public async Task<IActionResult> PostGalleryImageAsync([FromQuery] int galleryId, [FromQuery] string title, List<IFormFile> photos)
        {
            var command = new CreateGalleryImageCommand(galleryId, title, photos);
            await mediator.Send(command);
            return Ok();
        }

        //  Edit Photo
        //  PUT: api/GalleryImages/5     
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalleryImageAsync(int id, [FromQuery] int galleryId, [FromQuery] string title, IFormFile photo)
        {
            var command = new UpdateGalleryImageCommand(id, galleryId, title, photo);
            await mediator.Send(command);
            return Ok();
        }

        //  Get a List Photos of Current Gallery
        //  GET: api/GalleryImages       
        [HttpGet]
        public async Task<ActionResult<IQueryable<GalleryImageDto>>> GetGalleryImagesAsync(int galleryId)
        {
            var query = new GetAllGalleryImagesQuery(galleryId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        //  Get one photo
        //  GET: api/GalleryImages/5  
        [HttpGet("{id}")]
        public async Task<ActionResult<GalleryImageDto>> GetGalleryImageAsync(int id)
        {
            var query = new GetGalleryImageQuery(id);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        // DELETE: api/GalleryImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalleryImageAsync(int id)
        {
            var command = new DeleteGalleryImageCommand(id);
            await mediator.Send(command);
            return Ok();
        }
    }
}