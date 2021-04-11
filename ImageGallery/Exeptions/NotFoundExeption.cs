using System.Net;

namespace ImageGallery.Exeptions
{
    public class NotFoundExeption : CustomHttpException
    {
        public NotFoundExeption(string message) : base(HttpStatusCode.NotFound, message) { }
    }
}