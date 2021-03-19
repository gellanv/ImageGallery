using ImageGallery.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ImageGallery.Services
{
    public interface IGalleryImageService
    {
        int Id { get; set; }
        string Title { get; set; }
        byte[] Photo { get; set; }
        int GalleryId { get; set; }
        public Task<IActionResult> PostImageAsync(int galleryId, string title, IFormFile photo);
        public Task<IActionResult> PutImageAsync(int id, int galleryId, string title, IFormFile photo);
        public Task<ActionResult<GalleryItemDto>> GetGalleryImagesAsync(int galleryId);
        public Task<ActionResult<GalleryImageDto>> GetImageAsync(int id);
        public Task<IActionResult> DeleteImageAsync(int id);
    }
}
