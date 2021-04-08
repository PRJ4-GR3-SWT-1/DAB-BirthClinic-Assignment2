using System;
using System.Collections.Generic;
using System.Text;

namespace BirthClinicLibrary.Models
{
   public class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        
    }

   public class MaternityRoom : Room
   {
       public ICollection<Mother> MotherReservations { get; set; }
    }
   public class RestingRoom : Room
   {
       public ICollection<Mother> MotherReservations { get; set; }

    }
   public class BirthRoom : Room
   {
       public ICollection<Birth> BirthReservations { get; set; }

   }
}
