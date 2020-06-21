using PrzykladoweKolokwium.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrzykladoweKolokwium.DTOs
{
    public class NewOrderDto
    {
        [Required]
        public DateTime DataPrzyjecia { get; set; }
        [MaxLength(300)]
        public string Uwagi { get; set; }

        public ICollection<NewOrderItemDto> Wyroby { get; set; }
    }
}
