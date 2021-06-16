using AutoMapper;
using AutoMapper.QueryableExtensions;
using ImageGallery.Data;
using ImageGallery.Exceptions;
using ImageGallery.Features;
using ImageGallery.Features.Abstract;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ImageGallery.Queries
{
    public class GetAllGalleriesQuery : IRequest<IQueryable<GalleryModel>>
    {
        public class GetAllGalleriesHandler : BaseRequest, IRequestHandler<GetAllGalleriesQuery, IQueryable<GalleryModel>>
        {
            public GetAllGalleriesHandler(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
            public async Task<IQueryable<GalleryModel>> Handle(GetAllGalleriesQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var result = Context.Galleries.ProjectTo<GalleryModel>(Mapper.ConfigurationProvider);
                    return await Task.FromResult(result);
                }
                catch (System.Exception exeption)
                {
                    throw new BadRequestException(exeption.Message);
                }
            }
        }
    }
}