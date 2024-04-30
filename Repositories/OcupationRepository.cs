using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalGests.Repositories
{
    public interface IOccupationsRepository
    {
        Task<List<Occupation>> GetAll();
        Task<Occupation> GetOccupation(int occupation_Id);
        Task<Occupation> CreateOccupation(int roomID, int patientId, int doctorId, int locationId, string type, DateTime startDateTime, DateTime endDateTime);
        Task<Occupation> UpdateOccupation(Occupation occupation);
        Task<Occupation> DeleteOccupation(int occupation_Id);

    }

    public class OccupationsRepository : IOccupationsRepository
    {
        private readonly BaseDbContext _db;

        public OccupationsRepository(BaseDbContext db)
        {
            _db = db;
        }

        public async Task<List<Occupation>> GetAll()
        {
            return await _db.Occupations.ToListAsync();
        }

        public async Task<Occupation> GetOccupation(int occupation_Id)
        {
            return await _db.Occupations.FirstOrDefaultAsync(o => o.Occupation_Id == occupation_Id);
        }

        public async Task<Occupation> CreateOccupation(int roomID, int patientId, int doctorId, int locationId, string type, DateTime startDateTime, DateTime endDateTime)
        {
            Occupation newOccupation = new Occupation
            {
                RoomID = roomID,
                Type = type,
                PatientId = patientId,
                DoctorId = doctorId,
                Location_Id = locationId,
                StartDateTime = startDateTime,
                EndDateTime = endDateTime,

            };

            await _db.Occupations.AddAsync(newOccupation);
            await _db.SaveChangesAsync();

            return newOccupation;
        }

        public async Task<Occupation> UpdateOccupation(Occupation occupation)
        {
            _db.Occupations.Update(occupation);
            await _db.SaveChangesAsync();

            return occupation;
        }

        public async Task<Occupation> DeleteOccupation(int occupation_Id)
        {
            Occupation occupation = await GetOccupation(occupation_Id);
            _db.Occupations.Remove(occupation);
            await _db.SaveChangesAsync();

            return occupation;
        }
    }
}