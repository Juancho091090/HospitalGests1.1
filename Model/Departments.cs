using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class Departments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Department_Id { get; set; }
        public required string DepartmentName { get; set; }
        public  string? Description { get; set; }
    }
}
