using ImageGallery.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ImageGallery.CustomMiddlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
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
        private async Task HandleExceptionAsync(HttpContext context, CustomHttpException customExeption)
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
            await context.Response.WriteAsync(result);
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception tempExeption)
        {
            CustomHttpException tempCuspomExeption = new(HttpStatusCode.BadRequest, tempExeption.Message);
            string result = tempCuspomExeption.ToString();
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(result);
        }
    }
}