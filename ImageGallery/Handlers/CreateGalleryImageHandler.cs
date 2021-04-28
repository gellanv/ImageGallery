using ImageGallery.Commands;
using ImageGallery.Repositories.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Handlers
{
    public class CreateGalleryImageHandler : IRequestHandler<CreateGalleryImageCommand>
    {
        private readonly IGalleryImageRepository _galleryImageRepository;
        public CreateGalleryImageHandler(IGalleryImageRepository galleryImageRepository)
        {
            _galleryImageRepository = galleryImageRepository;
        }
        public async Task<Unit> Handle(CreateGalleryImageCommand request, CancellationToken cancellationToken)
        {
            await _galleryImageRepository.CreateAsync(request.galleryId, request.title, request.photos);
            return Unit.Value;
        }
    }
}