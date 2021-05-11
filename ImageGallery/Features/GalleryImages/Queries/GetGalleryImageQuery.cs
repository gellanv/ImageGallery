using AutoMapper;
using AutoMapper.QueryableExtensions;
using ImageGallery.Data;
using ImageGallery.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Queries
{
    public class GetGalleryImageQuery : IRequest<GalleryImageDto>
    {
        public int id { get; set; }
        public GetGalleryImageQuery(int _id)
        {
            id = _id;
        }

        public class GetGalleryImageHandler : IRequestHandler<GetGalleryImageQuery, GalleryImageDto>
        {
            private readonly ApplicationDbContext Context;
            private readonly IMapper Mapper;
            public GetGalleryImageHandler(ApplicationDbContext context, IMapper mapper)
            {
                Context = context;
                Mapper = mapper;
            }
            public async Task<GalleryImageDto> Handle(GetGalleryImageQuery request, CancellationToken cancellationToken)
            {
                var result = await Context.GalleryImages
                   .Where(g => g.Id == request.id)
                   .ProjectTo<GalleryImageDto>(Mapper.ConfigurationProvider)
                   .SingleOrDefaultAsync();
                if (result != null)
                    return result;
                else
                    throw new NotFoundException("There isn't GalleryImage with such id");
            }
        }
    }
}