namespace ImageGallery.Data
{
    public class GalleryImageDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GalleryId { get; set; }
        public byte[] Photo { get; set; }
    }
}