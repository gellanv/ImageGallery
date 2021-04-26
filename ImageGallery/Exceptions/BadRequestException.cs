using System.Net;

namespace ImageGallery.Exceptions
{
    public class BadRequestException : CustomHttpException
    {
        public BadRequestException(string message) : base(HttpStatusCode.BadRequest, message) { }
    }
}