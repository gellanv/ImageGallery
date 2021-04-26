using System.Net;

namespace ImageGallery.Exceptions
{
    public class InternalServerErrorException : CustomHttpException
    {
        public InternalServerErrorException(string message) : base(HttpStatusCode.InternalServerError, message) { }
    }
}