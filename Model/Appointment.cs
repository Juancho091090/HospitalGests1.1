

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentId { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public string? Status { get; set; }

        public string? Observations { get; set; }
        [ForeignKey("PatientId")]
        public Patients? Patients { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor? Doctors { get; set; }

    }
}