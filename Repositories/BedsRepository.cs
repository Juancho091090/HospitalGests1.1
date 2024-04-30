using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalGests.Repositories
{
    public interface IBedsRepository
    {
        Task<List<Beds>> GetAll();
        Task<Beds> GetBeds(int Bed_ID);
        Task<Beds> CreateBeds(int Bed_ID, int patientId, int roomId, int stock);
        Task<Beds> UpdateBeds(Beds beds);
        Task<Beds> DeleteBeds(int Bed_ID);
    }

    public class BedsRepository : IBedsRepository
    {
        private readonly BaseDbContext _db;

        public BedsRepository(BaseDbContext db)
        {
            _db = db;
        }

        public async Task<List<Beds>> GetAll()
        {
            return await _db.Beds.ToListAsync();
        }

        public async Task<Beds> GetBeds(int bedId)
        {
            return await _db.Beds.FirstOrDefaultAsync(b => b.Bed_ID == bedId);
        }

        public async Task<Beds> CreateBeds(int Bed_ID, int patientId, int roomId , int stock)
        {
            Beds beds = new Beds
            {
                Bed_ID = Bed_ID,
                PatientId = patientId,
                Stock = stock,
                RoomID = roomId
            };
            await _db.Beds.AddAsync(beds);
            _db.SaveChanges();
            return beds;
        }

        public async Task<Beds> UpdateBeds(Beds bed)
        {
            _db.Beds.Update(bed);
            await _db.SaveChangesAsync();
            return bed;
        }

        public async Task<Beds> DeleteBeds(int bedId)
        {
            Beds bed = await GetBeds(bedId);

            _db.Beds.Update(bed);
            await _db.SaveChangesAsync();
            return bed;
        }
    }
}
