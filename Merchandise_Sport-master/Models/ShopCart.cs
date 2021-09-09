using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Merchandise_Sport_master.Models
{
    public class ShopCart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        [DataType(DataType.Currency, ErrorMessage = "אנא השתמש בספרות בלבד")]
        public float TotalPrice { get; set; } = 0;
        public List<Product> Products { get; set; }
    }
}
