namespace ImageGallery.Services.Interface
{
    public interface IUnitOfWork
    {
        IGalleryImageService galleryImages { get; }

        IGalleryService galleries { get; }
    }
}
