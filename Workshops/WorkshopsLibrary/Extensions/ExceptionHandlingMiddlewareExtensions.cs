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
            return app;
            
        }
    }
}
