using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalGests.Repositories
{
    public interface IMedicinesRepository
    {
        Task<List<Medicines>> GetAll();
        Task<Medicines> GetMedicines(int medicineId);
        Task<Medicines> CreateMedicines(int treatmentId, string medicineName, float quantityAviable, DateTime dueDate, int idPrescription);
        Task<Medicines> UpdateMedicines(Medicines medicines);
        Task<Medicines> DeleteMedicines(int medicineId);
    }
    public class MedicinesRepository : IMedicinesRepository
    {
        private readonly BaseDbContext _db;
        public MedicinesRepository(BaseDbContext db)
        {
            _db = db;
        }
        public async Task<List<Medicines>> GetAll()
        {
            return await _db.Medicines.ToListAsync();
        }
        public async Task<Medicines> GetMedicines(int medicineId)
        {
            return await _db.Medicines.FirstOrDefaultAsync(u => u.MedicineId == medicineId);
        }
        public async Task<Medicines> CreateMedicines(int treatmentId, string medicineName, float quantityAviable, DateTime dueDate, int idPrescription)
        {
            Medicines newMedicine = new Medicines
            {
                MedicineName = medicineName,
                TreatmentId = treatmentId,
                QuantityAvaiable = quantityAviable,
                DueDate = dueDate,
                IdPrescription = idPrescription
            };
            await _db.Medicines.AddAsync(newMedicine);
            await _db.SaveChangesAsync();

            return newMedicine;
        }
        public async Task<Medicines> UpdateMedicines(Medicines medicines)
        {
            _db.Medicines.Update(medicines);
            await _db.SaveChangesAsync();
            return medicines;
        }
        public async Task<Medicines> DeleteMedicines(int medicineId)
        {
            Medicines medicines = await GetMedicines(medicineId);
            _db.Medicines.Update(medicines);
            await _db.SaveChangesAsync();
            return medicines;
        }
    }
}