

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{


    public class Pharmacy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPharmacy { get; set; }
        public required string Pharmacyname { get; set; }
        public required string Direcction { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public string? Others { get; set; }

    }
}
