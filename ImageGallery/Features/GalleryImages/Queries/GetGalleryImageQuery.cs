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
    public class GetGalleryImageQuery : IRequest<GalleryImageModel>
    {
        public int Id { get; set; }

        public class GetGalleryImageHandler : BaseRequest, IRequestHandler<GetGalleryImageQuery, GalleryImageModel>
        {
            public GetGalleryImageHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
            public async Task<GalleryImageModel> Handle(GetGalleryImageQuery request, CancellationToken cancellationToken)
            {
                var result = await Context.GalleryImages
                   .Where(g => g.Id == request.Id)
                   .ProjectTo<GalleryImageModel>(Mapper.ConfigurationProvider)
                   .SingleOrDefaultAsync();
                if (result != null)
                    return result;
                else
                    throw new NotFoundException("The gallery image not found!");
            }
        }
    }
}