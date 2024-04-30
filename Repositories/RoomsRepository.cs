using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalGests.Repositories
{
    public interface IRoomsRepository
    {
        Task<List<Rooms>> GetAll();
        Task<Rooms> GetRooms(int roomID);
        Task<Rooms> CreateRooms(int PatientId, string statusRoom, int locatio_Id, int bed_Id);
        Task<Rooms> UpdateRooms(Rooms room);
        Task<Rooms> DeleteRooms(int roomID);
    }

    public class RoomsRepository : IRoomsRepository
    {
        private readonly BaseDbContext _db;

        public RoomsRepository(BaseDbContext db)
        {
            _db = db;
        }

        public async Task<List<Rooms>> GetAll()
        {
            return await _db.Rooms.ToListAsync();
        }

        public async Task<Rooms> GetRooms(int roomID)
        {
            return await _db.Rooms.FirstOrDefaultAsync(r => r.RoomID == roomID);
        }

        public async Task<Rooms> CreateRooms(int PatientId, string statusRoom, int locatio_Id, int bed_Id)
        {
            Rooms rooms = new Rooms
            {
                PatientId = PatientId,
                StatusRoom = statusRoom,
                Location_Id = locatio_Id,
                Bed_ID = bed_Id
            };
            await _db.Rooms.AddAsync(rooms);
            _db.SaveChanges();
            return rooms;
        }

        public async Task<Rooms> UpdateRooms(Rooms room)
        {
            _db.Rooms.Update(room);
            await _db.SaveChangesAsync();
            return room;
        }

        public async Task<Rooms> DeleteRooms(int roomID)
        {
            var room = await _db.Rooms.FindAsync(roomID);

            _db.Rooms.Update(room);
            await _db.SaveChangesAsync(); 
            return room;
        }
    }
}