using FluentValidation;
using ImageGallery.Commands;

namespace ImageGallery.Validation.Galleries
{
    public class CreateGalleryCommandValidation : AbstractValidator<CreateGalleryCommand>
    {
        public CreateGalleryCommandValidation()
        {
            RuleFor(x => x.GalleryDto.Title).MaximumLength(50);
            RuleFor(x => x.GalleryDto.Description).MaximumLength(500);
        }
    }
}