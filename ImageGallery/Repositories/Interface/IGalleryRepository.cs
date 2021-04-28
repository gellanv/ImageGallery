using ImageGallery.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Repositories.Interface
{
    public interface IGalleryRepository
    {
        Task<GalleryDto> CreateAsync(GalleryDto galleryDto);
        Task UpdateAsync(int id, GalleryDto galleryDto);
        Task<IQueryable<GalleryDto>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}