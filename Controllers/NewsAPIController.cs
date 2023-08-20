using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsAPIController : ControllerBase
    {
        private NewsDataContext context;

        public NewsAPIController(NewsDataContext ctx)
        {
            context = ctx;
        }

        [HttpGet("getnews")]
        public IAsyncEnumerable<News> GetNews()
        {
            return context.Haberler;
        }

        [HttpGet("getnews/{id}")]
        public async Task<IActionResult> GetNews(long id)
        {
            News p = await context.Haberler.FindAsync(id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                NewsId = p.NewsId,
                NewsTitle = p.NewsTitle,
                NewsDescription = p.NewsDescription
                
            });
        }

        [HttpPost("savenews")]
        public async Task<IActionResult> SaveNews(NewsBindingTarget target)
        {
            News p = target.ToNews();
            await context.Haberler.AddAsync(p);
            await context.SaveChangesAsync();
            return Ok(p);
        }

        [HttpPut("updatenews")]
        public async Task UpdateNews(News news)
        {
            context.Update(news);
            await context.SaveChangesAsync();
        }

        [HttpDelete("deletenews/{id}")]
        public async Task DeleteNews(long id)
        {
            context.Haberler.Remove(new News() { NewsId = id });
            await context.SaveChangesAsync();
        }

        [HttpGet("redirect")]
        public IActionResult Redirect()
        {
            return RedirectToAction(nameof(GetNews), new { Id = 1 });
        }
    }
}
