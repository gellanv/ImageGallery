using System.Collections.Generic;

namespace ImageGallery.Data
{
    public class GalleryItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<GalleryImageDto> GalleryImagesDto { get; set; }
    }
}