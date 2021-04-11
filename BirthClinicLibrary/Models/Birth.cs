using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace BirthClinicLibrary.Models
{
    public class Birth
    {
        public Birth()
        {
            Clinicians = new List<ClinicianBirth>();
        }
        public int BirthId { get; set; }
        public Person Child { get; set; }

       
        
        public List<ClinicianBirth> Clinicians { get; set; }
        public DateTime PlannedStartTime { get; set; }
    }
}