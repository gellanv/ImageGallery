using ImageGallery.Data;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Repositories.Interface
{
    public interface IGalleryImageRepository
    {
        Task CreateAsync(int galleryId, string title, List<IFormFile> photos);
        Task UpdateAsync(int id, int galleryId, string title, IFormFile photo);
        Task<IQueryable<GalleryImageDto>> GetAllAsync(int galleryId);
        Task<GalleryImageDto> GetAsync(int id);
        Task DeleteAsync(int id);
    }
}