using ImageGallery.Commands;
using ImageGallery.Features;
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
        private readonly IMediator _mediator;
        public GalleriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // POST: api/Galleries
        [HttpPost]
        public async Task<ActionResult<CreateGalleryCommand>> PostGalleryAsync([FromBody] CreateGalleryCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        // PUT: api/Galleries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGalleryAsync(int id, [FromBody] UpdateGalleryCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return Ok();
        }
        // GET: api/Galleries
        [HttpGet]
        public async Task<ActionResult<IQueryable<GalleryModel>>> GetGalleriesAsync()
        {
            var query = new GetAllGalleriesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        // DELETE: api/Galleries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGalleryAsync(int id)
        {
            var command = new DeleteGalleryCommand() { Id = id };
            await _mediator.Send(command);
            return Ok();
        }
    }
}