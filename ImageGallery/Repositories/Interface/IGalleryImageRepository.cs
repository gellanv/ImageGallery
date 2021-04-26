using ImageGallery.Data;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Repositories.Interface
{
    public interface IGalleryImageRepository
    {
        Task PostGalleryImageAsync(int galleryId, string title, List<IFormFile> photos);
        Task PutGalleryImageAsync(int id, int galleryId, string title, IFormFile photo);
        Task<IQueryable<GalleryImageDto>> GetGalleryImagesAsync(int galleryId);
        Task<GalleryImageDto> GetGalleryImageAsync(int id);
        Task DeleteGalleryImageAsync(int id);
    }
}
