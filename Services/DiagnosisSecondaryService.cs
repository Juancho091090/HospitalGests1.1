using HospitalGests.Model;
using HospitalGests.Repositories;

namespace HospitalGests.Services
{
   
    public interface IDiagnosisSecondaryService
    {
        Task<List<DiagnosisSecondary>> GetAll();
        Task<DiagnosisSecondary> GetDiagnosisSecondary(int diagnosisId);
        Task<DiagnosisSecondary> CreateDiagnosisSecondary(string diagnosisName, string diagnosisDescription, string diagnosisType, int medicarRecordId);
        Task<DiagnosisSecondary> UpdateDiagnosisSecondary(int diagnosisId, string? diagnosisName = null, string? diagnosisDescription = null, string? diagnosisType = null, int? medicarRecordId = null);
        Task<DiagnosisSecondary> DeleteDiagnosisSecondary(int DiagnosisId);
    }

    public class DiagnosisSecondaryService : IDiagnosisSecondaryService
    {
        private readonly IDiagnosisSecondaryRepository _diagnosisSecondaryRepository;

        public DiagnosisSecondaryService(IDiagnosisSecondaryRepository diagnosisSecondaryRepository)
        {
            _diagnosisSecondaryRepository = diagnosisSecondaryRepository;
        }
        public async Task<DiagnosisSecondary> CreateDiagnosisSecondary(string diagnosisName, string diagnosisDescription, string diagnosisType, int medicarRecordId)
        {
           return await _diagnosisSecondaryRepository.CreateDiagnosisSecondary(diagnosisName, diagnosisDescription, diagnosisType, medicarRecordId);
        }

        public async Task<DiagnosisSecondary> DeleteDiagnosisSecondary(int DiagnosisId)
        {
            return await (_diagnosisSecondaryRepository.DeleteDiagnosisSecondary(DiagnosisId));
        }

        public Task<List<DiagnosisSecondary>> GetAll()
        {
            return _diagnosisSecondaryRepository.GetAll();
        }

        public Task<DiagnosisSecondary> GetDiagnosisSecondary(int diagnosisId)
        {
            return _diagnosisSecondaryRepository.GetDiagnosisSecondary(diagnosisId);
        }

        public async Task<DiagnosisSecondary> UpdateDiagnosisSecondary(int diagnosisId, string? diagnosisName = null, string? diagnosisDescription = null, string? diagnosisType = null, int? medicarRecordId = null)
        {
            DiagnosisSecondary newdiagnosisSecondary = await _diagnosisSecondaryRepository.GetDiagnosisSecondary(diagnosisId);
            if (newdiagnosisSecondary == null)
            {
                return null;
            }
            else
            {
                if(diagnosisName != null)
                {
                    newdiagnosisSecondary.DiagnosisName = diagnosisName;
                }
                if(diagnosisDescription != null)
                {
                    newdiagnosisSecondary.DiagnosisDescription = diagnosisDescription;
                }
                if (diagnosisType != null)
                {
                    newdiagnosisSecondary.DiagnosisType = diagnosisType;    
                }
            }
            return await _diagnosisSecondaryRepository.UpdateDiagnosisSecondary(newdiagnosisSecondary);
        }
    }
}
