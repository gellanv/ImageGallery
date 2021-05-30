namespace ImageGallery.Features
{
    public class GalleryImageModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GalleryId { get; set; }
        public byte[] Photo { get; set; }
    }
}