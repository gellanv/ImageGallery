using ImageGallery.Exceptions;
using ImageGallery.Exeptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ImageGallery.CustomMiddlewares
{
    public class ExeptionHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ExeptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (CustomHttpException customExeption)
            {
                await HandleExceptionAsync(context, customExeption);
            }
            catch (Exception tempExeption)
            {
                await HandleExceptionAsync(context, tempExeption);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, CustomHttpException customExeption)
        {
            string result = null;
            if (customExeption is CustomHttpException)
            {
                result = customExeption.ToString();
                context.Response.StatusCode = (int)customExeption.StatusCode;
            }
            else
            {
                CustomHttpException tempCuspomExeption = new(HttpStatusCode.BadRequest, "Runtime Error");
                result = tempCuspomExeption.ToString();
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            return context.Response.WriteAsync(result);
        }

        private Task HandleExceptionAsync(HttpContext context, Exception tempExeption)
        {
            CustomHttpException tempCuspomExeption = new(HttpStatusCode.BadRequest, tempExeption.Message);
            string result = tempCuspomExeption.ToString();
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return context.Response.WriteAsync(result);
        }
    }
}
