using System;

namespace BirthClinicLibrary.Models
{
    public class Reservation
    {
        public Room ReservedRoom { get; set; }
        public Mother User { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }
    }
}