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
        public Mother Mother { get; set; }
        public Person Father { get; set; }
        public DateTime ActualBirthTime { get; set; }
        public Birth Birth { get; set; }

    }

    public class Clinician:Person
    {
        public Clinician()
        {
            AssociatedBirths = new List<Birth>();
        }
        public ICollection<Birth> AssociatedBirths { get; set; }
    }
    public class Secretary : Person
    {
        
    }
    public class Mother : Person
    {
        //public Child Child { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
    public class MidWife : Clinician { }
    public class Doctor : Clinician { }
    public class Nurse : Clinician { }
    public class SocialHealthAssistant : Clinician { }

}