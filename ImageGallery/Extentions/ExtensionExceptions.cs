using ImageGallery.CustomMiddlewares;
using Microsoft.AspNetCore.Builder;

namespace ImageGallery.Exeptions
{
    public static class ExtensionExceptions
    {
        public static void UseCustomExeptionsHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExeptionHandlingMiddleware>();
        }
    }
}