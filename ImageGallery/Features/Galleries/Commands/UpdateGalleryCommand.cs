using AutoMapper;
using FluentValidation;
using ImageGallery.Data;
using ImageGallery.Exceptions;
using ImageGallery.Features.Abstract;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Commands
{
    public class UpdateGalleryCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public class UpdateGalleryHandler : BaseRequest, IRequestHandler<UpdateGalleryCommand>
        {
            public UpdateGalleryHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
            public async Task<Unit> Handle(UpdateGalleryCommand request, CancellationToken cancellationToken)
            {
                var gallery = Context.Galleries.SingleOrDefault(i => i.Id == request.Id);
                if (gallery == null)
                    throw new NotFoundException("The gallery not found!");
                Mapper.Map(request, gallery);
                await Context.SaveChangesAsync();
                return Unit.Value;
            }
        }

        public class UpdateGalleryCommandValidation : AbstractValidator<UpdateGalleryCommand>
        {
            public UpdateGalleryCommandValidation()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.Title).MaximumLength(50);
                RuleFor(x => x.Description).MaximumLength(500);
            }
        }
    }
}