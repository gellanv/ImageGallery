using AutoMapper;
using ImageGallery.Data;

namespace ImageGallery.Features.Abstract
{
    public abstract class BaseRequest
    {
        protected readonly ApplicationDbContext Context;
        protected readonly IMapper Mapper;

        public BaseRequest(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        public BaseRequest(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}
