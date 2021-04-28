using ImageGallery.Data;
using MediatR;
using System.Linq;

namespace ImageGallery.Queries
{
    public class GetAllGalleriesQuery : IRequest<IQueryable<GalleryDto>> { }
}