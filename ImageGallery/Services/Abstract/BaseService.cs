using AutoMapper;
using ImageGallery.Data;

namespace ImageGallery.Services.Abstract
{
    public abstract class BaseService
    {
        protected readonly IMapper Mapper;
        protected readonly ApplicationDbContext Context;
        public BaseService() { }
        public BaseService(ApplicationDbContext context, IMapper mapper)
        {
            Mapper = mapper;
            Context = context;
        }
    }
}
