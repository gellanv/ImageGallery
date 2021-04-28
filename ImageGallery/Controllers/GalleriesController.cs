using ImageGallery.Commands;
using ImageGallery.Data;
using ImageGallery.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleriesController : ControllerBase
    {
        private readonly IMediator mediator;
        public GalleriesController(IMediator _mediator)
        {
            mediator = _mediator;
        }
        // POST: api/Galleries
        [HttpPost]
        public async Task<ActionResult<GalleryDto>> PostGalleryAsync(GalleryDto galleryDto)
        {
            var command = new CreateGalleryCommand(galleryDto);
            await mediator.Send(command);
            return Ok();
        }
        // PUT: api/Galleries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalleryAsync(int id, GalleryDto galleryDto)
        {
            var command = new UpdateGalleryCommand(id, galleryDto);
            await mediator.Send(command);
            return Ok();
        }
        // GET: api/Galleries
        [HttpGet]
        public async Task<ActionResult<IQueryable<GalleryDto>>> GetGalleriesAsync()
        {
            var query = new GetAllGalleriesQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
        // DELETE: api/Galleries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalleryAsync(int id)
        {
            var command = new DeleteGalleryCommand(id);
            await mediator.Send(command);
            return Ok();
        }
    }
}