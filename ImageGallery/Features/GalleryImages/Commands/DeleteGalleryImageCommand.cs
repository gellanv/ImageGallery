using ImageGallery.Data;
using ImageGallery.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Commands
{
    public class DeleteGalleryImageCommand : IRequest
    {
        public int Id { get; set; }
        public DeleteGalleryImageCommand(int id)
        {
            this.Id = id;
        }

        public class DeleteGalleryImageHandler : IRequestHandler<DeleteGalleryImageCommand>
        {
            private readonly ApplicationDbContext Context;
            public DeleteGalleryImageHandler(ApplicationDbContext context)
            {
                Context = context;
            }
            public async Task<Unit> Handle(DeleteGalleryImageCommand request, CancellationToken cancellationToken)
            {
                var item = await Context.GalleryImages.
              Where(g => g.Id == request.Id).
              SingleOrDefaultAsync();
                if (item != null)
                {
                    Context.GalleryImages.Remove(item);
                    await Context.SaveChangesAsync();
                }
                else
                    throw new NotFoundException("There isn't GalleryImage with such id");
                return Unit.Value;
            }
        }
    }
}