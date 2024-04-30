using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalGests.Repositories
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAll();
        Task<Doctor> GetDoctor(int doctorId);
        Task<Doctor> CreateDoctor(int idPerson, int specialitieId, string observations);
        Task<Doctor> UpdateDoctor(Doctor doctor);
        Task<Doctor> DeleteDoctor(int doctorId);
    }

    public class DoctorRepository : IDoctorRepository
    {
        private readonly BaseDbContext _db;

        public DoctorRepository(BaseDbContext db)
        {
            _db = db;
        }

        public async Task<List<Doctor>> GetAll()
        {
            return await _db.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctor(int doctorId)
        {
            return await _db.Doctors.FirstOrDefaultAsync(u => u.DoctorId == doctorId);
        }

        public async Task<Doctor> CreateDoctor(int idPerson, int specialitieId, string observations)
        {
            Doctor newDoctor = new Doctor
            {
                IdPerson = idPerson,
                SpecialitieId = specialitieId,
                Observations = observations
            };

            await _db.Doctors.AddAsync(newDoctor);
            await _db.SaveChangesAsync();

            return newDoctor;
        }

        public async Task<Doctor> UpdateDoctor(Doctor doctor)
        {
            _db.Doctors.Update(doctor);
            await _db.SaveChangesAsync();

            return doctor;
        }

        public async Task<Doctor> DeleteDoctor(int doctorId)
        {
            Doctor doctor = await GetDoctor(doctorId);
            _db.Doctors.Remove(doctor);
            await _db.SaveChangesAsync();

            return doctor;
        }
    }
}
