using HospitalGests.Model;
using HospitalGests.Repositories;

namespace HospitalGests.Services
{

    public  interface IPersonService
    {
            Task<List<Persons>> GetAll();
            Task<Persons> GetPerson(int idPerson);
            Task<Persons> CreatePerson(string typeDocument, int document, string firstName, string secondName, string lastName, string secondLastName, string bloodType, DateTime birthDate, string direcction, string emailAddress, string phoneNumber, int patientId,int doctorId, int responsibleFamilyMemberId);
        Task<Persons> UpdatePerson(int idPerson, int patientId, int doctorId, int responsibleFamilyMemberId, string? typeDocument = null, int? document = null, string? firstName = null, string? secondName = null, string? lastName = null, string? secondLastName = null, string? bloodType = null, DateTime? birthDate = null, string? direcction = null, string? emailAddress = null, string? phoneNumber = null);
            Task<Persons> DeletePerson(int idPerson);
        
    }

    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepositoy;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepositoy = personRepository;
        }
        public async Task<Persons> CreatePerson(string typeDocument, int document, string firstName, string secondName, string lastName, string secondLastName, string bloodType, DateTime birthDate, string direcction, string emailAddress, string phoneNumber, int patientId, int doctorId, int ResponsibleFamilyMemberId)
        {
            return await _personRepositoy.CreatePerson(typeDocument, document, firstName, secondName, lastName, secondLastName, bloodType, birthDate, direcction, emailAddress, phoneNumber, patientId, doctorId, ResponsibleFamilyMemberId);
        }

        public async Task<Persons> DeletePerson(int IdPerson)
        {
            return await (_personRepositoy.DeletePerson(IdPerson));
        }

        public async Task<List<Persons>> GetAll()
        {
            return await _personRepositoy.GetAll();
        }

        public Task<Persons> GetPerson(int IdPerson)
        {
            return _personRepositoy.GetPerson(IdPerson);
        }

        public async Task<Persons> UpdatePerson(int idPerson, int patientId, int doctorId, int responsibleFamilyMemberId, string? typeDocument = null, int? document = null, string? firstName = null, string? secondName = null, string? lastName = null, string? secondLastName = null, string? bloodType = null, DateTime? birthDate = null, string? direcction = null, string? emailAddress = null, string? phoneNumber = null)
        {
            Persons newPerson = await _personRepositoy.GetPerson(idPerson);
            if (newPerson != null)
            {
                if (typeDocument != null)
                {
                    newPerson.TypeDocument = typeDocument;
                }
               if (document != null)
                {
                    newPerson.Document = (int)document;
                }
               if(firstName != null)
                {
                    newPerson.FirstName = firstName;
                }
               if(secondName != null)
                {
                    newPerson.SecondName = secondName;
                }
               if (lastName != null)
                {
                    newPerson.LastName = lastName;
                }
               if (secondLastName != null)
                {
                    newPerson.SecondLastName = secondLastName;
                }
               if(bloodType != null)
                {
                    newPerson.BloodType = bloodType;
                }      
               if (birthDate != null)
                {
                    newPerson.BirthDate = (DateTime)birthDate;
                }
               if(direcction != null)
                {
                    newPerson.Direcction = direcction;
                }
               if(emailAddress != null)
                {
                    newPerson.EmailAddress = emailAddress;
                }
               if (phoneNumber != null)
                {
                    newPerson.PhoneNumber = phoneNumber;
                }
            }
            return await _personRepositoy.UpdatePerson(newPerson);
        }

       
    }
}
