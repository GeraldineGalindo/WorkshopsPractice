using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;
using Workshops.Exceptions;

namespace WorkshopsLibrary.Extensions
{
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseNativeGlobalExceptionHandler(this IApplicationBuilder app)
        {
            /*
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;

                    var errorResponse = new ErrorResponse();

                    if (exception is DataMismatchException dataException)
                    {
                        errorResponse.StatusCode = StatusCodes.Status406NotAcceptable;
                        errorResponse.Message = dataException.Message;
                    }

                    if (exception is EmptyCollectionException emptyException)
                    {
                        errorResponse.StatusCode = StatusCodes.Status204NoContent;
                        errorResponse.Message = emptyException.Message;
                    }

                    if (exception is NotFoundItemException notFoundException)
                    {
                        errorResponse.StatusCode = StatusCodes.Status404NotFound;
                        errorResponse.Message = notFoundException.Message;
                    }

                    context.Response.StatusCode = (int)errorResponse.StatusCode;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(errorResponse.ToJsonString());
                });
            });
            */
            return app;
            
        }
    }
}
