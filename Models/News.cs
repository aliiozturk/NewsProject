using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class News
    {
        [Key]
        public long NewsId { get; set; }

        public string NewsTitle { get; set; }
        //[Column(TypeName = "decimal(8, 2)")]
        //public decimal Price { get; set; }

        public string NewsDescription { get; set; }
        public DateTime NewsPublishTime { get; set; }
        //public long CategoryId { get; set; }
        //public Category Category { get; set; }

        //public long SupplierId { get; set; }
        //public Supplier Supplier { get; set; }
    }
}
