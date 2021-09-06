using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Merchandise_Sport_master.Models
{
    public class Product
    {
        [Key]
        public int SerialNumber { get; set; }

        public string Title { get; set; }

        public int Size { get; set; }

        public int Price { get; set; }

        public string Image { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
