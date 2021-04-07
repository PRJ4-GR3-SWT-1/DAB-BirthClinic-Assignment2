using System;
using System.Collections.Generic;
using System.Text;

namespace BirthClinicLibrary.Models
{
   public class Room
    {
        public int RoomId { get; set; }
        public string Type { get; set; }
        public ICollection<Person> AssociatedPersons { get; set; }
    }
}
