using FluentValidation;
using ImageGallery.Commands;

namespace ImageGallery.Validation.GalleryImages
{
    public class DeleteGalleryImageCommandValidation : AbstractValidator<DeleteGalleryImageCommand>
    {
        public DeleteGalleryImageCommandValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
