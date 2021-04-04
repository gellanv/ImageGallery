using Microsoft.AspNetCore.Builder;

namespace ImageGallery.CustomMiddleware
{
    public static class MethodCustomMiddleware
    {
        public static void ExtensiondCustomMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomHandlingMiddleware>();
        }
    }
}