using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalGests.Repositories
{
    public interface IAvailabityRepository

    {
        Task<List<Availability>> GetAll();
        Task<Availability> GetAvailability(int AvailabilityId); 
        Task<Availability> CreatAvailability(int doctorId,DateTime? startDateTime,DateTime? endDateTime);
        Task<Availability> DeleteAvailability(int AvailabilityId);
        Task<Availability> UpdateAvialability( Availability availability);  

    }

    public class AviabilityRepository : IAvailabityRepository
    {
        private readonly BaseDbContext _db;
        public AviabilityRepository(BaseDbContext db)
        {
            _db = db;
        }
        public async Task<Availability> CreatAvailability(int doctorId, DateTime? startDateTime, DateTime? endDateTime)
        {
            Availability availability = new Availability
            {
                DoctorId = doctorId,
                StartDateTime = (DateTime)startDateTime,
                EndDateTime = (DateTime)endDateTime

            };
            await _db.Availabilities.AddAsync(availability);
            _db.SaveChanges();
            return availability;
        }

        public async Task<Availability> DeleteAvailability(int AvailabilityId)
        {
            Availability availability = await GetAvailability(AvailabilityId);
            if (availability == null)
            {
                //availability.IsDelete = true;
            }
            _db.Availabilities.Remove(availability);
            await _db.SaveChangesAsync();
            return availability;
           
        }

        public async Task<List<Availability>> GetAll()
        {
            return await _db.Availabilities.ToListAsync();
        }

        public async Task<Availability> GetAvailability(int AvailabilityId)
        {
            return await _db.Availabilities.FirstOrDefaultAsync(x => x.AvailabilityId == AvailabilityId);
        }

        public async Task<Availability> UpdateAvialability(Availability availability)
        {
            _db.Availabilities.Update(availability);
            await _db.SaveChangesAsync();
            return availability;
        }
    }

}
