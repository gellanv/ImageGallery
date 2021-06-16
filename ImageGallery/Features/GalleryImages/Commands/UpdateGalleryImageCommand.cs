using AutoMapper;
using FluentValidation;
using ImageGallery.Data;
using ImageGallery.Exceptions;
using ImageGallery.Features.Abstract;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Commands
{
    public class UpdateGalleryImageCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int GalleryId { get; set; }
        public string Title { get; set; }
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

        public class UpdateGalleryImageHandler : BaseRequest, IRequestHandler<UpdateGalleryImageCommand>
        {
            public UpdateGalleryImageHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
            public async Task<Unit> Handle(UpdateGalleryImageCommand request, CancellationToken cancellationToken)
            {
                var galleryImage = Context.GalleryImages.SingleOrDefault(i => i.Id == request.Id);
                if (galleryImage == null)
                    throw new NotFoundException("The gallery image not found!");
                Mapper.Map(request, galleryImage);
                await Context.SaveChangesAsync();
                return Unit.Value;
            }
        }
        public class UpdateGalleryImageCommandValidation : AbstractValidator<UpdateGalleryImageCommand>
        {
            public UpdateGalleryImageCommandValidation()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.Title).MaximumLength(50);
                RuleFor(x => x.Photo).NotNull();
            }
        }
    }
}