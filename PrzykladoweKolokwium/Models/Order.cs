using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrzykladoweKolokwium.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int IdOrder { get; set; }
        [Required]
        public DateTime AcceptanceDate { get; set; }
        public DateTime RealizationDate { get; set; }
        [MaxLength(300)]
        public string Comments { get; set; }

        [ForeignKey("Client")]
        public int IdClient { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Employee")]
        public int IdEmployee { get; set; }
        public Employee Employee { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
