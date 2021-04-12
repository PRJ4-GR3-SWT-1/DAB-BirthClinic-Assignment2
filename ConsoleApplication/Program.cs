using System;
using System.Collections.Generic;
using System.Linq;
using BirthClinicLibrary.Data;
using BirthClinicLibrary.Models;
using EFModels.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
                SeedData sd = new SeedData(context);

                // Til når brugeren skal vælge doctor og midwife.
                List<Doctor> doctors = context.Doctor.ToList();
                List<MidWife> midWives = context.MidWife.ToList();

                Console.WriteLine("Velkommen til reservation af fødsel");
                Console.WriteLine("-----------------------------------");

                Console.WriteLine("Hvad er navnet på barnet");
                string childName = Console.ReadLine();

                Console.WriteLine("Hvad er navnet på moderen til barnet");
                string motherName = Console.ReadLine();

                Console.WriteLine("Hvad er navnet på faderen til barnet");
                string fatherName = Console.ReadLine();

                Console.WriteLine("Hvilken dato vil du have reservationen til. Skriv på formen DD/MM/ÅÅÅÅ");
                string dato = Console.ReadLine();
                string[] datoOpsplittet = dato.Split("/");
                int dag = int.Parse(datoOpsplittet[0]);
                int måned = int.Parse(datoOpsplittet[1]);
                int år = int.Parse(datoOpsplittet[2]);

                Console.WriteLine("Hvilken tid vil du have reservationen. Skriv på formen TT.MM");
                string tid = Console.ReadLine();
                string[] tidOpsplittet = tid.Split(".");
                int time = int.Parse(tidOpsplittet[0]);
                int minut = int.Parse(tidOpsplittet[1]);

                Console.WriteLine("Hvilken jordmor vil du gerne have? Indtast tallet ud fra personen");
                int counter = 0;
                foreach (MidWife mW in midWives)
                {
                    Console.WriteLine(counter + ". " + mW.FullName);
                    counter++;
                }

                int valgtMidwife = int.Parse(Console.ReadLine());

                Console.WriteLine("Hvilken doktor vil du gerne have? Indtast tallet ud fra personen");
                counter = 0;
                foreach (Doctor dc in doctors)
                {
                    Console.WriteLine(counter + ". " + dc.FullName);
                    counter++;
                }

                int valgtDoctor = int.Parse(Console.ReadLine());

                Console.WriteLine("Du skal også have et fødselsrum reserveret, Vi finder ledige rum for dagen. \n Indtast tallet ud fra rummet");
                ShowAvailableRooms(context, new DateTime(år, måned, dag, time, minut, 00), new BirthRoom(""));
                int valgtRumId = int.Parse(Console.ReadLine());

                Room chosenRoom = context.Room.SingleOrDefault(r=>r.RoomId==valgtRumId);


                Console.WriteLine("Tak for dit info, vores super database vil nu oprette reservationen for dig");


                Child child1 = new Child(childName);
                Birth birth1 = new Birth();
                Mother mother1 = new Mother(motherName);
                FamilyMember father1 = new FamilyMember(fatherName, "Father");
                context.Add(child1);

                context.SaveChanges();
                birth1.Child = child1;
                DateTime PST = new DateTime(år, måned, dag, time, minut,00);
                birth1.PlannedStartTime = PST;
                child1.Birth = birth1;
                child1.Mother = mother1;
                child1.FamilyMembers = new List<FamilyMember>();
                child1.FamilyMembers.Add(father1);
                mother1.Children = new List<Child>();
                mother1.Children.Add(child1);

                //
                  ClinicianBirth CB1 = new ClinicianBirth();
                  CB1.Birth = birth1;
                  CB1.Clinician = doctors[valgtDoctor];
                  ClinicianBirth CB2 = new ClinicianBirth();
                  CB2.Birth = birth1;
                  CB2.Clinician = midWives[valgtMidwife]; 
                   doctors[valgtDoctor].AssociatedBirths = new List<ClinicianBirth>();
                   doctors[valgtDoctor].AssociatedBirths.Add(CB1);
                   midWives[valgtMidwife].AssociatedBirths = new List<ClinicianBirth>();
                   midWives[valgtMidwife].AssociatedBirths.Add(CB2); 
                //
                   birth1.Clinicians = new List<ClinicianBirth>();
                   birth1.Clinicians.Add(CB1);
                   birth1.Clinicians.Add(CB2);
                   //



                   Reservation res1 = new Reservation();
              /*     Reservation res2 = new Reservation();
                   Reservation res3 = new Reservation();
                   List <BirthRoom> BRoom = context.BirthRoom.ToList();
                   List<MaternityRoom> MRoom = context.MaternityRoom.ToList();
                   List<RestingRoom> RRoom = context.RestingRoom.ToList();*/
              res1.ReservationStart = new DateTime(år, måned, dag, time, minut, 00);
              res1.ReservationEnd = res1.ReservationStart + TimeSpan.FromHours(5);
                   res1.User = mother1;
                   res1.ReservedRoom = chosenRoom;
                   mother1.Reservations = new List<Reservation>();
                   chosenRoom.Reservations = new List<Reservation>();
                   mother1.Reservations.Add(res1);
                   chosenRoom.Reservations.Add(res1);

                /*  res2.User = mother1;
                  res2.ReservedRoom = MRoom[0];
                  MRoom[0].Reservations = new List<Reservation>();
                  mother1.Reservations.Add(res2);
                  MRoom[0].Reservations.Add(res2);

                  res3.User = mother1;
                  res3.ReservedRoom = RRoom[0];
                  RRoom[0].Reservations = new List<Reservation>();
                  mother1.Reservations.Add(res3);
                  RRoom[0].Reservations.Add(res3); */


                context.SaveChanges(); 

                //   ShowPlannedBirths(context);

                // ShowAvailableRoomsAndClinicians(context);

                //                ShowOngoingBirths(context);
                bool running = true;
                while (running) { 
                    Console.WriteLine("Muligheder: ");
                    Console.WriteLine("1: Vis planlagte fødsler: ");
                    Console.WriteLine("2: Ledige rum og klinikarbejdere ");
                    Console.WriteLine("3: Aktuelt pågående fødsler ");
                    Console.WriteLine("x: Luk ");
                    var key=Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            ShowPlannedBirths(context);
                            break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2:
                            ShowAvailableRoomsAndClinicians(context);
                            break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3:
                            ShowOngoingBirths(context);
                            break;
                        case ConsoleKey.X:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Ugyldigt valg");
                            break;
                    }
                }
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
            //print available rooms:
            Console.WriteLine("Ledige Rum:");

            foreach (var room in rooms)
            {
                bool booked = false;
                foreach (var reservation in room.Reservations)
                {
                    
                    if (reservation.ReservationStart < DateTime.Now + TimeSpan.FromDays(5) //Reservation starter inden for 5 dage
                   && reservation.ReservationEnd > DateTime.Now) ;//...og slutter en gang i fremtiden
                    //Remove room from list
                    {
                        booked = true;
                        break;
                    }
                }
                if(!booked) Console.WriteLine(room.RoomId + ": " + room.GetType().Name + " " + room.RoomName);
            }
            
            List<Clinician> clinicians =
                context.Clinicians//Det her virker måske - hiv dem evt ud enkeltvist
                    .Include(c=>c.AssociatedBirths)
                    .ThenInclude(x=>x.Birth)
                    .ToList();


            //Print available clinicians:
            Console.WriteLine("\nLedige Klinikarbejdere:");

            foreach (var clinician in clinicians)
            {
                bool booked = false;
                foreach (var birth in clinician.AssociatedBirths)
                {
                    if (birth.Birth.PlannedStartTime < DateTime.Now + TimeSpan.FromDays(5)
                        && birth.Birth.PlannedStartTime > DateTime.Now)
                    {//If booked for at birth the next 5 days
                        booked = true;
                        break;
                    }
                }
                if(!booked) Console.WriteLine(clinician.PersonId + " " + clinician.FullName + ": " + clinician.GetType().Name);

            }
           
        }

        private static void ShowPlannedBirths(BirthDbContext context)
        {
            //Show planned births for the coming three days
            List<Birth> plannedBirths =
                context.Birth
                    .Where(b => b.PlannedStartTime < (DateTime.Now+new TimeSpan(3,0,0,0)) && (b.PlannedStartTime > (DateTime.Now)))
                    .Include(b=>b.Child)
                    .Include(b=>b.Clinicians)
                    .ThenInclude(cb=>cb.Clinician)
                    .ToList();
            Console.WriteLine("Planned births next 3 days:");
            foreach (var birth in plannedBirths)
            {
                Console.WriteLine("BirthID: " +birth.BirthId+"Planned starttime: "+ birth.PlannedStartTime+ "Name: "+ birth.Child.FullName);
                Console.WriteLine(" Associated Clinicians:");
                foreach (var cb in birth.Clinicians)
                {
                    Console.WriteLine("   " + cb.Clinician.FullName + " " + cb.Clinician.GetType().Name);
                }
            }
        }

        //4.Show the maternity rooms and the four hours rest rooms in use withthe mother/parentsandchild/children using the room.
        //5.Givena birth can planneda)Show therooms reserved the birthb)Show the clinicians assigned the birth

        // Ekstra. Vis alle rum
        private static void ShowAvailableRooms(BirthDbContext context, DateTime startTime, Room RoomType)
        {
            
            // Show clinicians, birth room and available at the clinic for the next five days
            List<Room> rooms =
                context.Room
                    .Include(r => r.Reservations)
                    //.Where(r=>r.Reservations.ReservationStart>DateTime.Now+TimeSpan.FromDays(5))
                    .Where(r => r is BirthRoom )
                    .ToList();
            //print available rooms:
            Console.WriteLine("Ledige Rum:");

            foreach (var room in rooms)
            {
                bool booked = false;
                foreach (var reservation in room.Reservations)
                {

                    if (reservation.ReservationStart < startTime+TimeSpan.FromHours(5) && reservation.ReservationEnd > startTime) 
                    //Remove room from list
                    {
                        booked = true;
                        break;
                    }
                }
                if (!booked) Console.WriteLine(room.RoomId + ": " + room.GetType().Name + " " + room.RoomName);
            }
        }
    }


    
}
