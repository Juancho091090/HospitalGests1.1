using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalGests.Repositories
{
    public interface IMedicalEquipmentsRepository
    {
        Task<List<MedicalEquipments>> GetAll();
        Task<MedicalEquipments> GetMedicalEquipment(int id_Equipment);
        Task<MedicalEquipments> CreateMedicalEquipment(int department_Id, int location_Id, string? equipmentName, int stockEquipment);
        Task<MedicalEquipments> UpdateMedicalEquipment(MedicalEquipments medicalEquipments);
        Task<MedicalEquipments> DeleteMedicalEquipment(int id_Equipment);
    }

    public class MedicalEquipmentsRepository : IMedicalEquipmentsRepository
    {
        private readonly BaseDbContext _db;

        public MedicalEquipmentsRepository(BaseDbContext db)
        {
            _db = db;
        }

        public async Task<List<MedicalEquipments>> GetAll()
        {
            return await _db.MedicalEquipments.ToListAsync();
        }

        public async Task<MedicalEquipments> GetMedicalEquipment(int id_Equipment)
        {
            return await _db.MedicalEquipments.FirstOrDefaultAsync(e => e.Id_Equipment == id_Equipment);
        }

        public async Task<MedicalEquipments> CreateMedicalEquipment(int department_Id, int location_Id, string? equipmentName, int stockEquipment)
        {
            MedicalEquipments newEquipment = new MedicalEquipments
            {
                Department_Id = department_Id,
                Location_Id = location_Id,
                EquipmentName = equipmentName,
                StockEquipment = stockEquipment
            };

            await _db.MedicalEquipments.AddAsync(newEquipment);
            await _db.SaveChangesAsync();

            return newEquipment;
        }

        public async Task<MedicalEquipments> UpdateMedicalEquipment(MedicalEquipments medicalEquipments)
        {
            _db.MedicalEquipments.Update(medicalEquipments);
            await _db.SaveChangesAsync();

            return medicalEquipments;
        }

        public async Task<MedicalEquipments> DeleteMedicalEquipment(int id_Equipment)
        {
            MedicalEquipments equipment = await GetMedicalEquipment(id_Equipment);
            _db.MedicalEquipments.Remove(equipment);
            await _db.SaveChangesAsync();

            return equipment;
        }
    }
}
