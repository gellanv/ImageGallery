using System.Net;

namespace ImageGallery.Exeptions
{
    public class BadRequestException : CustomHttpException
    {
        public BadRequestException(string message) : base(HttpStatusCode.BadRequest, message) { }
    }
}