using System;
using System.Collections.Generic;
using System.Linq;
using BirthClinicLibrary.Models;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Extensions;


namespace EFModels.Data
{
    public class BirthDbContext : DbContext
    {
        //public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\DABServer;Initial Catalog=BirthClinic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateData(modelBuilder);
        }

        private void CreateData(ModelBuilder mb)
        {
            // Births
            /*mb.Entity<Birth>().HasData(new Birth()
            {
              //  BirthRoom = null,
              //  BirthRoomReservationStart = new DateTime(2021, 5, 12, 11, 0, 0),
             //   BirthRoomReservationEnd = new DateTime(2021, 5, 12, 16, 0, 0),

            });*/

            // Children
           // mb.Entity<Child>().HasData(new Child() {ActualBirthTime = new DateTime()});
        }

        public DbSet<Room> Room { get; set; }
        public DbSet<MaternityRoom> MaternityRoom { get; set; }
        public DbSet<RestingRoom> RestingRoom { get; set; }
        public DbSet<BirthRoom> BirthRoom { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Child> Child { get; set; }
        public DbSet<Mother> Mother { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Clinician> Clinicians { get; set; }
        public DbSet<Birth> Birth { get; set; }


    }
}