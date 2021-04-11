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

            }
        }
    }
}

