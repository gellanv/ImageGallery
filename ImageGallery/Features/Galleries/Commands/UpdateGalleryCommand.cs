using AutoMapper;
using ImageGallery.Data;
using ImageGallery.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Commands
{
    public class UpdateGalleryCommand : IRequest
    {
        public int Id { get; set; }
        public GalleryDto GalleryDto { get; set; }
        public UpdateGalleryCommand(int _id, GalleryDto _galleryDto)
        {
            Id = _id;
            GalleryDto = _galleryDto;
        }

        public class UpdateGalleryHandler : IRequestHandler<UpdateGalleryCommand>
        {
            private readonly ApplicationDbContext Context;
            private readonly IMapper Mapper;
            public UpdateGalleryHandler(ApplicationDbContext context, IMapper mapper)
            {
                Context = context;
                Mapper = mapper;
            }
            public async Task<Unit> Handle(UpdateGalleryCommand request, CancellationToken cancellationToken)
            {

                if (Context.Galleries.Any(e => e.Id == request.Id))
                {
                    var gallery = Mapper.Map<Gallery>(request.GalleryDto);
                    Context.Entry(gallery).State = EntityState.Modified;
                    await Context.SaveChangesAsync();
                }
                else
                    throw new NotFoundException("There isn't Gallery with such id");
                return Unit.Value;
            }
        }
    }
}