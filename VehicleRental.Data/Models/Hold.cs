using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleRental.Data.Models
{
    public class Hold
    {
        public int Id { get; set; }
        public virtual VehicleRentalAsset VehicleRentalAsset { get; set; }
        public DateTime HoldPlaced { get; set; }
    }
}
