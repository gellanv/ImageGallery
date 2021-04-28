using ImageGallery.Commands;
using ImageGallery.Repositories.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Handlers
{
    public class CreateGalleryHandler : IRequestHandler<CreateGalleryCommand>
    {
        private readonly IGalleryRepository _galleryRepository;
        public CreateGalleryHandler(IGalleryRepository galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }
        public async Task<Unit> Handle(CreateGalleryCommand request, CancellationToken cancellationToken)
        {
            await _galleryRepository.CreateAsync(request.galleryDto);
            return Unit.Value;
        }
    }
}