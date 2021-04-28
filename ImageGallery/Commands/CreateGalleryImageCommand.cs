using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ImageGallery.Commands
{
    public class CreateGalleryImageCommand : IRequest
    {
        public int galleryId { get; set; }
        public string title { get; set; }
        public List<IFormFile> photos { get; set; }
        public CreateGalleryImageCommand(int _galleryId, string _title, List<IFormFile> _photos)
        {
            galleryId = _galleryId;
            title = _title;
            photos = _photos;
        }
    }
}