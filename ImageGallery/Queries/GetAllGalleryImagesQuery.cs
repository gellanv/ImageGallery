using ImageGallery.Data;
using MediatR;
using System.Linq;

namespace ImageGallery.Queries
{
    public class GetAllGalleryImagesQuery : IRequest<IQueryable<GalleryImageDto>>
    {
        public int idGallery { get; set; }
        public GetAllGalleryImagesQuery(int _id)
        {
            idGallery = _id;
        }
    }
}