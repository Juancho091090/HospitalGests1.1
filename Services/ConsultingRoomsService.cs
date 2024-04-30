using HospitalGests.Model;
using HospitalGests.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalGests.Services
{
    public interface IConsultingRoomService
    {
        Task<List<ConsultingRooms>> GetAll();
        Task<ConsultingRooms> GetConsultingRoom(int consultingRoomId);
        Task<ConsultingRooms> CreateConsultingRoom(int roomID, int location_ID, int departmentId);
        Task<ConsultingRooms> UpdateConsultingRoom(int consultingRoomId, int roomID, int location_ID, int departmentId);
        Task<ConsultingRooms> DeleteConsultingRoom(int consultingRoomId);
    }

    public class ConsultingRoomsService : IConsultingRoomService
    {
        private readonly IConsultingRoomsRepository _consultingRoomsRepository;

        public ConsultingRoomsService(IConsultingRoomsRepository consultingRoomsRepository)
        {
            _consultingRoomsRepository = consultingRoomsRepository;
        }

        public async Task<ConsultingRooms> CreateConsultingRoom(int roomID, int location_ID, int departmentId)
        {
            return await _consultingRoomsRepository.CreateConsultingRoom(roomID, location_ID, departmentId);
        }

        public async Task<ConsultingRooms> DeleteConsultingRoom(int consultingRoomId)
        {
            return await (_consultingRoomsRepository.DeleteConsultingRoom(consultingRoomId));
        }

        public async Task<List<ConsultingRooms>> GetAll()
        {
            return await _consultingRoomsRepository.GetAll();
        }

        public async Task<ConsultingRooms> GetConsultingRoom(int consultingRoomId)
        {
            return await _consultingRoomsRepository.GetConsultingRoom(consultingRoomId);
        }

        public async Task<ConsultingRooms> UpdateConsultingRoom(int consultingRoomId, int roomID, int location_ID, int departmentId)
        {
            ConsultingRooms newConsultingRoooms = await _consultingRoomsRepository.GetConsultingRoom(consultingRoomId);
            if (newConsultingRoooms == null)
            {
                return null;
            }
            return await _consultingRoomsRepository.UpdateConsultingRoom(newConsultingRoooms);
        }
    }
}
