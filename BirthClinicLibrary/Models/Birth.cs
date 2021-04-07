using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace BirthClinicLibrary.Models
{
    public class Birth
    {
        public int BirthId { get; set; }
        public Person Child { get; set; }

        
        public Room BirthRoom { get; set; }
            public DateTime BirthRoomReservationStart { get; set; }
            public DateTime BirthRoomReservationEnd { get; set; }
        public Room MaternityRoom { get; set; }
            public DateTime MaternityRoomReservationStart { get; set; }
            public DateTime MaternityRoomReservationEnd { get; set; }
        public Room RestingRoom { get; set; }
            public DateTime RestingRoomReservationStart { get; set; }
            public DateTime RestingRoomReservationEnd { get; set; }
        public ICollection<Person>Clinicians { get; set; }
        public DateAndTime PlannedStartTime { get; set; }
    }
}