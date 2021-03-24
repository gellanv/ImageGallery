using ImageGallery.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageGallery.Services
{
    public interface IGalleryService
    {
        public Task<ActionResult<GalleryDto>> PostGalleryAsync(GalleryDto galleryDto);
        public Task<IActionResult> PutGalleryAsync(int id, GalleryDto galleryDto);
        public Task<IEnumerable<GalleryDto>> GetGalleriesAsync();
        public Task<IActionResult> DeleteGalleryAsync(int id);
    }
}