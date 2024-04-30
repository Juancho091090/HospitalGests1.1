

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class Locations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Location_Id { get; set; }
        public string? Floor { get; set; }
        public string? Denomination { get; set; }
        public int RoomID { get; set; }
        public Rooms? Rooms { get; set; }
    }
}

