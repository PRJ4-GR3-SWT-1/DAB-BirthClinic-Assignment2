using System;
using System.Collections.Generic;
using System.Linq;
using BirthClinicLibrary.Models;
using EFModels.Data;

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
            child1.Birth.BirthRoom = new BirthRoom();
            child1.Birth.BirthRoomReservationStart = DateTime.Now;
            child1.Birth.BirthRoomReservationEnd =  DateTime.Now+new TimeSpan(1,0,0);
            //child1.Birth.Child = child1;
            child1.Birth.Clinicians.Add(new Doctor());
            child1.Mother.MaternityRoom = new MaternityRoom();
            child1.Mother.MaternityRoomReservationStart = new DateTime(1999, 12, 12, 23, 20, 0);
            //child1.Mother.Child = child1;


            using (var context = new BirthDbContext())
            {
                //context.Child.Add(child1);
                //context.SaveChanges();

                //Show planned births for the comingthreedays
                List<Birth> plannedBirths =
                    context.Birth.Where(b => b.BirthRoomReservationStart < (DateTime.Now+new TimeSpan(3,0,0,0))).ToList();
                Console.WriteLine("Planned births next 3 days:");
                foreach (var birth in plannedBirths)
                {
                    Console.WriteLine(birth.BirthId);
                }

               // Show clinicians, birth room and availableat the clinic for the next fiveday
            }

            

        }
    }
}
