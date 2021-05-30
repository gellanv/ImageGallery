using AutoMapper;
using FluentValidation;
using ImageGallery.Data;
using ImageGallery.Exceptions;
using ImageGallery.Features.Abstract;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Commands
{
    public class CreateGalleryImageCommand : IRequest<int>
    {
        public string Title { get; set; }
        public int GalleryId { get; set; }
        public byte[] Photo { get; set; }

        public byte[] ConvertPhoto(IFormFile galleryPhoto)
        {
            byte[] image = null;
            using (var binaryReader = new BinaryReader(galleryPhoto.OpenReadStream()))
            {
                image = binaryReader.ReadBytes((int)galleryPhoto.Length);
            }
            return image;
        }

        public class CreateGalleryImageHandler : BaseRequest, IRequestHandler<CreateGalleryImageCommand, int>
        {
            public CreateGalleryImageHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
            public async Task<int> Handle(CreateGalleryImageCommand request, CancellationToken cancellationToken)
            {
                GalleryImage galleryImage;
                try
                {
                    galleryImage = Mapper.Map<GalleryImage>(request);
                    Context.GalleryImages.Add(galleryImage);
                    await Context.SaveChangesAsync();
                }
                catch (System.Exception exeption)
                {
                    throw new InternalServerErrorException(exeption.Message);
                }
                return galleryImage.Id;
            }
        }

        public class CreateGalleryImageCommandValidation : AbstractValidator<CreateGalleryImageCommand>
        {
            public CreateGalleryImageCommandValidation()
            {
                RuleFor(x => x.GalleryId).NotEmpty();
                RuleFor(x => x.Title).MaximumLength(50);
                RuleFor(x => x.Photo).NotNull();
            }
        }
    }
}