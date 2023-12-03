using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Http;
using Service;
using System.Threading.Tasks;

namespace API
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;

        public IRatingService _ratingService;
        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext,IRatingService ratingService)
        {
   
            DateTime date = DateTime.Now;
            await _next(httpContext);
            Rating rating = new Rating
            {
                Host = httpContext.Request.Host.ToString(),
                Method = httpContext.Request.Method,
                Path = httpContext.Request.Path,
                Referer = httpContext.Request.Headers["Referer"].ToString(),
                UserAgent = httpContext.Request.Headers["User-Agent"].ToString(),
                RecordDate=date
            };

            await ratingService.addRating(rating);

           
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
