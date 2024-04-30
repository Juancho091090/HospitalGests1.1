using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalGests.Repositories
{
    public interface ILocationsRepository
    {
        Task<List<Locations>> GetAll();
        Task<Locations> GetLocation(int location_ID);
        Task<Locations> CreateLocation(int location_ID, int RoomID, string floor, string denomination);
        Task<Locations> UpdateLocation(Locations location);
        Task<Locations> DeleteLocation(int location_ID);
    }

    public class LocationsRepository : ILocationsRepository
    {
        private readonly BaseDbContext _db;

        public LocationsRepository(BaseDbContext db)
        {
            _db = db;
        }

        public async Task<List<Locations>> GetAll()
        {
            return await _db.Locations.ToListAsync();
        }

        public async Task<Locations> GetLocation(int locationId)
        {
            return await _db.Locations.FirstOrDefaultAsync(l => l.Location_Id == locationId);
        }

        public async Task<Locations> CreateLocation(int location_ID, int RoomID, string floor, string denomination)
        {
            Locations newLocation = new Locations
            {
                RoomID = RoomID,
                Floor = floor,
                Denomination = denomination
            };
            await _db.Locations.AddAsync(newLocation);
            await _db.SaveChangesAsync();

            return newLocation;
        }

        public async Task<Locations> UpdateLocation(Locations location)
        {
            _db.Locations.Update(location);
            await _db.SaveChangesAsync();

            return location;
        }

        public async Task<Locations> DeleteLocation(int locationId)
        {
            Locations location = await GetLocation(locationId);
            _db.Locations.Remove(location);
            await _db.SaveChangesAsync();

            return location;
        }
    }
}
