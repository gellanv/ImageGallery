using System.Net;

namespace ImageGallery.Exeptions
{
    public class InternalServerErrorExeption : CustomHttpException
    {
        public InternalServerErrorExeption(string message) : base(HttpStatusCode.InternalServerError, message) { }
    }
}