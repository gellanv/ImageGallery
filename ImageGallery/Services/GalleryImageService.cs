using AutoMapper;
using AutoMapper.QueryableExtensions;
using ImageGallery.Controllers;
using ImageGallery.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Services
{
    public class GalleryImageService : BaseController, IGalleryImageService
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Photo { get; set; }
        public int GalleryId { get; set; }

        public GalleryImageService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public async Task<IActionResult> PostImageAsync(int galleryId, string title, IFormFile photo)
        {
            var gallery = await _context.Galleries.FindAsync(galleryId);
            if (gallery == null)
            {
                return NotFound();
            }
            else
            {
                GalleryImageDto galleryImageDto = new GalleryImageDto();
                galleryImageDto.Title = title;
                galleryImageDto.GalleryId = galleryId;
                galleryImageDto.Photo = ConverPhoto(photo);
                var galleryImage = _mapper.Map<GalleryImage>(galleryImageDto);
                _context.GalleryImages.Add(galleryImage);
                if (await _context.SaveChangesAsync() != 0)
                {
                    return NoContent();
                }
                else
                    return BadRequest();
            }
        }
        public async Task<IActionResult> PutImageAsync(int id, int galleryId, string title, IFormFile photo)
        {
            GalleryImageDto galleryImageDto = new GalleryImageDto();
            galleryImageDto.Id = id;
            galleryImageDto.GalleryId = galleryId;
            galleryImageDto.Title = title;
            galleryImageDto.Photo = ConverPhoto(photo);

            if (galleryImageDto.Id != id)
            {
                return BadRequest();
            }
            else
            {
                var galleryImage = _mapper.Map<GalleryImage>(galleryImageDto);
                _context.Entry(galleryImage).State = EntityState.Modified;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GalleryImageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private bool GalleryImageExists(int id)
        {
            return _context.GalleryImages.Any(e => e.Id == id);
        }

        public async Task<ActionResult<GalleryItemDto>> GetGalleryImagesAsync(int galleryId)
        {
            // var gallery = await _context.Galleries.FindAsync(galleryId);
            //var GalleryItemDto = _mapper.Map<GalleryItemDto>(gallery);

            List<GalleryImageDto> galleryImageDto = new List<GalleryImageDto>();
            Gallery context = new Gallery();
            galleryImageDto = context.GalleryImages.Where(g => g.GalleryId == galleryId).ProjectTo<GalleryImageDto>(_mapper.ConfigurationProvider).ToList();



            //foreach (GalleryImage galleryImage in _context.GalleryImages)
            //{
            //    if (galleryImage.GalleryId == galleryId)
            //    {
            //        var GalleryImageDto = _mapper.Map<GalleryImageDto>(galleryImage);
            //        galleryImageDto.Add(GalleryImageDto);
            //    }
            //}


            //;



            //var configuration = new MapperConfiguration(cfg =>cfg.CreateMap<OrderLine, OrderLineDTO>().ForMember(dto => dto.Item, conf => conf.MapFrom(ol => ol.Item.Name)));

            //public List<OrderLineDTO> GetLinesForOrder(int orderId)
            //{
            //    using (var context = new orderEntities())
            //    {
            //        return context.OrderLines.Where(ol => ol.OrderId == orderId)
            //                 .ProjectTo<OrderLineDTO>(configuration).ToList();
            //    }
            //}





            if (gallery == null)
            {
                return NotFound();
            }
            return GalleryItemDto;
        }


        public async Task<ActionResult<GalleryImageDto>> GetImageAsync(int id)
        {
            var galleryImage = await _context.GalleryImages.FindAsync(id);
            if (galleryImage == null)
            {
                return NotFound();
            }
            var GalleryImageDto = _mapper.Map<GalleryImageDto>(galleryImage);
            return GalleryImageDto;
        }
        public async Task<IActionResult> DeleteImageAsync(int id)
        {
            var galleryImage = await _context.GalleryImages.FindAsync(id);
            if (galleryImage == null)
            {
                return NotFound();
            }
            _context.GalleryImages.Remove(galleryImage);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private byte[] ConverPhoto(IFormFile galleryPhoto)
        {
            byte[] image = null;
            using (var binaryReader = new BinaryReader(galleryPhoto.OpenReadStream()))
            {
                image = binaryReader.ReadBytes((int)galleryPhoto.Length);
            }
            return image;
        }
    }
}
