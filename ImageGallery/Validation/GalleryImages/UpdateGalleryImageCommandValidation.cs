using FluentValidation;
using ImageGallery.Commands;

namespace ImageGallery.Validation.GalleryImages
{
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