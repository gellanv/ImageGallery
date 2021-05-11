using ImageGallery.Data;
using ImageGallery.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Commands
{
    public class DeleteGalleryCommand : IRequest
    {
        public int Id { get; set; }
        public DeleteGalleryCommand(int _id)
        {
            Id = _id;
        }

        public class DeleteGalleryHandler : IRequestHandler<DeleteGalleryCommand>
        {
            private readonly ApplicationDbContext Context;

            public DeleteGalleryHandler(ApplicationDbContext context)
            {
                Context = context;
            }
            public async Task<Unit> Handle(DeleteGalleryCommand request, CancellationToken cancellationToken)
            {
                var item = await Context.Galleries
               .Where(g => g.Id == request.Id)
               .SingleOrDefaultAsync();
                if (item != null)
                {
                    Context.Galleries.Remove(item);
                    await Context.SaveChangesAsync();
                }
                else
                    throw new NotFoundException("There isn't Gallery with such id");
                return Unit.Value;
            }
        }
    }
}
