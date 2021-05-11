using AutoMapper;
using AutoMapper.QueryableExtensions;
using ImageGallery.Data;
using ImageGallery.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Queries
{
    public class GetAllGalleriesQuery : IRequest<IQueryable<GalleryDto>>
    {
        public class GetAllGalleriesHandler : IRequestHandler<GetAllGalleriesQuery, IQueryable<GalleryDto>>
        {
            private readonly ApplicationDbContext Context;
            private readonly IMapper Mapper;
            public GetAllGalleriesHandler(ApplicationDbContext context, IMapper mapper)
            {
                Context = context;
                Mapper = mapper;
            }
            public async Task<IQueryable<GalleryDto>> Handle(GetAllGalleriesQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var result = Context.Galleries.ProjectTo<GalleryDto>(Mapper.ConfigurationProvider);
                    return await Task.FromResult(result);
                }
                catch (System.Exception exeption)
                {
                    throw new BadRequestException(exeption.Message);
                }
            }
        }
    }
}