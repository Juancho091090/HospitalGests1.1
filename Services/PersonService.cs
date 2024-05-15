using HospitalGests.Model;
using HospitalGests.Repositories;
using static HospitalGests.Repositories.IPersonRepository;

namespace HospitalGests.Services
{

    public  interface IPersonService
    {
        Task<List<Persons>> GetAll();
        Task<Persons> GetPerson(int idPerson);
        Task<Persons> CreatePerson(int idPerson, string typeDocument, int document, string firstName, string secondName, string lastName, string secondLastName, string bloodType, DateTime birthDate, string direcction, string emailAddress, string phoneNumber, int patientId,int doctorId, int responsibleFamilyMemberId, byte[] passwordHash, byte[] passwordSalt);
        Task<Persons> GetPersonByDocument(int document);
        Task<Persons> CreatePerson(Persons person, string password);
        Task<bool> Authenticate(string userNumber, string password);
        Task<Persons> UpdatePerson(int idPerson, int patientId, int doctorId, int responsibleFamilyMemberId, string? typeDocument = null, int? document = null, string? firstName = null, string? secondName = null, string? lastName = null, string? secondLastName = null, string? bloodType = null, DateTime? birthDate = null, string? direcction = null, string? emailAddress = null, string? phoneNumber = null, byte[]? passwordHash = null, byte[]? passwordSalt = null);
        Task<Persons> DeletePerson(int idPerson);
        
    }

    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepositoy;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepositoy = personRepository;
        }
        public async Task<Persons> CreatePerson(int idPerson, string typeDocument, int document, string firstName, string secondName, string lastName, string secondLastName, string bloodType, DateTime birthDate, string direcction, string emailAddress, string phoneNumber, int patientId, int doctorId, int ResponsibleFamilyMemberId, byte[] passwordHash, byte[] passwordSalt)
        {
            return await _personRepositoy.CreatePerson(idPerson, typeDocument, document, firstName, secondName, lastName, secondLastName, bloodType, birthDate, direcction, emailAddress, phoneNumber, patientId, doctorId, ResponsibleFamilyMemberId, passwordHash, passwordHash);
        }
        public async Task<Persons> CreatePerson(Persons person, string password)
        {
            return await _personRepositoy.CreatePerson(person, password);
        }
        public async Task<bool> Authenticate(string userNumber, string password)
        {
            var user = await _personRepositoy.GetPersonByDocument(int.Parse(userNumber));

            // Verificar si el usuario existe y si la contraseña es correcta
            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return false;

            return true;
        }
        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            // Verificar la contraseña hash y sal almacenada
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                        return false;
                }
            }
            return true;
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
        public async Task<Persons> GetPersonByDocument(int document)
        {
            return await _personRepositoy.GetPersonByDocument(document);
        }

        public async Task<Persons> UpdatePerson(int idPerson, int patientId, int doctorId, int responsibleFamilyMemberId, string? typeDocument = null, int? document = null, string? firstName = null, string? secondName = null, string? lastName = null, string? secondLastName = null, string? bloodType = null, DateTime? birthDate = null, string? direcction = null, string? emailAddress = null, string? phoneNumber = null, byte[]? passwordHash = null, byte[]? passwordSalt = null)
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
               if (passwordHash != null)
                {
                    newPerson.PasswordHash = passwordHash;
                }
               if (passwordSalt != null)
                {
                    newPerson.PasswordSalt = passwordSalt;
                }
            }
            return await _personRepositoy.UpdatePerson(newPerson);
        }

       
    }
}
