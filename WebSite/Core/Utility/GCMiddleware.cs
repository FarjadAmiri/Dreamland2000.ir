using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebSite.Core.Utility
{
    public class GcMiddleware
    {
        private readonly RequestDelegate _next;

        public GcMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);
            GC.Collect(2, GCCollectionMode.Forced, true);
            GC.WaitForPendingFinalizers();
        }
    }
}
