using System.Collections.Generic;

namespace ImageGallery.Data
{
    public class Gallery
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<GalleryImage> GalleryImages { get; set; }
    }
}