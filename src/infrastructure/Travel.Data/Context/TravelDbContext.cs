using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.Entities;

namespace Travel.Data.Context
{
    public class TravelDbContext : DbContext
    {

        public TravelDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite(@"Data Source=TravelTourDatabase.db");
        }

        public TravelDbContext(DbContextOptions<TravelDbContext> options) : base(options)
        {

        }


        public DbSet<TourList> TourLists { get; set; }
        public DbSet<TourPackage> TourPackages { get; set; }


    }
}
