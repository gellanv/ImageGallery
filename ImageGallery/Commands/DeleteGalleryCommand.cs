using MediatR;

namespace ImageGallery.Commands
{
    public class DeleteGalleryCommand : IRequest
    {
        public int id { get; set; }
        public DeleteGalleryCommand(int id)
        {
            this.id = id;
        }
    }
}
