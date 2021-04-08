using System;
using BirthClinicLibrary.Models;

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
            child1.FullName = "Flemming Babysen";
            child1.Birth.BirthRoom = new BirthRoom();
            child1.Birth.BirthRoomReservationStart = DateTime.Now;
            child1.Birth.Child = child1;
            child1.Birth.Clinicians.Add(new Doctor());



        }
    }
}
