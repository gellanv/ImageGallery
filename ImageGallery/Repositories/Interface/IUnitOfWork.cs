using ImageGallery.Repositories.Interface;

namespace ImageGallery.Services.Interface
{
    public interface IUnitOfWork
    {
        IGalleryImageRepository galleryImages { get; }
        IGalleryRepository galleries { get; }
    }
}
