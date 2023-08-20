using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using SportsStore.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace SportsStore
{
    public static class WebServiceEndpoint
    {
        private static string BASEURL = "api/news";

        public static void MapWebService(this IEndpointRouteBuilder app)
        {

            app.MapGet($"{BASEURL}/{{id}}", async context => {
                long key = long.Parse(context.Request.RouteValues["id"] as string);
                NewsDataContext data = context.RequestServices.GetService<NewsDataContext>();
                News p = data.Haberler.Find(key);
                if (p == null)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                }
                else
                {
                    context.Response.ContentType = "application/json";
                    await context.Response
                        .WriteAsync(JsonSerializer.Serialize<News>(p));
                }
            });

            app.MapGet(BASEURL, async context => {
                NewsDataContext data = context.RequestServices.GetService<NewsDataContext>();
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer
                    .Serialize<IEnumerable<News>>(data.Haberler));
            });

            app.MapPost(BASEURL, async context => {
                NewsDataContext data = context.RequestServices.GetService<NewsDataContext>();
                News p = await
                    JsonSerializer.DeserializeAsync<News>(context.Request.Body);
                await data.AddAsync(p);
                await data.SaveChangesAsync();
                context.Response.StatusCode = StatusCodes.Status200OK;
            });
        }
    }
}
