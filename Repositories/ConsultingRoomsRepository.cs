using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalGests.Repositories
{
    public interface IConsultingRoomsRepository
    {
        Task<List<ConsultingRooms>> GetAll();
        Task<ConsultingRooms> GetConsultingRoom(int ConsultingRoomId);
        Task<ConsultingRooms> CreateConsultingRoom(int roomID, int location_ID, int departmentId);
        Task<ConsultingRooms> UpdateConsultingRoom(ConsultingRooms consultingRoom);
        Task<ConsultingRooms> DeleteConsultingRoom(int ConsultingRoomId);
    }

    public class ConsultingRoomsRepository : IConsultingRoomsRepository
    {
        private readonly BaseDbContext _db;

        public ConsultingRoomsRepository(BaseDbContext db)
        {
            _db = db;
        }

        public async Task<List<ConsultingRooms>> GetAll()
        {
            return await _db.ConsultingRooms.ToListAsync();
        }

        public async Task<ConsultingRooms> GetConsultingRoom(int ConsultingRoomId)
        {
            return await _db.ConsultingRooms.FirstOrDefaultAsync(c => c.ConsultingRoom_ID == ConsultingRoomId);
        }

        public async Task<ConsultingRooms> CreateConsultingRoom(int roomID, int location_ID, int departmentId)
        {
            ConsultingRooms newConsultingRoom = new ConsultingRooms
            {
                RoomID = roomID,
                Location_ID = location_ID,
                Departament_Id = departmentId
            };

            await _db.ConsultingRooms.AddAsync(newConsultingRoom);
            await _db.SaveChangesAsync();

            return newConsultingRoom;
        }

        public async Task<ConsultingRooms> UpdateConsultingRoom(ConsultingRooms consultingRoom)
        {
            _db.ConsultingRooms.Update(consultingRoom);
            await _db.SaveChangesAsync();

            return consultingRoom;
        }

        public async Task<ConsultingRooms> DeleteConsultingRoom(int ConsultingRoomId)
        {
            ConsultingRooms consultingRoom = await GetConsultingRoom(ConsultingRoomId);

            _db.ConsultingRooms.Update(consultingRoom);
            await _db.SaveChangesAsync();

            return consultingRoom;
        }
    }
}
