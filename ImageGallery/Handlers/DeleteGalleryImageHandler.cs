using ImageGallery.Commands;
using ImageGallery.Repositories.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Handlers
{
    public class DeleteGalleryImageHandler : IRequestHandler<DeleteGalleryImageCommand>
    {
        private readonly IGalleryImageRepository _galleryImageRepository;
        public DeleteGalleryImageHandler(IGalleryImageRepository galleryImageRepository)
        {
            _galleryImageRepository = galleryImageRepository;
        }
        public async Task<Unit> Handle(DeleteGalleryImageCommand request, CancellationToken cancellationToken)
        {
            await _galleryImageRepository.DeleteAsync(request.id);
            return Unit.Value;
        }
    }
}