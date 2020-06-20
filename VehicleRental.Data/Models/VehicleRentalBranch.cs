using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VehicleRental.Data.Models
{
    public class VehicleRentalBranch
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40, ErrorMessage ="Limit Branch Name to 40 Characters")]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        public string Telephone { get; set; }
        public DateTime OpenDate { get; set; }

        public virtual IEnumerable<Patron> Patrons { get; set; }
        public virtual IEnumerable<VehicleRentalAsset> VehicleRentalAssets { get; set; }
        public string ImageUrl { get; set; }
    }
}
