using ImageGallery.Data;
using ImageGallery.Queries;
using ImageGallery.Repositories.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Handlers
{
    public class GetGalleryImageHandler : IRequestHandler<GetGalleryImageQuery, GalleryImageDto>
    {
        private readonly IGalleryImageRepository _galleryImageRepository;
        public GetGalleryImageHandler(IGalleryImageRepository galleryImageRepository)
        {
            _galleryImageRepository = galleryImageRepository;
        }
        public async Task<GalleryImageDto> Handle(GetGalleryImageQuery request, CancellationToken cancellationToken)
        {
            var result = await _galleryImageRepository.GetAsync(request.id);
            return result;
        }
    }
}
