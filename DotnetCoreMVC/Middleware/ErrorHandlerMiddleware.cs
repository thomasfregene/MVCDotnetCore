using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreMVC.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                //Forward to next middleware
                await _next(context);
            }
            catch (Exception ex)
            {
                //Log ex
                //Send Email/SMS of the exception to admin
                await context.Response.WriteAsync("sorry something went wrong, please try again");
                //throw;
            }
        }
    }
}
