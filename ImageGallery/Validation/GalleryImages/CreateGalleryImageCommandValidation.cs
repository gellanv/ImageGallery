using FluentValidation;
using ImageGallery.Commands;

namespace ImageGallery.Validation.GalleryImages
{
    public class CreateGalleryImageCommandValidation : AbstractValidator<CreateGalleryImageCommand>
    {
        public CreateGalleryImageCommandValidation()
        {
            RuleFor(x => x.GalleryId).NotEmpty();
            RuleFor(x => x.Title).MaximumLength(50);
            RuleFor(x => x.Photos).NotNull();
        }
    }
}