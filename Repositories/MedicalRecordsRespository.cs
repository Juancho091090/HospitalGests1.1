using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HospitalGests.Repositories
{
    public interface IMedicalRecordsRepository
    {
        Task<List<MedicalRecords>> GetAll();
        Task<MedicalRecords> GetMedicalRecords(int medicalRecordId);
        Task<MedicalRecords> CreateMedicalRecords(int patientID, DateTime? admissionDate, DateTime? dischargeDate,string diagnosisPrincipal);
        Task<MedicalRecords> UpdateMedicalRecords(MedicalRecords medicalRecords);
        Task<MedicalRecords> DeleteMedicalRecords(int medicalRecordId);
    }
    public class MedicalRecordsRespository : IMedicalRecordsRepository
    {
        private readonly BaseDbContext _db;
        public MedicalRecordsRespository(BaseDbContext db)
        {
            _db = db;
        }
        public async Task<List<MedicalRecords>> GetAll()
        {
            return await _db.MedicalRecords.ToListAsync();
        }
        public async Task<MedicalRecords> GetMedicalRecords(int medicalRecordId)
        {
            return await _db.MedicalRecords.FirstOrDefaultAsync(u => u.MedicalRecordId == medicalRecordId);
        }
        public async Task<MedicalRecords> CreateMedicalRecords(int patientID, DateTime? admissionDate, DateTime? dischargeDate, string diagnosisPrincipal)
        {
            MedicalRecords newMedicalRecord = new MedicalRecords
            {
                PatientId = patientID,
                AdmissionDate = admissionDate,
                DischargeDate = dischargeDate,
                DiagnosisPrincipal = diagnosisPrincipal,          
            };
            await _db.MedicalRecords.AddAsync(newMedicalRecord);
            await _db.SaveChangesAsync();

            return newMedicalRecord;
        }
        public async Task<MedicalRecords> UpdateMedicalRecords(MedicalRecords medicalRecords)
        {
            _db.MedicalRecords.Update(medicalRecords);
            await _db.SaveChangesAsync();   
            return medicalRecords;
        }
        public async Task<MedicalRecords> DeleteMedicalRecords(int medicalRecordId)
        {
            MedicalRecords medicalRecords = await GetMedicalRecords(medicalRecordId);

            _db.MedicalRecords.Update(medicalRecords);
            await _db.SaveChangesAsync();
            return medicalRecords;
        }

    }
}
