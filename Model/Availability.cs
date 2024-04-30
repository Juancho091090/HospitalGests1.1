

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class Availability
    {
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int AvailabilityId { get; set; }
       public int DoctorId { get; set; }
       public DateTime StartDateTime { get; set; }
       public DateTime EndDateTime { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }
    }
}