using AutoMapper;
using ImageGallery.Data;
using ImageGallery.Services.Interface;

namespace ImageGallery.Services
{
    public class UnitOfWork : IUnitOfWork
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

        public IGalleryImageService galleryImages
        {
            get
            {
                if (galleryImageService == null)
                    galleryImageService = new GalleryImageService(Context, Mapper);
                return galleryImageService;
            }
        }

        public IGalleryService galleries
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