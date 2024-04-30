using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalGests.Repositories
{
    public interface ITreatmentRepository
    {
        Task<List<Treatments>> GetAll();
        Task<Treatments> GetTreatments(int treatmentId);
        Task<Treatments> CreateTreatments(int medicalRecordID, string treatmentType, string dosage);
        Task<Treatments> UpdateTreatments(Treatments treatments);
        Task<Treatments> DeleteTreatments(int treatmentId);
    }
    public class TreatmentsRepository : ITreatmentRepository
    {
        private readonly BaseDbContext _db;
        public TreatmentsRepository(BaseDbContext db)
        {
            _db = db;
        }
        public async Task<List<Treatments>> GetAll()
        {
            return await _db.Treatments.ToListAsync();
        }
        public async Task<Treatments> GetTreatments(int treatmentId)
        {
            return await _db.Treatments.FirstOrDefaultAsync(u => u.TreatmentId == treatmentId);
        }
        public async Task<Treatments> CreateTreatments(int medicalRecordID, string treatmentType, string dosage)
        {
            Treatments newTreatment = new Treatments
            {
                MedicalRecordID = medicalRecordID,
                TreatmentType = treatmentType,
                Dosage = dosage
            };
            await _db.Treatments.AddAsync(newTreatment);
            await _db.SaveChangesAsync();

            return newTreatment;
        }
        public async Task<Treatments> UpdateTreatments(Treatments treatments)
        {
            _db.Treatments.Update(treatments);
            await _db.SaveChangesAsync();
            return treatments;
        }
        public async Task<Treatments> DeleteTreatments(int treatmentId)
        {
            Treatments treatments = await GetTreatments(treatmentId);

            _db.Treatments.Update(treatments);
            await _db.SaveChangesAsync();
            return treatments;
        }
    }
}