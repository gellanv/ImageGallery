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
    public class GetGalleryQuery : IRequest<GalleryModel>
    {
        public int Id { get; set; }

        public class GetGalleryImageHandler : BaseRequest, IRequestHandler<GetGalleryQuery, GalleryModel>
        {
            public GetGalleryImageHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
            public async Task<GalleryModel> Handle(GetGalleryQuery request, CancellationToken cancellationToken)
            {
                var result = await Context.Galleries
                   .Where(g => g.Id == request.Id)
                   .ProjectTo<GalleryModel>(Mapper.ConfigurationProvider)
                   .SingleOrDefaultAsync();
                if (result != null)
                    return result;
                else
                    throw new NotFoundException("The gallery not found!");
            }           
        }
    }
}
