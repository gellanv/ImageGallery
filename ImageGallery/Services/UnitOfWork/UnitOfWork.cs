using AutoMapper;
using ImageGallery.Data;
using Microsoft.EntityFrameworkCore;

namespace ImageGallery.Services
{
    public class UnitOfWork
    {
        protected readonly IMapper Mapper;
        protected readonly ApplicationDbContext Context;
        public UnitOfWork(ApplicationDbContext context, IMapper mapper)
        {
            Mapper = mapper;
            Context = context;
        }

        private GalleryImageService galleryImageService;
        private GalleryService galleryService;

        public GalleryImageService galleryImages
        {
            get
            {
                if (galleryImageService == null)
                    galleryImageService = new GalleryImageService(Context, Mapper);
                return galleryImageService;
            }
        }

        public GalleryService galleries
        {
            get
            {
                if (galleryService == null)
                    galleryService = new GalleryService(Context, Mapper);
                return galleryService;
            }
        }
    }
}
