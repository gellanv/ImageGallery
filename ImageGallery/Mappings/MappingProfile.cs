using AutoMapper;
using ImageGallery.Commands;
using ImageGallery.Data;
using ImageGallery.Features;

namespace ImageGallery.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Gallery, GalleryModel>();
            CreateMap<CreateGalleryCommand, Gallery>();
            CreateMap<UpdateGalleryCommand, Gallery>();

            CreateMap<GalleryImage, GalleryImageModel>();
            CreateMap<UpdateGalleryImageCommand, GalleryImage>();
            CreateMap<CreateGalleryImageCommand, GalleryImage>();
        }
    }
}