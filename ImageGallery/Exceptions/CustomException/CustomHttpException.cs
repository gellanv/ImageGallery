using System;
using System.Net;

namespace ImageGallery.Exceptions
{
    public class CustomHttpException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public CustomHttpException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }           

        public override string ToString()
        {
            string response = "StatusCode: " + StatusCode + ",  Message: " + Message;
            return response;
        }
    }
}
