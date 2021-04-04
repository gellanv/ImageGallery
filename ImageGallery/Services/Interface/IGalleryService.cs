using ImageGallery.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageGallery.Services
{
    public interface IGalleryService
    {
        public Task<GalleryDto> PostGalleryAsync(GalleryDto galleryDto);
        public Task PutGalleryAsync(int id, GalleryDto galleryDto);
        public Task<IEnumerable<GalleryDto>> GetGalleriesAsync();
        public Task DeleteGalleryAsync(int id);
    }
}