using AutoMapper;
using ImageGallery.Data;
using ImageGallery.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Commands
{
    public class CreateGalleryCommand : IRequest
    {
        public GalleryDto GalleryDto { get; set; }
        public CreateGalleryCommand(GalleryDto _galleryDto)
        {
            GalleryDto = _galleryDto;
        }

        public class CreateGalleryHandler : IRequestHandler<CreateGalleryCommand>
        {
            private readonly ApplicationDbContext Context;
            private readonly IMapper Mapper;
            public CreateGalleryHandler(ApplicationDbContext context, IMapper mapper)
            {
                Context = context;
                Mapper = mapper;
            }
            public async Task<Unit> Handle(CreateGalleryCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var gallery = Mapper.Map<Gallery>(request.GalleryDto);
                    Context.Galleries.Add(gallery);
                    await Context.SaveChangesAsync();
                    return Unit.Value;
                }
                catch (System.Exception exeption)
                {
                    throw new InternalServerErrorException(exeption.Message);
                }
            }
        }
    }
}