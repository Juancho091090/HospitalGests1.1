using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalGests.Repositories
{

    public interface IPrescriptionRepository
    {
        Task<List<Prescriptions>> GetAll();
        Task<Prescriptions> GetPrescriptions(int idPrescription);
        Task<Prescriptions> CreatePrescriptions(int medicalRecordId, int medicineId, string dose, string duration, DateOnly dateissue, string state);
        Task<Prescriptions> UpdatePrescriptions(Prescriptions prescriptions);
        Task<Prescriptions> DeletePrescriptions(int idPrescription);
    }

    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly BaseDbContext _db;

        public PrescriptionRepository(BaseDbContext db)
        {
            _db = db;
        }

        public async Task<List<Prescriptions>> GetAll()
        {
            return await _db.Prescriptions.ToListAsync();
        }

        public async Task<Prescriptions> GetPrescriptions(int idPrescription)
        {
            return await _db.Prescriptions.FirstOrDefaultAsync(u => u.IdPrescription == idPrescription);
        }

        public async Task<Prescriptions> CreatePrescriptions(int medicalRecordId, int medicineId, string dose, string duration, DateOnly dateissue, string state)
        {
            Prescriptions newPrescription = new Prescriptions
            {
                MedicalRecordId = medicalRecordId,
                MedicineId = medicineId,
                Dose = dose,
                Duration=duration,
                Dateissue=dateissue,
                State=state,

            };

            await _db.Prescriptions.AddAsync(newPrescription);
            await _db.SaveChangesAsync();

            return newPrescription;
        }

        public async Task<Prescriptions> UpdatePrescriptions(Prescriptions prescriptions)
        {
            _db.Prescriptions.Update(prescriptions);
            await _db.SaveChangesAsync();

            return prescriptions;
        }

        public async Task<Prescriptions> DeletePrescriptions(int idPrescription)
        {
            Prescriptions prescription = await GetPrescriptions(idPrescription);
            _db.Prescriptions.Remove(prescription);
            await _db.SaveChangesAsync();

            return prescription;
        }
    }
}
