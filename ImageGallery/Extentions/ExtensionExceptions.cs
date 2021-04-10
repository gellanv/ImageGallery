using Microsoft.AspNetCore.Builder;

namespace ImageGallery.CustomMiddleware
{
    public static class ExtensionExceptions
    {
        public static void UseCustomExeptionsHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomHandlingMiddleware>();
        }
    }
}