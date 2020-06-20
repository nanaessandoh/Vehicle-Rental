using Microsoft.EntityFrameworkCore;
using System;
using VehicleRental.Data.Models;

namespace VehicleRental.Data
{
    public class VehicleRentalDBContext: DbContext
    {
        public VehicleRentalDBContext(DbContextOptions options) : base(options) { }

        public DbSet<BranchHour> BranchHours { get; set; }
        public DbSet<CheckoutHistory> CheckoutHistories { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<DriverLicense> DriverLicenses { get; set; }
        public DbSet<Hold> Holds { get; set; }
        public DbSet<Patron> Patrons { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<VehicleRentalAsset> VehicleRentalAssets { get; set; }
        public DbSet<VehicleRentalBranch> VehicleRentalBranches { get; set; }

    }
}
