using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class EFNewsRepository : INewsRepository
    {
        private NewsDataContext context;
        public EFNewsRepository(NewsDataContext ctx)
        {
            context = ctx;
        }
        public IQueryable<News> Haberler => context.Haberler;

       

        public void CreateNews(News p)
        {
            context.Add(p);
            context.SaveChanges();
        }

        public void DeleteNews(News p)
        {
            context.Remove(p);
            context.SaveChanges();
        }

        public void SaveNews(News p)
        {
            context.SaveChanges();
        }
    }
}
