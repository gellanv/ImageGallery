using AutoMapper;
using ImageGallery.Data;
using Microsoft.AspNetCore.Mvc;

namespace ImageGallery.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMapper Mapper;
        protected readonly ApplicationDbContext Context;

        public BaseController(ApplicationDbContext context, IMapper mapper)
        {
           Mapper = mapper;
           Context = context;
        }
    }
}
