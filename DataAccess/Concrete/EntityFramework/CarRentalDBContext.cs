using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //Context
    public class CarRentalDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //DB Connection
            optionsBuilder.UseSqlServer(@"Server=(localdb)\DESKTOP-6OSPN7J;Databases=CarRentalDB;Trusted_Connection=true");
        }

        //Db ile Projede birbirine bağlanacak nesneler
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<BrandModel> BrandModels { get; set; }
    }
}
