namespace BirthClinicLibrary.Models
{
    public class ClinicianBirth
    {
        public int ClinicianBirthId { get; set; }
        public Birth Birth { get; set; }
        public Clinician Clinician { get; set; }
    }
}