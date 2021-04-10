﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using ImageGallery.Data;
using ImageGallery.Exeptions;
using ImageGallery.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ImageGallery.Services
{
    public class GalleryImageService : BaseService, IGalleryImageService
    {
        public GalleryImageService(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
        public async Task PostGalleryImageAsync(int galleryId, string title, IFormFile photo)
        {
            try
            {
                GalleryImageDto galleryImageDto = new() { GalleryId = galleryId, Title = title, Photo = ConvertPhoto(photo) };
                var galleryImage = Mapper.Map<GalleryImage>(galleryImageDto);
                Context.GalleryImages.Add(galleryImage);
                await Context.SaveChangesAsync();
            }
            catch (System.Exception exeption)
            {
                throw new CustomHttpException(HttpStatusCode.InternalServerError, exeption.Message);
            }
        }
        public async Task PutGalleryImageAsync(int id, int galleryId, string title, IFormFile photo)
        {
            if (Context.GalleryImages.Any(e => e.Id == id))
            {
                GalleryImageDto galleryImageDto = new() { Id = id, GalleryId = galleryId, Title = title, Photo = ConvertPhoto(photo) };
                var galleryImage = Mapper.Map<GalleryImage>(galleryImageDto);
                Context.Entry(galleryImage).State = EntityState.Modified;
                await Context.SaveChangesAsync();
            }
            else
                new CustomHttpException(HttpStatusCode.NotFound, "There isn't GalleryImage with such id");
        }
        public async Task<IQueryable<GalleryImageDto>> GetGalleryImagesAsync(int galleryId)
        {
            try
            {
                var result = Context.GalleryImages
                    .Where(g => g.GalleryId == galleryId)
                    .ProjectTo<GalleryImageDto>(Mapper.ConfigurationProvider);
                return await Task.FromResult(result);
            }
            catch (System.ArgumentNullException)
            {
                throw new CustomHttpException(HttpStatusCode.NotFound, "Such gallery don't exist");
            }
        }
        public async Task<GalleryImageDto> GetGalleryImageAsync(int id)
        {
            var result = await Context.GalleryImages
                .Where(g => g.Id == id)
                .ProjectTo<GalleryImageDto>(Mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
            if (result != null)
                return result;
            else
                throw new CustomHttpException(HttpStatusCode.NotFound, "There isn't GalleryImage with such id");
        }
        public async Task DeleteGalleryImageAsync(int id)
        {
            var item = await Context.GalleryImages.
               Where(g => g.Id == id).
               SingleOrDefaultAsync();
            if (item != null)
            {
                Context.GalleryImages.Remove(item);
                await Context.SaveChangesAsync();
            }
            else
                throw new CustomHttpException(HttpStatusCode.NotFound, "There isn't GalleryImage with such id");
        }
        private byte[] ConvertPhoto(IFormFile galleryPhoto)
        {
            byte[] image = null;
            using (var binaryReader = new BinaryReader(galleryPhoto.OpenReadStream()))
            {
                image = binaryReader.ReadBytes((int)galleryPhoto.Length);
            }
            return image;
        }
    }
}
