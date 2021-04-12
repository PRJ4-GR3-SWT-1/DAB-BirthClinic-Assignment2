using BirthClinicLibrary.Models;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Diagnostics;


namespace EFModels.Data
{
    public class BirthDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Write SQL code to terminal:
            //optionsBuilder.LogTo(Console.WriteLine, new[] {RelationalEventId.CommandExecuted})
            //    .EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\DABServer;Initial Catalog=BirthClinic;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }

        

        //Rooms:
        public DbSet<Room> Room { get; set; }
        public DbSet<MaternityRoom> MaternityRoom { get; set; }
        public DbSet<RestingRoom> RestingRoom { get; set; }
        public DbSet<BirthRoom> BirthRoom { get; set; }
        //Persons:
        public DbSet<Person> Person { get; set; }
        public DbSet<Child> Child { get; set; }
        public DbSet<Mother> Mother { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Nurse> Nurse { get; set; }
        public DbSet<Clinician> Clinicians { get; set; }
        public DbSet<MidWife> MidWife { get; set; }
        public DbSet<SocialHealthAssistant> SocialHealthAssistant { get; set; }
        //Birth:
        public DbSet<Birth> Birth { get; set; }
        //Reservation:
        public DbSet<Reservation> Reservation { get; set; }

        public DbSet<Secretary> Secretary { get; set; }


    }
}