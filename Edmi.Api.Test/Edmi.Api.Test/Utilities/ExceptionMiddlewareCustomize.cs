using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Edmi.Api.Utilities
{
    public class ExceptionMiddlewareCustomize
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddlewareCustomize(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "text/plain";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                if (ex is ApplicationException)
                {
                    await context.Response.WriteAsync(ex.Message);
                }
            }
        }
    }
}