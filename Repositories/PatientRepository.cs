using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HospitalGests.Repositories
{

    public interface IPatientRepository
    {
        Task<List<Patients>> GetAll();
        Task<Patients> GetPatients(int patientId);
        Task<Patients> CreatePatients(int idPerson);
        Task<Patients> UpdatePatients(Patients patient);
        Task<Patients> DeletePatients(int patientId);
    }


    public class PatientRepository : IPatientRepository
    {
        private readonly BaseDbContext _db;

        public PatientRepository(BaseDbContext db)
        {
            _db = db;
        }

        public async Task<List<Patients>> GetAll()
        {
            return await _db.Patients.ToListAsync();
        }

        public async Task<Patients> GetPatients(int patientId)
        {
            return await _db.Patients.FirstOrDefaultAsync(u => u.PatientId == patientId);
        }

        public async Task<Patients> CreatePatients(int idPerson)
        {
            Patients newPatients = new Patients
            {
                IdPerson = idPerson,
            };

            await _db.Patients.AddAsync(newPatients);
            await _db.SaveChangesAsync();

            return newPatients;
        }

        public async Task<Patients> UpdatePatients(Patients patients)
        {
            _db.Patients.Update(patients);
            await _db.SaveChangesAsync();

            return patients;
        }

        public async Task<Patients> DeletePatients(int patientId)
        {
            Patients patients = await GetPatients(patientId);
            _db.Patients.Remove(patients);
            await _db.SaveChangesAsync();

            return patients;
        }
    }
}