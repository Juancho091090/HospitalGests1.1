


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalGests.Model
{
    public class Persons
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPerson { get; set; }
        public required string TypeDocument { get; set; }
        public required int Document {  get; set; }
        public required string FirstName { get; set; }
        public  string? SecondName { get; set; }
        public required string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public required string BloodType { get; set; }
        public required DateTime BirthDate { get; set; }
        public required string Direcction {  get; set; }
        public required string EmailAddress { get; set; }
        public required string PhoneNumber { get; set;}
        public int? PatientId { get; set; }
        public Patients? Patient { get; set; }
        public int? ResponsibleFamilyMemberId { get; set; }
        public ResponsibleFamilyMember? ResponsibleFamilyMember { get; set; }
        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
    }
    
}
