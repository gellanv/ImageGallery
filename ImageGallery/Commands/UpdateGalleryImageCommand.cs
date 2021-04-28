using MediatR;
using Microsoft.AspNetCore.Http;

namespace ImageGallery.Commands
{
    public class UpdateGalleryImageCommand : IRequest
    {
        public int id { get; set; }
        public int galleryId { get; set; }
        public string title { get; set; }
        public IFormFile photo { get; set; }
        public UpdateGalleryImageCommand(int _id, int _galleryId, string _title, IFormFile _photo)
        {
            id = _id;
            galleryId = _galleryId;
            title = _title;
            photo = _photo;
        }
    }
}