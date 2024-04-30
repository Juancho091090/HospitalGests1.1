
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{


    public class Stockmedicines
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idstock { get; set; }
        public int MedicineId { get; set; }
        public int IdPharmacy { get; set; }
        public int Stockquantity { get; set; }
        public DateOnly Lastupdate { get; set; }
        [ForeignKey("MedicineId")]
        public Medicines? Medicines { get; set; }
        [ForeignKey("IdPharmacy")]
        public Pharmacy? Pharmacy { get; set; }
    }
}
