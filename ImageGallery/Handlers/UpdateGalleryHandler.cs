using ImageGallery.Commands;
using ImageGallery.Repositories.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Handlers
{
    public class UpdateGalleryHandler : IRequestHandler<UpdateGalleryCommand>
    {
        private readonly IGalleryRepository _galleryRepository;
        public UpdateGalleryHandler(IGalleryRepository galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }
        public async Task<Unit> Handle(UpdateGalleryCommand request, CancellationToken cancellationToken)
        {
            await _galleryRepository.UpdateAsync(request.id, request.galleryDto);
            return Unit.Value;
        }
    }
}
