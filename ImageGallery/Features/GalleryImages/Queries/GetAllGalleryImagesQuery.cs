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
    public class GetAllGalleryImagesQuery : IRequest<IQueryable<GalleryImageDto>>
    {
        public int galleryId { get; set; }
        public GetAllGalleryImagesQuery(int _galleryId)
        {
            galleryId = _galleryId;
        }
        public class GetAllGalleryImagesHandler : IRequestHandler<GetAllGalleryImagesQuery, IQueryable<GalleryImageDto>>
        {
            private ApplicationDbContext Context;
            private IMapper Mapper;
            public GetAllGalleryImagesHandler(ApplicationDbContext context, IMapper mapper)
            {
                Context = context;
                Mapper = mapper;
            }
            public async Task<IQueryable<GalleryImageDto>> Handle(GetAllGalleryImagesQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var result = Context.GalleryImages
                        .Where(g => g.GalleryId == request.galleryId)
                        .ProjectTo<GalleryImageDto>(Mapper.ConfigurationProvider);
                    return await Task.FromResult(result);
                }
                catch (System.ArgumentNullException)
                {
                    throw new NotFoundException("Such gallery don't exist");
                }
            }
        }
    }
}