using AutoMapper;
using ImageGallery.Data;

namespace ImageGallery.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Gallery, GalleryDto>().ReverseMap();
            CreateMap<Gallery, GalleryItemDto>().ReverseMap();
            CreateMap<GalleryImage, GalleryImageDto>().ReverseMap();
        }
    }
}