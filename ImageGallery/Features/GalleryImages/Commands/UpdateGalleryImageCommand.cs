using AutoMapper;
using ImageGallery.Data;
using ImageGallery.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Commands
{
    public class UpdateGalleryImageCommand : IRequest
    {
        public int Id { get; set; }
        public int GalleryId { get; set; }
        public string Title { get; set; }
        public IFormFile Photo { get; set; }
        public UpdateGalleryImageCommand(int _id, int _galleryId, string _title, IFormFile _photo)
        {
            Id = _id;
            GalleryId = _galleryId;
            Title = _title;
            Photo = _photo;
        }
        public class UpdateGalleryImageHandler : IRequestHandler<UpdateGalleryImageCommand>
        {
            private readonly ApplicationDbContext Context;
            private readonly IMapper Mapper;
            public UpdateGalleryImageHandler(ApplicationDbContext context, IMapper mapper)
            {
                Context = context;
                Mapper = mapper;
            }
            public async Task<Unit> Handle(UpdateGalleryImageCommand request, CancellationToken cancellationToken)
            {
                if (Context.GalleryImages.Any(e => e.Id == request.Id))
                {
                    GalleryImageDto galleryImageDto = new() { Id = request.Id, GalleryId = request.GalleryId, Title = request.Title, Photo = ConvertPhoto(request.Photo) };
                    var galleryImage = Mapper.Map<GalleryImage>(galleryImageDto);
                    Context.Entry(galleryImage).State = EntityState.Modified;
                    await Context.SaveChangesAsync();
                }
                else
                    throw new NotFoundException("There isn't GalleryImage with such id");
                return Unit.Value;
            }
            private byte[] ConvertPhoto(IFormFile galleryPhoto)
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
}