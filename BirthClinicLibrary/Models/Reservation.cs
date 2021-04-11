using System;

namespace BirthClinicLibrary.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public Room ReservedRoom { get; set; }
        public Mother User { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }
    }
}