using ImageGallery.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageGallery.Repositories.Interface
{
    public interface IGalleryRepository
    {
        Task<GalleryDto> PostGalleryAsync(GalleryDto galleryDto);
        Task PutGalleryAsync(int id, GalleryDto galleryDto);
        Task<IEnumerable<GalleryDto>> GetGalleriesAsync();
        Task DeleteGalleryAsync(int id);
    }
}
