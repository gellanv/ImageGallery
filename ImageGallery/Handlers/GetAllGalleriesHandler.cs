using ImageGallery.Data;
using ImageGallery.Queries;
using ImageGallery.Repositories.Interface;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Handlers
{
    public class GetAllGalleriesHandler : IRequestHandler<GetAllGalleriesQuery, IQueryable<GalleryDto>>
    {
        private readonly IGalleryRepository _galleryRepository;
        public GetAllGalleriesHandler(IGalleryRepository galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }
        public async Task<IQueryable<GalleryDto>> Handle(GetAllGalleriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _galleryRepository.GetAllAsync();
            return result;
        }
    }
}