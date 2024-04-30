using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalGests.Repositories
{
    public interface IOperatingRoomsRepository
    {
        Task<List<OperatingRooms>> GetAll();
        Task<OperatingRooms> GetOperatingRoom(int operatingRoomId);
        Task<OperatingRooms> CreateOperatingRoom(int department_Id, string operatingRoomStatus, int doctorId, int patientId);
        Task<OperatingRooms> UpdateOperatingRoom(OperatingRooms operatingRoom);
        Task<OperatingRooms> DeleteOperatingRoom(int operatingRoomId);
    }

    public class OperatingRoomsRepository : IOperatingRoomsRepository
    {
        private readonly BaseDbContext _db;

        public OperatingRoomsRepository(BaseDbContext db)
        {
            _db = db;
        }

        public async Task<List<OperatingRooms>> GetAll()
        {
            return await _db.OperatingRooms.ToListAsync();
        }

        public async Task<OperatingRooms> GetOperatingRoom(int operatingRoomId)
        {
            return await _db.OperatingRooms.FirstOrDefaultAsync(o => o.OperatingRoom_ID == operatingRoomId);
        }

        public async Task<OperatingRooms> CreateOperatingRoom(int department_Id, string operatingRoomStatus, int doctorId, int patientId)
        {
            OperatingRooms newOperatingRoom = new OperatingRooms
            {
                Department_Id = department_Id,
                OperatingRoomStatus = operatingRoomStatus,
                DoctorId = doctorId,
                PatientId = patientId
            };

            await _db.OperatingRooms.AddAsync(newOperatingRoom);
            await _db.SaveChangesAsync();

            return newOperatingRoom;
        }

        public async Task<OperatingRooms> UpdateOperatingRoom(OperatingRooms operatingRoom)
        {
            _db.OperatingRooms.Update(operatingRoom);
            await _db.SaveChangesAsync();

            return operatingRoom;
        }

        public async Task<OperatingRooms> DeleteOperatingRoom(int operatingRoomId)
        {
            OperatingRooms operatingRoom = await GetOperatingRoom(operatingRoomId);
            _db.OperatingRooms.Remove(operatingRoom);
            await _db.SaveChangesAsync();

            return operatingRoom;
        }
    }
}