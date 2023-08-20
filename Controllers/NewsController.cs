using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
    public class NewsController : Controller
    {
        private INewsRepository newsrepository;
        public int pageSize = 4;

        public NewsController(INewsRepository repo)
        {
            newsrepository = repo;
        }

        //private NewsDataContext context;

        //public NewsController(NewsDataContext ctx)
        //{
        //    context = ctx;
        //}
        public ViewResult Index()
        {
            return View();
        }
        [HttpGet("/News/GetNews")]
        public ViewResult GetNews()
        {
            var news = newsrepository.Haberler;
            return View(news);
        }

        [HttpGet("/News/NewsDetailById/{id}")]
        public ActionResult NewsDetailById(int id)
        {
            var news = newsrepository.Haberler.FirstOrDefault(x => x.NewsId == id);
            return View(news);
        }
    }
}
