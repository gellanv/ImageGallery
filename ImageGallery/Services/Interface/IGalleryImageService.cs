using ImageGallery.Data;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Services
{
    public interface IGalleryImageService
    {
        public Task PostGalleryImageAsync(int galleryId, string title, List<IFormFile> photos);
        public Task PutGalleryImageAsync(int id, int galleryId, string title, IFormFile photo);
        public Task<IQueryable<GalleryImageDto>> GetGalleryImagesAsync(int galleryId);
        public Task<GalleryImageDto> GetGalleryImageAsync(int id);
        public Task DeleteGalleryImageAsync(int id);
    }
}
