using AutoMapper;
using FluentValidation;
using ImageGallery.Data;
using ImageGallery.Exceptions;
using ImageGallery.Features.Abstract;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Commands
{
    public class CreateGalleryCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public class CreateGalleryHandler : BaseRequest, IRequestHandler<CreateGalleryCommand, int>
        {
            public CreateGalleryHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
            public async Task<int> Handle(CreateGalleryCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var gallery = Mapper.Map<Gallery>(request);
                    Context.Galleries.Add(gallery);
                    await Context.SaveChangesAsync();
                    return gallery.Id;
                }
                catch (System.Exception exeption)
                {
                    throw new InternalServerErrorException(exeption.Message);
                }
            }
        }
        public class CreateGalleryCommandValidation : AbstractValidator<CreateGalleryCommand>
        {
            public CreateGalleryCommandValidation()
            {
                RuleFor(x => x.Title).MaximumLength(50);
                RuleFor(x => x.Description).MaximumLength(500);
            }
        }
    }
}