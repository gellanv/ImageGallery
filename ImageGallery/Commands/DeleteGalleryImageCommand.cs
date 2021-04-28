using MediatR;

namespace ImageGallery.Commands
{
    public class DeleteGalleryImageCommand : IRequest
    {
        public int id { get; set; }
        public DeleteGalleryImageCommand(int id)
        {
            this.id = id;
        }
    }
}