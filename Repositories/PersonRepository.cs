using Microsoft.EntityFrameworkCore;
using HospitalGests.Model;
using HospitalGests.Context;
using System.Numerics;

namespace HospitalGests.Repositories
{
    public interface IPersonRepository
    {
        Task<List<Persons>> GetAll();
        Task<Persons> GetPerson(int idPerson);
        Task<Persons> CreatePerson(int idPerson, string typeDocument, int document, string firstName, string secondName, string lastName, string secondLastName, string bloodType, DateTime birthDate, string direcction, string emailAddress, string phoneNumber, int patientId, int doctorId, int responsibleFamilyMemberId, byte[] PasswordHash, byte[] PasswordSalt);
        Task<Persons> GetPersonByDocument(int document);
        Task<Persons> CreatePerson(Persons person, string password);
        Task<Persons> UpdatePerson(Persons person);
        Task<Persons> DeletePerson(int idPerson);

        public class PersonRepository : IPersonRepository
        {
            private readonly BaseDbContext _db;
            public PersonRepository(BaseDbContext db)
            {
                _db = db;
            }

            public async Task<Persons> CreatePerson(int idPerson, string typeDocument, int document, string firstName, string secondName, string lastName, string secondLastName, string bloodType, DateTime birthDate, string direcction, string emailAddress, string phoneNumber, int patientId, int doctorId, int responsibleFamilyMemberId, byte[] passwordHash, byte[] passwordSalt)
            {
                Persons newPerson = new Persons
                {
                    IdPerson = idPerson,
                    TypeDocument = typeDocument,
                    Document = document,
                    FirstName = firstName,
                    SecondName = secondName,
                    LastName = lastName,
                    SecondLastName = secondLastName,
                    BloodType = bloodType,
                    BirthDate = birthDate,
                    Direcction = direcction,
                    EmailAddress = emailAddress,
                    PhoneNumber = phoneNumber,
                    PatientId = patientId,
                    DoctorId = doctorId,
                    ResponsibleFamilyMemberId = responsibleFamilyMemberId,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };

                await _db.Persons.AddAsync(newPerson);
                _db.SaveChanges();

                return newPerson;
            }
            public async Task<Persons> CreatePerson(Persons person, string password)
            {
                // Generar hash y sal de la contraseña
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                // Asignar hash y sal a la persona
                person.PasswordHash = passwordHash;
                person.PasswordSalt = passwordSalt;

                // Guardar la persona en la base de datos
                await _db.Persons.AddAsync(person);
                await _db.SaveChangesAsync();

                return person;
            }
            private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
            {
                using (var hmac = new System.Security.Cryptography.RNGCryptoServiceProvider())
                {
                    // Generar una sal aleatoria
                    byte[] salt = new byte[16];
                    hmac.GetBytes(salt);

                    // Calcular el hash de la contraseña utilizando PBKDF2
                    using (var pbkdf2 = new System.Security.Cryptography.Rfc2898DeriveBytes(password, salt, 10000))
                    {
                        passwordHash = pbkdf2.GetBytes(20); // Tamaño del hash de salida: 20 bytes
                    }

                    // Asignar el hash y la sal generados
                    passwordSalt = salt;
                }
            }

            public async Task<List<Persons>> GetAll()
            {
                return await _db.Persons.ToListAsync();
            }

            public async Task<Persons> GetPerson(int idPerson)
            {
                return await _db.Persons.FirstOrDefaultAsync(u => u.IdPerson == idPerson);
            }
            public async Task<Persons> GetPersonByDocument(int document)
            {
                return await _db.Persons.FirstOrDefaultAsync(p => p.Document == document);
            }

            public async Task<Persons> UpdatePerson(Persons person)
            {
                _db.Persons.Update(person);
                await _db.SaveChangesAsync();
                return person;
            }
            public async Task<Persons> DeletePerson(int idPerson)
            {
               Persons persons = await GetPerson(idPerson);
                _db.Persons.Update(persons);
                await _db.SaveChangesAsync();

                return persons;
            }
        }
    }
}