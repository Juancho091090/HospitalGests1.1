

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class MedicalEquipments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Equipment { get; set; }
        public int Department_Id { get; set; }
        public int Location_Id { get; set; }
        public string? EquipmentName { get; set; }
        public int StockEquipment { get; set; }
        [ForeignKey("Location_Id")]
        public Locations? Locations { get; set; }
        [ForeignKey("Department_Id")]
        public Departments? Departments { get; set; }

    }
}
