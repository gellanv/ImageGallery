using ImageGallery.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Services
{
    public interface IGalleryImageService
    {
        public Task<IActionResult> PostGalleryImageAsync(int galleryId, string title, IFormFile photo);
        public Task<IActionResult> PutGalleryImageAsync(int id, int galleryId, string title, IFormFile photo);
        public Task<IQueryable<GalleryImageDto>> GetGalleryImagesAsync(int galleryId);
        public Task<GalleryImageDto> GetGalleryImageAsync(int id);
        public Task<IActionResult> DeleteGalleryImageAsync(int id);
    }
}
