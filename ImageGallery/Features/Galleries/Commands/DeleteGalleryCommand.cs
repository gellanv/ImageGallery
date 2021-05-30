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
    public class DeleteGalleryCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public class DeleteGalleryHandler : BaseRequest, IRequestHandler<DeleteGalleryCommand>
        {
            public DeleteGalleryHandler(ApplicationDbContext context) : base(context) { }
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
                    throw new NotFoundException("The gallery not found!");
                return Unit.Value;
            }
        }
        public class DeleteGalleryCommandValidation : AbstractValidator<DeleteGalleryCommand>
        {
            public DeleteGalleryCommandValidation()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }
    }
}
