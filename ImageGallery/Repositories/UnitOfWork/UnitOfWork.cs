using AutoMapper;
using ImageGallery.Data;
using ImageGallery.Repositories.Interface;
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

        private GalleryImageRepository galleryImageRepository;
        private GalleryRepository galleryRepository;

        public IGalleryImageRepository GalleryImages
        {
            get
            {
                if (galleryImageRepository == null)
                    galleryImageRepository = new GalleryImageRepository(Context, Mapper);
                return galleryImageRepository;
            }
        }

        public IGalleryRepository Galleries
        {
            get
            {
                if (galleryRepository == null)
                    galleryRepository = new GalleryRepository(Context, Mapper);
                return galleryRepository;
            }
        }
    }
}