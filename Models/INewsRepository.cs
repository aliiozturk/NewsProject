using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public interface INewsRepository
    {
        IQueryable<News> Haberler { get; }

        void SaveNews(News p);
        void CreateNews(News p);
        void DeleteNews(News p);
    }
}
