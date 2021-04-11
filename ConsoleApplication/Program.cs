using System;
using System.Collections.Generic;
using System.Linq;
using BirthClinicLibrary.Models;
using EFModels.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var child1 = new Child();
            child1.Mother = new Mother();
            child1.Birth = new Birth();
            child1.FullName = "Ib Babysen";
            child1.Birth.Clinicians = new BirthRoom();
            child1.Birth.BirthRoomReservationStart = DateTime.Now;
            child1.Birth.BirthRoomReservationEnd = DateTime.Now + new TimeSpan(1, 0, 0);

            child1.Birth.Clinicians.Add(new Doctor());
            child1.Mother.MaternityRoom = new MaternityRoom();
            child1.Mother.MaternityRoomReservationStart = new DateTime(1999, 12, 12, 23, 20, 0);



            using (var context = new BirthDbContext())
            {
                context.Child.Add(child1);
                context.SaveChanges();

                //Show planned births for the comingthreedays
                List<Birth> plannedBirths =
                    context.Birth.Where(b => b.BirthRoomReservationStart < (DateTime.Now+new TimeSpan(3,0,0,0))).ToList();
                Console.WriteLine("Planned births next 3 days:");
                foreach (var birth in plannedBirths)
                {
                    Console.WriteLine(birth.BirthId);
                }

                // Show clinicians, birth room and available at the clinic for the next five days
                List<BirthRoom> availableBirthRooms =
                    context.BirthRoom
                        .ToList();
                List<Clinician> availableClinicians =
                    context.Clinicians
                        .ToList();
                foreach (var clinician in availableClinicians)
                {
                    Console.WriteLine(clinician.FullName + clinician.PersonId);
                }
            }




        }



        public void addRooms(ModelBuilder mb)
        {
            mb.Entity<Room>().HasData(
                new MaternityRoom() {RoomName = "M1"});


        }


    }
}
