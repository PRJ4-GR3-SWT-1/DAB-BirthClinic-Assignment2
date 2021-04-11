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
            Console.WriteLine("Welcome to the BirthClinic Database access system :D");

            //var child1 = new Child();
            //child1.Mother = new Mother();
            //child1.Birth = new Birth();
            //child1.FullName = "Ib Babysen";
            //child1.Birth.Clinicians = new BirthRoom();
            //child1.Birth.BirthRoomReservationStart = DateTime.Now;
            //child1.Birth.BirthRoomReservationEnd = DateTime.Now + new TimeSpan(1, 0, 0);

            //child1.Birth.Clinicians.Add(new Doctor());
            //child1.Mother.MaternityRoom = new MaternityRoom();
            //child1.Mother.MaternityRoomReservationStart = new DateTime(1999, 12, 12, 23, 20, 0);



            using (var context = new BirthDbContext())
            {
                //context.Child.Add(child1);
                //context.SaveChanges();

              //  ShowPlannedBirths(context);

              //  ShowAvailableRoomsAndClinicians(context);

//                ShowOngoingBirths(context);
            }

            

        }

        //Show the at current time ongoing births with information about the birth, parents, clinicians associated and the birth room.
        private static void ShowOngoingBirths(BirthDbContext context)
        {
            List<Reservation> reservations =
                context.Reservation
                    .Where(reservation => reservation.ReservedRoom is BirthRoom)
                    .Where(r=>r.ReservationStart<DateTime.Now
                    && r.ReservationEnd>DateTime.Now)
                    .Include(r => r.ReservedRoom)
                    .Include(r=>r.User)
                    .ToList();

            foreach (Reservation res in reservations)
            {
               // res.User.Children[0].Birth.Clinicians
            }

            /*
            List<Birth> births =
                context.Birth
                    .Where(b => b.PlannedStartTime < DateTime.Now)
                    .ToList();

                births[0].*/
        }

        private static void ShowAvailableRoomsAndClinicians(BirthDbContext context)
        {
            // Show clinicians, birth room and available at the clinic for the next five days
            List<Room> rooms =
                context.Room
                    .Include(r => r.Reservations)
                    //.Where(r=>r.Reservations.ReservationStart>DateTime.Now+TimeSpan.FromDays(5))
                    //.Where(r=>r.ReservedRoom.GetType()==typeof(BirthRoom))
                    .ToList();
            //Remove reserved rooms:
            foreach (var room in rooms)
            {
                foreach (var reservation in room.Reservations)
                {
                    if (reservation.ReservationStart > DateTime.Now + TimeSpan.FromDays(5)) ; //Rummet skal først bruges om lang tid;
                    else if (reservation.ReservationEnd < DateTime.Now) ;//Reservationen er i fortid
                    else//Remove room from list
                    {
                        rooms.Remove(room);
                        break;
                    }
                }
            }
            //Print available rooms:
            Console.WriteLine("These Rooms are not used the next five days:");
            foreach (var room in rooms)
            {
                Console.WriteLine(room.RoomId + ": " + room.GetType().Name + " " + room.RoomName);
            }
            List<Clinician> availableClinicians =
                context.Clinicians//Det her virker måske - hiv dem evt ud enkeltvist
                    .Include(c=>c.AssociatedBirths)
                    .ThenInclude(x=>x.Birth)
                    .ToList();
            

            //Remove booked clinicians:
            foreach (var clinician in availableClinicians)
            {
                foreach (var birth in clinician.AssociatedBirths)
                {
                    if (birth.Birth.PlannedStartTime < DateTime.Now + TimeSpan.FromDays(5)
                        && birth.Birth.PlannedStartTime > DateTime.Now)
                    {//If booked for at birth the next 5 days
                        availableClinicians.Remove(clinician);
                        break;
                    }
                }
            }
            //Print clinicians
            Console.WriteLine("These Clinicians are not booked to any births the next 5 days:");
            foreach (var clinician in availableClinicians)
            {
                Console.WriteLine( clinician.PersonId+" " + clinician.FullName + ": " +clinician.GetType().Name);
            }
        }

        private static void ShowPlannedBirths(BirthDbContext context)
        {
            //Show planned births for the coming three days
            List<Birth> plannedBirths =
                context.Birth
                    .Where(b => b.PlannedStartTime < (DateTime.Now/*+new TimeSpan(3,0,0,0)*/))
                    .ToList();
            Console.WriteLine("Planned births next 3 days:");
            foreach (var birth in plannedBirths)
            {
                Console.WriteLine(birth.BirthId);
            }
        }

        //4.Show the maternity rooms and the four hours rest rooms in use withthe mother/parentsandchild/children using the room.
        //5.Givena birth can planneda)Show therooms reserved the birthb)Show the clinicians assigned the birth
    }
}
