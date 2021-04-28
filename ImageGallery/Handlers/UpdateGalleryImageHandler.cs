using ImageGallery.Commands;
using ImageGallery.Repositories.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Handlers
{
    public class UpdateGalleryImageHandler : IRequestHandler<UpdateGalleryImageCommand>
    {
        private readonly IGalleryImageRepository _galleryImageRepository;
        public UpdateGalleryImageHandler(IGalleryImageRepository galleryImageRepository)
        {
            _galleryImageRepository = galleryImageRepository;
        }
        public async Task<Unit> Handle(UpdateGalleryImageCommand request, CancellationToken cancellationToken)
        {
            await _galleryImageRepository.UpdateAsync(request.id, request.galleryId, request.title, request.photo);
            return Unit.Value;
        }
    }
}
