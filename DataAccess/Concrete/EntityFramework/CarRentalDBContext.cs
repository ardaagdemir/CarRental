using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Core.Entities.Concrete;
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
            optionsBuilder.UseSqlServer(@"Server =DESKTOP-6OSPN7J\SQLEXPRESS; Database =CarRentalDB;Trusted_Connection=true");
        }

        //Db ile Projede birbirine bağlanacak nesneler
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        

    }

}
