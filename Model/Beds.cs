using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HospitalGests.Model
{
    public class Beds
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Bed_ID { get; set; }
        public int PatientId { get; set; }
        public int Stock { get; set; }

        [ForeignKey("PatientId")]
        public Patients? Patients { get; set; }

        public int RoomID { get; set; }
        public Rooms? Rooms { get; set; }

    }
}