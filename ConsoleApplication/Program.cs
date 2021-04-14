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
        private static bool _running = true;
        static void Main(string[] args)
        {
            Console.WriteLine("Velkommen til BirthClinic Database access system :D");

            using (var context = new BirthDbContext())
            {
                context.Database.EnsureCreated();
                Console.WriteLine("Databasen eksisterer, og context er defineret");
                SeedData sd = new SeedData(context);

                
                while (_running) { 
                    Console.WriteLine("Muligheder: ");
                    Console.WriteLine("1: Vis planlagte fødsler: ");
                    Console.WriteLine("2: Ledige rum og klinikarbejdere ");
                    Console.WriteLine("3: Aktuelt igangværende fødsler ");
                    Console.WriteLine("4: Værelser i brug lige nu (ikke fødselsrum)");
                    Console.WriteLine("5: Vis reserverede rum og associeret personale til specifik fødsel");
                    Console.WriteLine("F: Færdiggør reservation af rum ");
                    Console.WriteLine("B: Lav en reservation til en fødsel");
                    Console.WriteLine("A: Annuller reservation af rum ");
                    Console.WriteLine("x: Luk ");
                    var key=Console.ReadKey();
                    HandleKey(key,context);
                }
            }
        }

        private static void HandleKey(ConsoleKeyInfo key, BirthDbContext context)
        {
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
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    ShowMaternityRoomsAndRestingRoomsInUse(context);
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    ShowRoomsAndClinicianReservedForBirth(context);
                    break;
                case ConsoleKey.X:
                    _running = false;
                    break;
                case ConsoleKey.F:
                    FinnishRoomReservation(context);
                    break;
                case ConsoleKey.B:
                    AddBirth(context);
                    break;
                case ConsoleKey.A:
                    CancelRoomReservation(context);
                    break;
                default:
                    Console.WriteLine("Ugyldigt valg");
                    break;
            }
        }

        private static void CancelRoomReservation(BirthDbContext context)
        {
            int id = inputID();
            var res = context.Reservation.Single(r => r.ReservationId == id);
            if (res != null)
            {
                Console.WriteLine("Reservation fundet. Fjernes nu");
                context.Remove<Reservation>(res);
                context.SaveChanges();
            }
            else Console.WriteLine("Kunne ikke finde reservation. Intet er fjernet.");
            
        }

        private static void FinnishRoomReservation(BirthDbContext context)
        {
            
            int id = inputID();
            

            Reservation res = context.Reservation
                .SingleOrDefault(r => r.ReservationId == id);
            if (res != null)
            {
                res.ReservationEnd = DateTime.Now;
                context.SaveChanges();
                Console.WriteLine("Succes. Reservationen er nu markeret som 'færdig'!");
            }
            else
            {
                Console.WriteLine("Reservation ikke fundet.");
                FinnishRoomReservation(context);
            }
        }

        private static int inputID()
        {
            bool isNumber = false;
            int id =0;
            while (!isNumber)
            {
                Console.WriteLine("Skriv reservation ID (x for at afslutte)");
                var input = Console.ReadLine();
                if (input == "x") return 0;
                isNumber = int.TryParse(input, out id);
            }
            return id;
        }

        //Show the at current time ongoing births with information about the birth, parents, clinicians associated and the birth room.
        private static void ShowOngoingBirths(BirthDbContext context)
        {
            List<Reservation> reservations =
                context.Reservation
                    .Where(reservation => reservation.ReservedRoom is BirthRoom)
                    .Where(r=>r.ReservationStart<DateTime.Now)
                    .Where(r=>r.ReservationEnd>DateTime.Now)//Assuming current reservations of birthrooms is current births
                    .Include(r => r.ReservedRoom)
                    .Include(r=>r.User)
                    .ThenInclude(u=>u.Children)
                    .ThenInclude(c=>c.FamilyMembers)
                    .ToList();
            Console.WriteLine("Nuværende føderum i brug:");
            foreach (Reservation res in reservations)
            {
                Console.WriteLine(res.ReservedRoom.RoomName);
                foreach (var child in res.User.Children)
                {
                    Console.WriteLine("Barnets navn: "+ child.FullName + " Morens navn: "+child.Mother.FullName + " Familie:");
                    foreach (var member in child.FamilyMembers)
                    {
                        Console.WriteLine("  "+member.Relation+": "+member.FullName);
                    }

                    var birth = context.Birth
                        .Include(b => b.Clinicians)
                        .ThenInclude(c => c.Clinician)
                        .Single(b => b.Child.PersonId == child.PersonId);
                    Console.WriteLine(" Associeret personale til fødselsID "+ birth.BirthId + ":");
                    foreach (var cb in birth.Clinicians)
                    {
                        Console.WriteLine("  "+cb.Clinician.GetType().Name + ": " + cb.Clinician.FullName);
                    }
                }
            }
            Console.WriteLine("\n\n");
        }

        private static void ShowAvailableRoomsAndClinicians(BirthDbContext context)
        {
            // Show clinicians, birth room and available at the clinic for the next five days
            List<Room> rooms =
                context.Room
                    .Include(r => r.Reservations)
                  
                    .ToList();
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
                context.Clinicians
                    .Include(c=>c.AssociatedBirths)
                    .ThenInclude(x=>x.Birth)
                    .ToList();


            //Print available clinicians:
            Console.WriteLine("\n\nLedige Klinikarbejdere:");

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
            Console.WriteLine("\n\n");
        }

        private static void ShowPlannedBirths(BirthDbContext context)
        {
            //Show planned births for the coming three days
            List<Birth> plannedBirths =
                context.Birth
                    .Where(b => b.PlannedStartTime < (DateTime.Now.AddDays(3)))
                    .Where(b=>b.PlannedStartTime > (DateTime.Now))
                    .Include(b=>b.Child)
                    .Include(b=>b.Clinicians)
                    .ThenInclude(cb=>cb.Clinician)
                    .ToList();
            Console.WriteLine(" - Planlagte fødsler de kommende 3 dage:");
            foreach (var birth in plannedBirths)
            {
                Console.WriteLine("Fødsels ID: " +birth.BirthId+"\nPlanlagt starttidspunkt: "
                                  + birth.PlannedStartTime+ "\nNavn: "+ birth.Child.FullName);
                Console.WriteLine("Associeret personale: ");
                foreach (var cb in birth.Clinicians)
                {
                    Console.WriteLine("   " + cb.Clinician.FullName + " (" + cb.Clinician.GetType().Name + ")");
                }
            }
            Console.WriteLine("\n\n");
        }

        //4.Show the maternity rooms and the four hours rest rooms in use with the mother/parents and child/children using the room.
        private static void ShowMaternityRoomsAndRestingRoomsInUse(BirthDbContext context)
        {
            List<Reservation> maternityRoomsAndRestingRooms =
                context.Reservation
                    .Where(r => r.ReservationStart < (DateTime.Now))
                    .Where(r=>r.ReservationEnd > (DateTime.Now))
                    .Where(r=>r.ReservedRoom is MaternityRoom || r.ReservedRoom is RestingRoom)
                    .Include(r => r.ReservedRoom)
                    .Include(r => r.User)
                    .ThenInclude(m => m.Children)
                    .ThenInclude(c => c.FamilyMembers)
                    .ToList();
            foreach (var reservation in maternityRoomsAndRestingRooms)
            {
                Console.WriteLine(" - Rummet: "
                                  + reservation.ReservedRoom.RoomName
                                  + " er reserveret af " + reservation.User.FullName + " med reservationsID: " + reservation.ReservationId
                                  + ".\n Navn på børn: ");
                foreach (var c in reservation.User.Children) 
                {
                    Console.WriteLine(c.FullName + ". ");
                    foreach (var fm in c.FamilyMembers)
                    {
                        Console.WriteLine(". \n Familiemedlem: " + fm.FullName + " Relation: " + fm.Relation);
                    }
                }
            }
            Console.WriteLine("\n\n");
        }


        

        // Ekstra. Vis alle rum
        private static void ShowAvailableRooms(BirthDbContext context, DateTime startTime, string roomType ="birthroom")
        {
            roomType = roomType.ToLower();
            List<Room> rooms = null;

            switch (roomType)
            {
                case "birthroom":
                    rooms = context.Room
                        .Include(r => r.Reservations)
                        .Where(r => r is BirthRoom)
                        .ToList();
                    break;
                case "maternityroom":
                    rooms = context.Room
                        .Include(r => r.Reservations)
                        .Where(r => r is MaternityRoom)
                        .ToList();
                    break;
                case "restingroom":
                    rooms = context.Room
                        .Include(r => r.Reservations)
                        .Where(r => r is RestingRoom)
                        .ToList();
                    break;
            }

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

        public static void AddBirth(BirthDbContext context)
        {
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
            ShowAvailableRooms(context, new DateTime(år, måned, dag, time, minut, 00), "birthroom");
            int valgtRumId = int.Parse(Console.ReadLine());
            Room chosenBirthRoom = context.Room.SingleOrDefault(r => r.RoomId == valgtRumId);

            Console.WriteLine("Vil du også reservere et Maternityroom y/n");
            Room chosenMaternityRoom = null;
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.WriteLine("MaternityRoom reservation \n Indtast tallet ud fra rummet");
                ShowAvailableRooms(context, new DateTime(år, måned, dag, time, minut, 00), "maternityroom");
                valgtRumId = int.Parse(Console.ReadLine());
                chosenMaternityRoom = context.Room.SingleOrDefault(r => r.RoomId == valgtRumId);
            }
            Console.WriteLine("Vil du også reservere et restingroom y/n");
            Room chosenRestingRoom = null;
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.WriteLine("RestingRoom reservation \n Indtast tallet ud fra rummet");
                ShowAvailableRooms(context, new DateTime(år, måned, dag, time, minut, 00), "restingroom");
                valgtRumId = int.Parse(Console.ReadLine());
                chosenRestingRoom = context.Room.SingleOrDefault(r => r.RoomId == valgtRumId);
            }

            Console.WriteLine("Tak for dit info, vores super database vil nu oprette reservationen for dig");

            // Følgende kode opsætter de rigtige referencer m.m. Så dataen kan gemmes på databasen
            // Her oprettes de forskellige klasser
            Child child1 = new Child(childName);
            Birth birth1 = new Birth();
            Mother mother1 = new Mother(motherName);
            FamilyMember father1 = new FamilyMember(fatherName, "Father");
            // Savechanges skal kaldes allerede nu, da child skal laves før birth ellers så kan EF core ikke finde ud af hvilken den skal lave først.
            context.Add(child1);
            context.SaveChanges();

            // Her sættes referencer
            birth1.Child = child1;
            DateTime PST = new DateTime(år, måned, dag, time, minut, 00);
            birth1.PlannedStartTime = PST;
           //child1.Birth = birth1;
            child1.Mother = mother1;
            child1.FamilyMembers = new List<FamilyMember>();
            child1.FamilyMembers.Add(father1);
            mother1.Children = new List<Child>();
            mother1.Children.Add(child1);

            // Her sættes clinicians og deres births
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
            // Her sættes clinicians på selve birth
            birth1.Clinicians = new List<ClinicianBirth>();
            birth1.Clinicians.Add(CB1);
            birth1.Clinicians.Add(CB2);
            //


            // Her sættes reservationerne for alle rum.
            Reservation res1 = new Reservation();
            res1.ReservationStart = new DateTime(år, måned, dag, time, minut, 00);
            res1.ReservationEnd = res1.ReservationStart + TimeSpan.FromHours(5);
            res1.User = mother1;
            res1.ReservedRoom = chosenBirthRoom;
            mother1.Reservations = new List<Reservation>();
            chosenBirthRoom.Reservations = new List<Reservation>();
            mother1.Reservations.Add(res1);
            chosenBirthRoom.Reservations.Add(res1);

            Reservation res2 = new Reservation();
            if (chosenMaternityRoom != null)
            {
                res2.ReservationStart = new DateTime(år, måned, dag, time, minut, 00);
                res2.ReservationEnd = res2.ReservationStart + TimeSpan.FromDays(5);
                res2.User = mother1;
                res2.ReservedRoom = chosenMaternityRoom;
                chosenMaternityRoom.Reservations = new List<Reservation>();
                mother1.Reservations.Add(res2);
                chosenMaternityRoom.Reservations.Add(res2);
            }

            Reservation res3 = new Reservation();
            if (chosenRestingRoom != null)
            {
                res3.ReservationStart = new DateTime(år, måned, dag, time, minut, 00)+TimeSpan.FromHours(5);
                res3.ReservationEnd = res3.ReservationStart + TimeSpan.FromHours(4);
                res3.User = mother1;
                res3.ReservedRoom = chosenRestingRoom;
                chosenRestingRoom.Reservations = new List<Reservation>();
                mother1.Reservations.Add(res3);
                chosenRestingRoom.Reservations.Add(res3);
            }
            // Alt gemmes og reservationen er gemmenført
            context.SaveChanges();

            Console.WriteLine($"Reservation til den {dato}, med personerne {childName}, {motherName} og {fatherName} er gennemført og gemt");
        }
        //5.Given a birth can planned
        //a)Show the rooms reserved the birth
        //b)Show the clinicians assigned the birth
        private static void ShowRoomsAndClinicianReservedForBirth(BirthDbContext context)
        {
            Console.WriteLine(" - Hvilket BirthID søger du efter?");
            var input = Console.ReadLine();
            var inputId = int.Parse(input);
            
            Birth birth =
                context.Birth
                    
                    .Include(b => b.Child)
                    .ThenInclude(c => c.Mother)
                    .ThenInclude(m => m.Reservations)
                    .ThenInclude(r => r.ReservedRoom)
                    .Include(b => b.Clinicians)
                    .ThenInclude(b=>b.Clinician)
                    .SingleOrDefault(b => b.BirthId == inputId);

            Console.WriteLine("Fødsels ID: " + birth.BirthId + " Navn: " + birth.Child.FullName);
            Console.WriteLine(" Associeret personale:");
                foreach (var cb in birth.Clinicians)
                {
                    Console.WriteLine("   " + cb.Clinician.FullName + " " + cb.Clinician.GetType().Name);
                }

            Console.WriteLine(" Reserverede rum: ");
                Child c = birth.Child;
                foreach (var r in c.Mother.Reservations)
                {
                    Console.WriteLine("   "+r.ReservedRoom.RoomName + " med reservationsID: " + r.ReservationId);
                }
                Console.WriteLine("\n\n");
        }
    }


    
}
