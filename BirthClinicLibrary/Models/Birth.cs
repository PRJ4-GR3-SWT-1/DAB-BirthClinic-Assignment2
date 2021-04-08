using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace BirthClinicLibrary.Models
{
    public class Birth
    {
        public Birth()
        {
            Clinicians = new List<Person>();
        }
        public int BirthId { get; set; }
        public Person Child { get; set; }

        
        public Room BirthRoom { get; set; }
            public DateTime BirthRoomReservationStart { get; set; }
            public DateTime BirthRoomReservationEnd { get; set; }
        
        public ICollection<Person>Clinicians { get; set; }
        public DateTime PlannedStartTime { get; set; }
    }
}