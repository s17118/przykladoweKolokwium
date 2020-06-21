using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrzykladoweKolokwium.Models
{
    public class OrderItem
    {
        
        [Required]
        public int Quantity { get; set; }
        [MaxLength(300)]
        public string Comments { get; set; }

        [Key]
        [ForeignKey("ConfectioneryProduct")]
        public int IdConfectioneryProduct { get; set; }
        public ConfectioneryProduct ConfectioneryProduct { get; set; }

        [Key]
        [ForeignKey("Order")]
        public int IdOrder { get; set; }
        public Order Order { get; set; }
    }
}
