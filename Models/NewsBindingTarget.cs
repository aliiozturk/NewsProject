using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class NewsBindingTarget
    {

        [Required]
        public string NewsTitle { get; set; }

        //[Range(1, 1000)]
        //public decimal Price { get; set; }

        [Range(1, long.MaxValue)]
        public long CategoryId { get; set; }
        public string NewsDescription { get; set; }

        public DateTime NewsPublishTime { get; set; }

        //[Range(1, long.MaxValue)]
        //public long SupplierId { get; set; }

        public News ToNews() => new News()
        {
            NewsTitle = this.NewsTitle,
            NewsDescription = this.NewsDescription,
            NewsPublishTime = this.NewsPublishTime,
            //Price = this.Price,
            //CategoryId = this.CategoryId,
            //SupplierId = this.SupplierId
        };
    }
}
