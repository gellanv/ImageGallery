using System.Net;

namespace ImageGallery.Exceptions
{
    public class NotFoundException : CustomHttpException
    {
        public NotFoundException(string message) : base(HttpStatusCode.NotFound, message) { }
    }
}