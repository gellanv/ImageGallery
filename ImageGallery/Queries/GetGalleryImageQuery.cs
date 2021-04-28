using ImageGallery.Data;
using MediatR;

namespace ImageGallery.Queries
{
    public class GetGalleryImageQuery : IRequest<GalleryImageDto>
    {
        public int id { get; set; }
        public GetGalleryImageQuery(int _id)
        {
            id = _id;
        }
    }
}