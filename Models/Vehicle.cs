using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.Models
{
    public class Vehicle
    {
        [Required]
        [Key]
        public string LicensePlate { get; set; }
        [Required]
        public string OwnerName { get; set; }
        [Required]
        public int Telephone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public DateTime DateRegistry { get; set; }

    }
}
