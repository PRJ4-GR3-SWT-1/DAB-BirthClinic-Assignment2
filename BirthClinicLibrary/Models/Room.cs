using System.Collections.Generic;
using System.Text;

namespace BirthClinicLibrary.Models
{
   public class Room
    {
        public Room(string name)
        {
            RoomName = name;
        }

        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

    }

   public class MaternityRoom : Room
   {
       public MaternityRoom(string name) : base(name)
       {

       }
   }
   public class RestingRoom : Room
   {
       public RestingRoom(string name) : base(name)
       {

       }

   }
   public class BirthRoom : Room
   {
       public BirthRoom(string name) : base(name)
       {

       }
   }
}
