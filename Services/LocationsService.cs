using HospitalGests.Model;
using HospitalGests.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalGests.Services
{
    public interface ILocationService
    {
        Task<List<Locations>> GetAll();
        Task<Locations> GetLocation(int location_Id);
        Task<Locations> CreateLocation(int location_ID, int RoomID, string floor, string denomination);
        Task<Locations> UpdateLocation(int location_ID, int RoomId, string? floor = null, string? denomination = null);
        Task<Locations> DeleteLocation(int location_Id);
    }

    public class LocationsService : ILocationService
    {
        private readonly ILocationsRepository _locationsRepository;

        public LocationsService(ILocationsRepository locationsRepository)
        {
            _locationsRepository = locationsRepository;
        }

        public Task<Locations> CreateLocation(int location_ID, int RoomID, string floor, string denomination)
        {
            return _locationsRepository.CreateLocation(location_ID, RoomID, floor, denomination);
        }

        public async Task<Locations> DeleteLocation(int location_Id)
        {
            return await (_locationsRepository.DeleteLocation(location_Id));
        }

        public Task<List<Locations>> GetAll()
        {
            return _locationsRepository.GetAll();
        }

        public Task<Locations> GetLocation(int location_Id)
        {
            return _locationsRepository.GetLocation(location_Id);
        }

        public async Task<Locations> UpdateLocation(int location_ID, int RoomID, string? floor = null, string? denomination = null)
        {
            Locations newlocations = await _locationsRepository.GetLocation(location_ID);
            if (newlocations == null)
            {
                return null;
            }
            else
            {
                if (floor != null)
                {
                    newlocations.Floor = floor;
                }
                if (denomination != null)
                {
                    newlocations.Denomination = denomination;
                }
            }
            return await _locationsRepository.UpdateLocation(newlocations);
        }
    }
}
