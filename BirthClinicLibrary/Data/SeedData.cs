using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BirthClinicLibrary.Models;
using EFModels.Data;
using Microsoft.EntityFrameworkCore;

namespace BirthClinicLibrary.Data
{
    public class SeedData
    {
        public SeedData(BirthDbContext db)
        {
            SeedRooms(db);
            SeedStaff(db);
        }

        public static void SeedRooms(BirthDbContext db)
        {
            var r = db.Room.FirstOrDefault();
            if (r == null)
            {
                SeedMaternityRooms(db);
                SeedBirthRooms(db);
                SeedRestingRooms(db);
            }

        }

        private static void SeedRestingRooms(BirthDbContext db)
        {
            Room r1 = new RestingRoom("R1");
            Room r2 = new RestingRoom("R2");
            Room r3 = new RestingRoom("R3");
            Room r4 = new RestingRoom("R4");
            Room r5 = new RestingRoom("R5");

            db.Add(r1);
            db.Add(r2);
            db.Add(r3);
            db.Add(r4);
            db.Add(r5);
            db.SaveChanges();
            Console.WriteLine("Resting rooms added.");

        }

        private static void SeedBirthRooms(BirthDbContext db)
        {
            Room b1 = new BirthRoom("B1");
            Room b2 = new BirthRoom("B2");
            Room b3 = new BirthRoom("B3");
            Room b4 = new BirthRoom("B4");
            Room b5 = new BirthRoom("B5");
            Room b6 = new BirthRoom("B6");
            Room b7 = new BirthRoom("B7");
            Room b8 = new BirthRoom("B8");
            Room b9 = new BirthRoom("B9");
            Room b10 = new BirthRoom("B10");
            Room b11 = new BirthRoom("B11");
            Room b12 = new BirthRoom("B12");
            Room b13 = new BirthRoom("B13");
            Room b14 = new BirthRoom("B14");
            Room b15 = new BirthRoom("B15");

            db.Add(b1);
            db.Add(b2);
            db.Add(b3);
            db.Add(b4);
            db.Add(b5);
            db.Add(b6);
            db.Add(b7);
            db.Add(b8);
            db.Add(b9);
            db.Add(b10);
            db.Add(b11);
            db.Add(b12);
            db.Add(b13);
            db.Add(b14);
            db.Add(b15);

            db.SaveChanges();
            Console.WriteLine("Birth Rooms Added");

        }

        private static void SeedMaternityRooms(BirthDbContext db)
        {
            Room m1 = new MaternityRoom("M1");
            Room m2 = new MaternityRoom("M2");
            Room m3 = new MaternityRoom("M3");
            Room m4 = new MaternityRoom("M4");
            Room m5 = new MaternityRoom("M5");
            Room m6 = new MaternityRoom("M6");
            Room m7 = new MaternityRoom("M7");
            Room m8 = new MaternityRoom("M8");
            Room m9 = new MaternityRoom("M9");
            Room m10 = new MaternityRoom("M10");
            Room m11 = new MaternityRoom("M11");
            Room m12 = new MaternityRoom("M12");
            Room m13 = new MaternityRoom("M13");
            Room m14 = new MaternityRoom("M14");
            Room m15 = new MaternityRoom("M15");
            Room m16 = new MaternityRoom("M16");
            Room m17 = new MaternityRoom("M17");
            Room m18 = new MaternityRoom("M18");
            Room m19 = new MaternityRoom("M19");
            Room m20 = new MaternityRoom("M20");
            Room m21 = new MaternityRoom("M21");
            Room m22 = new MaternityRoom("M22");

            db.Add(m1);
            db.Add(m2);
            db.Add(m3);
            db.Add(m4);
            db.Add(m5);
            db.Add(m6);
            db.Add(m7);
            db.Add(m8);
            db.Add(m9);
            db.Add(m10);
            db.Add(m11);
            db.Add(m12);
            db.Add(m13);
            db.Add(m14);
            db.Add(m15);
            db.Add(m16);
            db.Add(m17);
            db.Add(m18);
            db.Add(m19);
            db.Add(m20);
            db.Add(m21);
            db.Add(m22);
            db.SaveChanges();
            Console.WriteLine("MaternityRooms Added");
        }


        public static void SeedStaff(BirthDbContext db)
        {
            var c = db.Clinicians.FirstOrDefault();
            if (c == null)
            {
                SeedDoctors(db);
                SeedNurses(db);
                SeedMidwives(db);
                SeedSHAssistans(db);
            }

            var s = db.Secretary.FirstOrDefault();
            if (s == null)
            {
                SeesSecretary(db);
            }
        }

        private static void SeedDoctors(BirthDbContext db)
        {
            Person D1 = new Doctor("Dorthe");
            Person D2 = new Doctor("Dennis");
            Person D3 = new Doctor("Dina");
            Person D4 = new Doctor("Daniel"); 
            Person D5 = new Doctor("Daniella");

            db.Add(D1);
            db.Add(D2);
            db.Add(D3);
            db.Add(D4);
            db.Add(D5);

            db.SaveChanges();
            Console.WriteLine("Doctors added.");
        }

