

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class Occupation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Occupation_Id { get; set; }
        public int RoomID { get; set; }
        public string? Type { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int Location_Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        [ForeignKey("PatientId")]
        public Patients? Patients { get; set; }
        [ForeignKey("RoomID")]
        public Rooms? Rooms { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }
        [ForeignKey("Location_Id")]
        public Locations? Locations { get; set; }
    }
}
