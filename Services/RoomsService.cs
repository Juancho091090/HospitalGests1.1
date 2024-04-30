using HospitalGests.Model;
using HospitalGests.Repositories;

namespace HospitalGests.Services
{
    public interface IRoomsService
    {
        Task<List<Rooms>> GetAll();
        Task<Rooms> GetRooms(int roomID);
        Task<Rooms> CreateRooms(int PatientId, string statusRoom, int location_Id, int bed_Id);
        Task<Rooms> UpdateRooms(int roomID, int PatientId, int location_Id, int bed_Id, string? statusRoom = null );
        Task<Rooms> DeleteRooms(int roomID);
    }
    public class RoomsService : IRoomsService

    {
        public readonly IRoomsRepository _roomsRepository;

        public RoomsService(IRoomsRepository roomsRepository)
        {
            _roomsRepository = roomsRepository;
        }

        public async Task<Rooms> CreateRooms(int patientId, string statusRoom, int location_Id, int bed_Id)
        {
            return await _roomsRepository.CreateRooms(patientId, statusRoom, location_Id, bed_Id);
        }

        public async Task<Rooms> DeleteRooms(int roomID)
        {
            return await (_roomsRepository.DeleteRooms(roomID));    
        }
        public async Task<List<Rooms>> GetAll()
        {
            return await _roomsRepository.GetAll();
        }

        public async Task<Rooms> GetRooms(int roomID)
        {
            return await _roomsRepository.GetRooms(roomID);
        }

        public async Task<Rooms> UpdateRooms(int roomID, int PatientId, int location_Id, int bed_Id, string? statusRoom = null)
        {
            Rooms newRooms = await _roomsRepository.GetRooms(roomID);
            if (newRooms == null)
            {
                return null;
            }
            if (statusRoom != null) 
            {
                newRooms.StatusRoom = statusRoom;
            }
            return await _roomsRepository.UpdateRooms(newRooms);
        }

    }
}