using ImageGallery.Repositories.Interface;

namespace ImageGallery.Services.Interface
{
    public interface IUnitOfWork
    {
        IGalleryImageRepository GalleryImages { get; }
        IGalleryRepository Galleries { get; }
    }
}
