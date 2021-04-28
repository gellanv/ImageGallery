using ImageGallery.Data;
using MediatR;

namespace ImageGallery.Commands
{
    public class UpdateGalleryCommand : IRequest
    {
        public int id { get; set; }
        public GalleryDto galleryDto { get; set; }
        public UpdateGalleryCommand(int _id, GalleryDto _galleryDto)
        {
            id = _id;
            galleryDto = _galleryDto;
        }
    }
}