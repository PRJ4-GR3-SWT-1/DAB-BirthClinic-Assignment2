using System.Collections.Generic;

namespace BirthClinicLibrary.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public ICollection<Room> AssociatedRooms { get; set; }
    }
}