        private static void SeedNurses(BirthDbContext db)
        {
            Person N1 = new Nurse("Nete");
            Person N2 = new Nurse("Nathan");
            Person N3 = new Nurse("Natalie");
            Person N4 = new Nurse("Noel");
            Person N5 = new Nurse("Nadja");
            Person N6 = new Nurse("Nessa");
            Person N7 = new Nurse("Naja");
            Person N8 = new Nurse("Nikoline");
            Person N9 = new Nurse("Nik");
            Person N10 = new Nurse("Nikolaj");
            Person N11 = new Nurse("Niklas");
            Person N12 = new Nurse("Nor");
            Person N13 = new Nurse("Nazarat");
            Person N14 = new Nurse("Neo");
            Person N15 = new Nurse("Nasir");
            Person N16 = new Nurse("Niller");
            Person N17 = new Nurse("Niko");
            Person N18 = new Nurse("Niels");
            Person N19 = new Nurse("Niels-Erik");
            Person N20 = new Nurse("Niels-Ove");


            db.Add(N1);
            db.Add(N2);
            db.Add(N3);
            db.Add(N4);
            db.Add(N5);
            db.Add(N6);
            db.Add(N7);
            db.Add(N8);
            db.Add(N9);
            db.Add(N10);
            db.Add(N11);
            db.Add(N12);
            db.Add(N13);
            db.Add(N14);
            db.Add(N15);
            db.Add(N16);
            db.Add(N17);
            db.Add(N18);
            db.Add(N19);
            db.Add(N20);

            db.SaveChanges();
            Console.WriteLine("Nurses added.");
        }

        private static void SeedMidwives(BirthDbContext db)
        {
            Person M1 = new MidWife("Mary");
            Person M2 = new MidWife("Malfred");
            Person M3 = new MidWife("Marius");
            Person M4 = new MidWife("Marianne");
            Person M5 = new MidWife("Morten");
            Person M6 = new MidWife("Marie");
            Person M7 = new MidWife("Molly");
            Person M8 = new MidWife("Mingming");
            Person M9 = new MidWife("Mulle");
            Person M10 = new MidWife("Mads");

            db.Add(M1);
            db.Add(M2);
            db.Add(M3);
            db.Add(M4);
            db.Add(M5);
            db.Add(M6);
            db.Add(M7);
            db.Add(M8);
            db.Add(M9);
            db.Add(M10);

            db.SaveChanges();
            Console.WriteLine("Midwives added.");
        }

        private static void SeedSHAssistans(BirthDbContext db)
        {
            Person SHA1 = new SocialHealthAssistant("Harry");
            Person SHA2 = new SocialHealthAssistant("Harper");
            Person SHA3 = new SocialHealthAssistant("Hans");
            Person SHA4 = new SocialHealthAssistant("Hope");
            Person SHA5 = new SocialHealthAssistant("Harriet");
            Person SHA6 = new SocialHealthAssistant("Hal");
            Person SHA7 = new SocialHealthAssistant("Hamlet");
            Person SHA8 = new SocialHealthAssistant("Hubert");
            Person SHA9 = new SocialHealthAssistant("Holger");
            Person SHA10 = new SocialHealthAssistant("Holmer");
            Person SHA11 = new SocialHealthAssistant("Hansi");
            Person SHA12 = new SocialHealthAssistant("Hylle");
            Person SHA13 = new SocialHealthAssistant("Henrik");
            Person SHA14 = new SocialHealthAssistant("Hermione");
            Person SHA15 = new SocialHealthAssistant("Heidi");
            Person SHA16 = new SocialHealthAssistant("Helene");
            Person SHA17 = new SocialHealthAssistant("Helena");
            Person SHA18 = new SocialHealthAssistant("Hailey");
            Person SHA19 = new SocialHealthAssistant("Henriette");
            Person SHA20 = new SocialHealthAssistant("Hanne");

            db.Add(SHA1);
            db.Add(SHA2);
            db.Add(SHA3);
            db.Add(SHA4);
            db.Add(SHA5);
            db.Add(SHA6);
            db.Add(SHA7);
            db.Add(SHA8);
            db.Add(SHA9);
            db.Add(SHA10);
            db.Add(SHA11);
            db.Add(SHA12);
            db.Add(SHA13);
            db.Add(SHA14);
            db.Add(SHA15);
            db.Add(SHA16);
            db.Add(SHA17);
            db.Add(SHA18);
            db.Add(SHA19);
            db.Add(SHA20);

            db.SaveChanges();
            Console.WriteLine("Social and Health Assistans added.");



        }

        private static void SeesSecretary(BirthDbContext db)
        {
            Person s1 = new Secretary("Susan");
            Person s2 = new Secretary("Simon");
            Person s3 = new Secretary("Sam");
            Person s4 = new Secretary("Susanne");

            db.Add(s1);
            db.Add(s2);
            db.Add(s3);
            db.Add(s4);

            db.SaveChanges();
            Console.WriteLine("Secretaries added.");
        }
    }
}

