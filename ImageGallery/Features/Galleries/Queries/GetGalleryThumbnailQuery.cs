using AutoMapper;
using AutoMapper.QueryableExtensions;
using ImageGallery.Data;
using ImageGallery.Exceptions;
using ImageGallery.Features;
using ImageGallery.Features.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Queries
{
    public class GetGalleryThumbnailQuery : IRequest<byte[]>
    {
        public int Id { get; set; }

        public class GetGalleryThumbnailHandler : BaseRequest, IRequestHandler<GetGalleryThumbnailQuery, byte[]>
        {
            public GetGalleryThumbnailHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
            public async Task<byte[]> Handle(GetGalleryThumbnailQuery request, CancellationToken cancellationToken)
            {
                var result = await Context.GalleryImages
                   .Where(g => g.GalleryId == request.Id)
                   .ProjectTo<GalleryImageModel>(Mapper.ConfigurationProvider)
                   .FirstOrDefaultAsync();
                if (result != null)                
                    return result.Photo;
                else
                    throw new NotFoundException("The gallery thumbnail not found!");
            }
        }
    }
}