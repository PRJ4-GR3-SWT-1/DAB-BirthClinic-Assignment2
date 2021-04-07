using System;
using System.Collections.Generic;
using System.Text;

namespace BirthClinicLibrary.Models
{
   public class Room
    {
        public int RoomId { get; set; }
        public ICollection<Person> AssociatedPersons { get; set; }
        public ICollection<Birth> Reservations { get; set; }
    }

   public class MaternityRoom : Room
   {

   }
   public class RestingRoom : Room
   {
        
   }
}
