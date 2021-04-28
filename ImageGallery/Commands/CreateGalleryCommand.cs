using ImageGallery.Data;
using MediatR;

namespace ImageGallery.Commands
{
    public class CreateGalleryCommand : IRequest
    {
        public GalleryDto galleryDto { get; set; }
        public CreateGalleryCommand(GalleryDto _galleryDto)
        {
            galleryDto = _galleryDto;
        }
    }
}