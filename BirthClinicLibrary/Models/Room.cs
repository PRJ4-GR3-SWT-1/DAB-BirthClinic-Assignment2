using System.Collections.Generic;
using System.Text;

namespace BirthClinicLibrary.Models
{
   public class Room
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

    }

   public class MaternityRoom : Room
   {
       
    }
   public class RestingRoom : Room
   {
       

    }
   public class BirthRoom : Room
   {

   }
}
