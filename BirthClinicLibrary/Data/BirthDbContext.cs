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

        }

        public DbSet<Room> Rooms { get; set; }


    }
}