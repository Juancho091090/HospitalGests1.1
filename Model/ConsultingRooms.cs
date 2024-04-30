

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class ConsultingRooms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConsultingRoom_ID { get; set; }
        public int RoomID { get; set; }
        public int Location_ID { get; set; }
        public int Departament_Id { get; set; }
        [ForeignKey("Departament_Id")]
        public Departments? Departments { get; set; }
        [ForeignKey("RoomID")]
        public Rooms? Rooms { get; set; }
        [ForeignKey("Location_ID")]
        public Locations? Locations { get; set; }
    }
}
