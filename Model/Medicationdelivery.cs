using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HospitalGests.Model
{
    public class Medicationdelivery
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDelivery { get; set; }
        public int IdPrescription { get; set; }
        public int IdPharmacy { get; set; }
        public DateTime DeliDaTe { get; set; }
        public required string DeliveredQuantity { get; set; }
        public required string State { get; set; }
        [ForeignKey("IdPrescription")]
        public Prescriptions? Prescriptions { get; set; }
        [ForeignKey("IdPharmacy")]
        public Pharmacy? Pharmacy { get; set;}
    }
}
