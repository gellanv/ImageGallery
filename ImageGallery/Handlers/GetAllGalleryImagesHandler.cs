using ImageGallery.Data;
using ImageGallery.Queries;
using ImageGallery.Repositories.Interface;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Handlers
{
    public class GetAllGalleryImagesHandler : IRequestHandler<GetAllGalleryImagesQuery, IQueryable<GalleryImageDto>>
    {
        private readonly IGalleryImageRepository _galleryImageRepository;
        public GetAllGalleryImagesHandler(IGalleryImageRepository galleryImageRepository)
        {
            _galleryImageRepository = galleryImageRepository;
        }
        public async Task<IQueryable<GalleryImageDto>> Handle(GetAllGalleryImagesQuery request, CancellationToken cancellationToken)
        {
            var result = await _galleryImageRepository.GetAllAsync(request.idGallery);
            return result;
        }
    }
}