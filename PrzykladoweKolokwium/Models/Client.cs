using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrzykladoweKolokwium.Models
{
    public class Client
    {
        [Key]
        [Required]
        public int IdClient { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(60)]
        public string Surname { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
