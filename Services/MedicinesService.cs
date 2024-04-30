using HospitalGests.Model;
using HospitalGests.Repositories;

namespace HospitalGests.Services
{
    public interface IMedicineService
    {
        Task<List<Medicines>> GetAll();
        Task<Medicines> GetMedicines(int medicineId);
        Task<Medicines> CreateMedicines(int treatmentId, string medicineName, float quantityAviable, DateTime dueDate, int idPrescription);
        Task<Medicines> UpdateMedicines(int medicineId, int treatmentId, string? medicineName = null, float? quantityAviable = null, DateTime? dueDate = null, int? idPrescription = null);
        Task<Medicines> DeleteMedicines(int medicineId);
    }
    public class MedicinesService : IMedicineService

    {
        public readonly IMedicinesRepository _medicineRepository;

        public MedicinesService(IMedicinesRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public async Task<Medicines> CreateMedicines(int treatmentId, string medicineName, float quantityAviable, DateTime dueDate, int idPrescription)
        {
            return await _medicineRepository.CreateMedicines(treatmentId, medicineName, quantityAviable, dueDate, idPrescription);
        }

        public async Task<Medicines> DeleteMedicines(int medicineId)
        {
            return await (_medicineRepository.DeleteMedicines(medicineId));
        }

        public async Task<List<Medicines>> GetAll()
        {
            return await _medicineRepository.GetAll();
        }

        public async Task<Medicines> GetMedicines(int medicineId)
        {
            return await _medicineRepository.GetMedicines(medicineId);
        }

        public async Task<Medicines> UpdateMedicines(int medicineId, int treatmentId, string? medicineName = null, float? quantityAviable = null, DateTime? dueDate = null, int? idPrescription = null)
        {
            Medicines newMedicines = await _medicineRepository.GetMedicines(medicineId);
            if (newMedicines == null)
            {
                return null;
            }
            else
            {
                if (medicineName != null)
                {
                    newMedicines.MedicineName = medicineName;
                }
                if (quantityAviable != null)
                {
                    newMedicines.QuantityAvaiable = (float)quantityAviable;
                }
                if (dueDate != null)
                {
                    newMedicines.DueDate = dueDate;
                }
            }
            return await _medicineRepository.UpdateMedicines(newMedicines);
        }
    }
}