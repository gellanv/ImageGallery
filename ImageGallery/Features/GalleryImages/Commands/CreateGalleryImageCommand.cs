using AutoMapper;
using ImageGallery.Data;
using ImageGallery.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Commands
{
    public class CreateGalleryImageCommand : IRequest
    {
        public int GalleryId { get; set; }
        public string Title { get; set; }
        public List<IFormFile> Photos { get; set; }
        public CreateGalleryImageCommand(int _galleryId, string _title, List<IFormFile> _photos)
        {
            GalleryId = _galleryId;
            Title = _title;
            Photos = _photos;
        }
        public class CreateGalleryImageHandler : IRequestHandler<CreateGalleryImageCommand>
        {
            private readonly ApplicationDbContext Context;
            private readonly IMapper Mapper;
            public CreateGalleryImageHandler(ApplicationDbContext context, IMapper mapper)
            {
                Context = context;
                Mapper = mapper;
            }
            public async Task<Unit> Handle(CreateGalleryImageCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    foreach (var uploadedFoto in request.Photos)
                    {
                        GalleryImageDto galleryImageDto = new() { GalleryId = request.GalleryId, Title = request.Title, Photo = ConvertPhoto(uploadedFoto) };
                        var galleryImage = Mapper.Map<GalleryImage>(galleryImageDto);
                        Context.GalleryImages.Add(galleryImage);
                    }
                    await Context.SaveChangesAsync();
                }
                catch (System.Exception exeption)
                {
                    throw new InternalServerErrorException(exeption.Message);
                }
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