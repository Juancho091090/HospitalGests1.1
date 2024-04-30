

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class OperatingRooms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OperatingRoom_ID { get; set; }
        public int Department_Id { get; set; }
        public required string OperatingRoomStatus { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("Department_Id")]
        public Departments? Departments { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor? Doctors { get; set; }
        [ForeignKey("PatientId")]
        public Patients? Patients { get; set; }
    }
}
