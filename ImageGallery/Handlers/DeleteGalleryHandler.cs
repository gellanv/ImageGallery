using ImageGallery.Commands;
using ImageGallery.Repositories.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Handlers
{
    public class DeleteGalleryHandler : IRequestHandler<DeleteGalleryCommand>
    {
        private readonly IGalleryRepository _galleryRepository;
        public DeleteGalleryHandler(IGalleryRepository galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }
        public async Task<Unit> Handle(DeleteGalleryCommand request, CancellationToken cancellationToken)
        {
            await _galleryRepository.DeleteAsync(request.id);
            return Unit.Value;
        }
    }
}