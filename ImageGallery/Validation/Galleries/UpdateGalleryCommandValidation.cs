using FluentValidation;
using ImageGallery.Commands;

namespace ImageGallery.Validation.Galleries
{
    public class UpdateGalleryCommandValidation : AbstractValidator<UpdateGalleryCommand>
    {
        public UpdateGalleryCommandValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.GalleryDto.Id).NotEmpty();
            RuleFor(x => x.GalleryDto.Title).MaximumLength(50);
            RuleFor(x => x.GalleryDto.Description).MaximumLength(500);
        }
    }
}