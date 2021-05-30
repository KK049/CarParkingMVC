using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarParkingMVC.Models;

namespace CarParkingMVC.Data
{
    public class CarParkingMVCContext : DbContext
    {
        public CarParkingMVCContext (DbContextOptions<CarParkingMVCContext> options)
            : base(options)
        {
        }

        public DbSet<CarParkingMVC.Models.Car> Car { get; set; }

        public DbSet<CarParkingMVC.Models.Customer> Customer { get; set; }

        public DbSet<CarParkingMVC.Models.BookingCars> BookingCars { get; set; }

        public DbSet<CarParkingMVC.Models.Query> Query { get; set; }

        public DbSet<CarParkingMVC.Models.Register> Register { get; set; }
    }
}
