using FluentValidation;
using ImageGallery.Commands;

namespace ImageGallery.Validation.Galleries
{
    public class DeleteGalleryCommandValidation : AbstractValidator<DeleteGalleryCommand>
    {
        public DeleteGalleryCommandValidation()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}