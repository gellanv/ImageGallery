using AutoMapper;
using ImageGallery.Data;
using Microsoft.AspNetCore.Mvc;

namespace ImageGallery.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly ApplicationDbContext _context;

        public BaseController(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
    }
}