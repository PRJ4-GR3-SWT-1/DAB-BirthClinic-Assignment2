using System;
using System.Collections.Generic;

namespace BirthClinicLibrary.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FullName { get; set; }
        
    }

    public class Child : Person
    {
        public Person Mother { get; set; }
        public DateTime ActualBirthTime { get; set; }
        public Birth Birth { get; set; }

    }

    public class Clinician:Person
    {
        public ICollection<Room> AssociatedRooms { get; set; }
    }
}