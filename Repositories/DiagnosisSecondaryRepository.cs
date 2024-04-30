using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalGests.Repositories
{
    public interface IDiagnosisSecondaryRepository
    {
       Task<List<DiagnosisSecondary>> GetAll();
       Task<DiagnosisSecondary> GetDiagnosisSecondary(int diagnosisId);
       Task<DiagnosisSecondary> CreateDiagnosisSecondary(string diagnosisName, string diagnosisDescription, string diagnosisType, int medicarRecordId);
       Task<DiagnosisSecondary> UpdateDiagnosisSecondary(DiagnosisSecondary diagnosisSecondary);
       Task<DiagnosisSecondary> DeleteDiagnosisSecondary(int diagnosisId);
    }
    public class DiagnosisSecondaryRepository : IDiagnosisSecondaryRepository
    {
        private readonly BaseDbContext _db;
        public DiagnosisSecondaryRepository(BaseDbContext db)
        {
            _db = db;
        }
        public async Task<List<DiagnosisSecondary>> GetAll()
        {
            return await _db.DiagnosisSecondaries.ToListAsync();
        }
        public async Task<DiagnosisSecondary> GetDiagnosisSecondary(int diagnosisId)
        {
            return await _db.DiagnosisSecondaries.FirstOrDefaultAsync(u => u.DiagnosisId == diagnosisId);
        }
        public async Task<DiagnosisSecondary> CreateDiagnosisSecondary(string diagnosisName, string diagnosisDescription, string diagnosisType, int medicarRecordId)
        {
            DiagnosisSecondary newDiagnosisSecondary = new DiagnosisSecondary
            {
                DiagnosisName = diagnosisName,
                DiagnosisDescription = diagnosisDescription,
                DiagnosisType = diagnosisType,
                MedicalRecordId = medicarRecordId
                
            };
            await _db.DiagnosisSecondaries.AddAsync(newDiagnosisSecondary);
            await _db.SaveChangesAsync();
            return newDiagnosisSecondary;
        }
        public async Task<DiagnosisSecondary> UpdateDiagnosisSecondary(DiagnosisSecondary diagnosisSecondary)
        {
            _db.DiagnosisSecondaries.Update(diagnosisSecondary);
            await _db.SaveChangesAsync();
            return diagnosisSecondary;
        }
        public async Task<DiagnosisSecondary> DeleteDiagnosisSecondary(int diagnosisId)
        {
            DiagnosisSecondary diagnosisSecondary = await GetDiagnosisSecondary(diagnosisId);

            //diagnosisSecondary.IsDelete = true;

            _db.DiagnosisSecondaries.Update(diagnosisSecondary);
            await _db.SaveChangesAsync();
            return diagnosisSecondary;
        }
    }
}
