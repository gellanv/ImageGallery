using FluentValidation;
using ImageGallery.Data;
using ImageGallery.Exceptions;
using ImageGallery.Features.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Commands
{
    public class DeleteGalleryImageCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public class DeleteGalleryImageHandler : BaseRequest, IRequestHandler<DeleteGalleryImageCommand>
        {
            public DeleteGalleryImageHandler(ApplicationDbContext context) : base(context) { }
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
                    throw new NotFoundException("The gallery image not found!");
                return Unit.Value;
            }
        }
        public class DeleteGalleryImageCommandValidation : AbstractValidator<DeleteGalleryImageCommand>
        {
            public DeleteGalleryImageCommandValidation()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }
    }
}