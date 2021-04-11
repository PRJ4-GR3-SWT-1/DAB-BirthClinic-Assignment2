using System;
using System.Collections.Generic;
using EFModels.Data;

namespace BirthClinicLibrary.Models
{
    public abstract class Person
    {
        protected Person(string name)
        {
            FullName = name;
        }
        public int PersonId { get; set; }
        public string FullName { get; set; }
        
    }

    public class Child : Person
    {
        public Child(string name, Mother mother, Birth birth) : base(name)
        {
            Mother = mother;
            Birth = birth;
        }
        public Mother Mother { get; set; }
        public FamilyMember Father { get; set; }
        public DateTime ActualBirthTime { get; set; }
        public Birth Birth { get; set; }

    }

    public class Clinician:Person
    {
        public Clinician(string name) : base(name)
        {
            AssociatedBirths = new List<ClinicianBirth>();
        }
        public List<ClinicianBirth> AssociatedBirths { get; set; }
    }
    public class Secretary : Person
    {
        public Secretary(string name) : base(name)
        {

        }
        
    }
    public class Mother : Person
    {
        public Mother(string name):base(name)
        {
            Reservations = new List<Reservation>();
            Children = new List<Child>();
        }
        public List<Child> Children { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }

    public class FamilyMember : Person
    {
        public FamilyMember(string name, string relation) : base(name)
        {
            Relation = relation;
        }
        public string Relation { get; set; }
    }



    public class MidWife : Clinician
    {
        public MidWife(string name) : base(name)
        {

        }

    }

    public class Doctor : Clinician
    {
        public Doctor(string name) : base(name)
        {

        }
    }

    public class Nurse : Clinician
    {
        public Nurse(string name) : base(name)
        {
        }
    }

    public class SocialHealthAssistant : Clinician
    {
        public SocialHealthAssistant(string name) : base(name)
        {
        }
    }
}