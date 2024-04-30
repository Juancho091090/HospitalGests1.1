using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalGests.Repositories
{
    public interface ISpecialityRepository
    {
        Task<List<Specialties>> GetAll();
        Task<Specialties> GetSpecialties(int specialitieId);
        Task<Specialties> CreateSpecialties(string specialitieName);
        Task<Specialties> UpdateSpecialties(Specialties specialties);
        Task<Specialties> DeleteSpecialties(int specialitieId);
    }
    public class SpecialityRepository : ISpecialityRepository
    {
        private readonly BaseDbContext _db;
        public SpecialityRepository(BaseDbContext db)
        {
            _db = db;
        }
        public async Task<List<Specialties>> GetAll()
        {
            return await _db.Specialties.ToListAsync();
        }
        public async Task<Specialties> GetSpecialties(int specialitieId)
        {
            return await _db.Specialties.FirstOrDefaultAsync(u => u.SpecialitieId == specialitieId);
        }
        public async Task<Specialties> CreateSpecialties(string specialityName)
        {
            Specialties newSpecialties = new Specialties
            {  
                SpecialitieName= specialityName
            };
            await _db.Specialties.AddAsync(newSpecialties);
            await _db.SaveChangesAsync();

            return newSpecialties;
        }
        public async Task<Specialties> UpdateSpecialties(Specialties speciality)
        {
            _db.Specialties.Update(speciality);
            await _db.SaveChangesAsync();
            return speciality;
        }
        public async Task<Specialties> DeleteSpecialties(int specialitieId)
        {
            Specialties speciality = await GetSpecialties(specialitieId);
            _db.Specialties.Update(speciality);
            await _db.SaveChangesAsync();
            return speciality;
        }
    }
}
