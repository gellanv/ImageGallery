using ImageGallery.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageGallery.Services
{
    public interface IGalleryService
    {
        int Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }

        public Task<ActionResult<GalleryDto>> PostGalleryAsync(GalleryDto galleryDto);
        public Task<IActionResult> PutGalleryAsync(int id, GalleryDto galleryDto);
        public IEnumerable<GalleryDto> GetGalleries();
        public Task<IActionResult> DeleteGalleryAsync(int id);
    }
}
