namespace ImageGallery.Data
{
    public class GalleryImage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Photo { get; set; }
        public int GalleryId { get; set; }
        public Gallery Gallery { get; set; }
    }
}