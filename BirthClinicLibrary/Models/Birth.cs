using System.Collections.Generic;

namespace BirthClinicLibrary.Models
{
    public class Birth
    {
        public int BirthId { get; set; }
        public Person Child { get; set; }

        public Person Mother { get; set; }
        public Room BirthRoom { get; set; }
        public ICollection<Person>Clinicians { get; set; }
    }
}