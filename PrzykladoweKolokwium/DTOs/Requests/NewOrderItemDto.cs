using PrzykladoweKolokwium.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrzykladoweKolokwium.DTOs
{
    public class NewOrderItemDto
    {
        [Required]
        [MaxLength(200)]
        public string Wyrob { get; set; }
        [Required]
        public string Ilosc { get; set; }
        [MaxLength(300)]
        public string Uwagi { get; set; }
        
    }
}
