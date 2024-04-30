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
        Task<Persons> CreatePerson(string typeDocument, int document, string firstName, string secondName, string lastName, string secondLastName, string bloodType, DateTime birthDate, string direcction, string emailAddress, string phoneNumber, int patientId, int doctorId, int responsibleFamilyMemberId);
        Task<Persons> UpdatePerson(Persons person);
        Task<Persons> DeletePerson(int idPerson);

        public class PersonRepository : IPersonRepository
        {
            private readonly BaseDbContext _db;
            public PersonRepository(BaseDbContext db)
            {
                _db = db;
            }

            public async Task<Persons> CreatePerson(string typeDocument, int document, string firstName, string secondName, string lastName, string secondLastName, string bloodType, DateTime birthDate, string direcction, string emailAddress, string phoneNumber, int patientId, int doctorId, int responsibleFamilyMemberId)
            {
                Persons newPerson = new Persons
                {
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
                    ResponsibleFamilyMemberId = responsibleFamilyMemberId
                };

                await _db.Persons.AddAsync(newPerson);
                _db.SaveChanges();

                return newPerson;
            }

            public async Task<List<Persons>> GetAll()
            {
                return await _db.Persons.ToListAsync();
            }

            public async Task<Persons> GetPerson(int idPerson)
            {
                return await _db.Persons.FirstOrDefaultAsync(u => u.IdPerson == idPerson);
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