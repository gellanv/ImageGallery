using AutoMapper;
using AutoMapper.QueryableExtensions;
using ImageGallery.Data;
using ImageGallery.Exceptions;
using ImageGallery.Features;
using ImageGallery.Features.Abstract;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Queries
{
    public class GetAllGalleryImagesQuery : IRequest<IQueryable<GalleryImageModel>>
    {
        public int GalleryId { get; set; }

        public class GetAllGalleryImagesHandler : BaseRequest, IRequestHandler<GetAllGalleryImagesQuery, IQueryable<GalleryImageModel>>
        {
            public GetAllGalleryImagesHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
            public async Task<IQueryable<GalleryImageModel>> Handle(GetAllGalleryImagesQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var result = Context.GalleryImages
                        .Where(g => g.GalleryId == request.GalleryId)
                        .ProjectTo<GalleryImageModel>(Mapper.ConfigurationProvider);
                    return await Task.FromResult(result);
                }
                catch (System.ArgumentNullException)
                {
                    throw new NotFoundException("Such gallery doesn't exist");
                }
            }
        }
    }
}