using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merchandise_Sport_master.Models
{
    public class CategoryImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    } 
}
