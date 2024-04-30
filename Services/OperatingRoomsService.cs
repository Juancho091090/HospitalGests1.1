using HospitalGests.Model;
using HospitalGests.Repositories;

namespace HospitalGests.Services
{
    public interface IOperatingService
    {
        Task<List<OperatingRooms>> GetAll();
        Task<OperatingRooms> GetOperatingRoom(int operatingRoomId);
        Task<OperatingRooms> CreateOperatingRoom(int department_Id, string operatingRoomStatus, int doctorId, int patientId);
        Task<OperatingRooms> UpdateOperatingRoom(int operatingRoomId, int department_Id, string? operatingRoomStatus, int doctorId, int patientId);
        Task<OperatingRooms> DeleteOperatingRoom(int operatingRoomId);
    }
    public class OperatingRoomsService : IOperatingService

    {
        public readonly IOperatingRoomsRepository _operatingRoomsRepository;
        public OperatingRoomsService(IOperatingRoomsRepository operatingRoomsRepository)
        {
            _operatingRoomsRepository = operatingRoomsRepository;
        }

        public async Task<OperatingRooms> CreateOperatingRoom(int department_Id, string operatingRoomStatus, int doctorId, int patientId)
        {
            return await _operatingRoomsRepository.CreateOperatingRoom(department_Id, operatingRoomStatus, doctorId, patientId);
        }

        public async Task<OperatingRooms> DeleteOperatingRoom(int operatingRoom_ID)
        {
            return await (_operatingRoomsRepository.DeleteOperatingRoom(operatingRoom_ID));
        }

        public async Task<List<OperatingRooms>> GetAll()
        {
            return await _operatingRoomsRepository.GetAll();
        }

        public async Task<OperatingRooms> GetOperatingRoom(int operatingRoomId)
        {
            return await _operatingRoomsRepository.GetOperatingRoom(operatingRoomId);
        }

        public async Task<OperatingRooms> UpdateOperatingRoom(int operatingRoomId, int department_Id, string? operatingRoomStatus, int doctorId, int patientId)
        {
            OperatingRooms newOperatingRooms = await _operatingRoomsRepository.GetOperatingRoom(operatingRoomId);
            if (newOperatingRooms == null)
            {
                return null;
            }
            if (operatingRoomStatus != null)
            {
                newOperatingRooms.OperatingRoomStatus = operatingRoomStatus;
            }
            return await _operatingRoomsRepository.UpdateOperatingRoom(newOperatingRooms);
        }

    }
}