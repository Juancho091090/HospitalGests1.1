

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class Rooms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomID { get; set; }
        public int PatientId { get; set; }
        public required string StatusRoom { get; set; }
        public int Location_Id { get; set; }
        public Locations? Locations { get; set; }

        [ForeignKey("PatientId")]
        public Patients Patients { get; set; }
        public int Bed_ID { get; set; }
        public Beds Beds { get; set; }
    }
}
