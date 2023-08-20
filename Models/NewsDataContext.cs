using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class NewsDataContext : DbContext
    {
        public NewsDataContext(DbContextOptions<NewsDataContext> opts)
        : base(opts) { }

        public DbSet<News> Haberler { get; set; }
        public DbSet<Category> Kategoriler { get; set; }
    }
}
