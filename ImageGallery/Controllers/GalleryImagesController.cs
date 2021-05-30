using ImageGallery.Commands;
using ImageGallery.Features;
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
        private readonly IMediator _mediator;
        public GalleryImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //  Add photo to the current Gallery
        //  POST: api/GalleryImages     
        [HttpPost]
        public async Task<IActionResult> PostGalleryImageAsync([FromQuery] int galleryId, [FromQuery] string title, List<IFormFile> photos)
        {
            foreach (var uploadedFoto in photos)
            {
                var command = new CreateGalleryImageCommand() { GalleryId = galleryId, Title = title };
                command.Photo = command.ConvertPhoto(uploadedFoto);
                await _mediator.Send(command);
            }
            return Ok();
        }

        //  Edit Photo
        //  PUT: api/GalleryImages/5     
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalleryImageAsync(int id, [FromQuery] UpdateGalleryImageCommand command, IFormFile photo)
        {
            command.Photo = command.ConvertPhoto(photo);
            command.Id = id;
            await _mediator.Send(command);
            return Ok();
        }

        //  Get a List Photos of Current Gallery
        //  GET: api/GalleryImages       
        [HttpGet]
        public async Task<ActionResult<IQueryable<GalleryImageModel>>> GetGalleryImagesAsync(int galleryId)
        {
            var query = new GetAllGalleryImagesQuery() { GalleryId = galleryId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //  Get one photo
        //  GET: api/GalleryImages/5  
        [HttpGet("{id}")]
        public async Task<ActionResult<GalleryImageModel>> GetGalleryImageAsync(int id)
        {
            var query = new GetGalleryImageQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // DELETE: api/GalleryImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalleryImageAsync(int id)
        {
            var command = new DeleteGalleryImageCommand() { Id = id };
            await _mediator.Send(command);
            return Ok();
        }
    }
}