

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class ResponsibleFamilyMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResponsibleFamilyMemberId { get; set; }
        public string? Relationship { get; set; }
        public bool IsPatient { get; set; }
        public int IdPerson { get; set; }
        public Persons Person { get; set; }
    }
}
