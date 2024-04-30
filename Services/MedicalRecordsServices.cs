using HospitalGests.Model;
using HospitalGests.Repositories;

namespace HospitalGests.Services
{
    public interface IMedicalRecordsServices
    {
        Task<List<MedicalRecords>> GetAll();
        Task<MedicalRecords> GetMedicalRecords(int medicalRecordId);
        Task<MedicalRecords> CreateMedicalRecords(int patientID, DateTime? admissionDate, DateTime? dischargeDate, string diagnosisPrincipal);
        Task<MedicalRecords> UpdateMedicalRecords(int medicalRecordId, int patientID, DateTime? admissionDate = null, DateTime? dischargeDate = null, string? diagnosisPrincipal = null);
        Task<MedicalRecords> DeleteMedicalRecords(int medicalRecordId);
    }
    public class MedicalRecordsServices : IMedicalRecordsServices
    {
        public readonly IMedicalRecordsRepository _medicalRecordsRepository;

        public MedicalRecordsServices(IMedicalRecordsRepository medicalRecordsRepository)
        {
            _medicalRecordsRepository = medicalRecordsRepository;
        }
        public async Task<MedicalRecords> CreateMedicalRecords(int patientID, DateTime? admissionDate, DateTime? dischargeDate, string diagnosisPrincipal)
        {
            return await _medicalRecordsRepository.CreateMedicalRecords(patientID, admissionDate, dischargeDate, diagnosisPrincipal);
        }

        public async Task<MedicalRecords> DeleteMedicalRecords(int medicalRecordId)
        {
            return await (_medicalRecordsRepository.DeleteMedicalRecords(medicalRecordId));
        }

        public Task<List<MedicalRecords>> GetAll()
        {
            return _medicalRecordsRepository.GetAll();
        }

        public Task<MedicalRecords> GetMedicalRecords(int medicalRecordId)
        {
            return _medicalRecordsRepository.GetMedicalRecords(medicalRecordId);
        }

        public async Task<MedicalRecords> UpdateMedicalRecords(int medicalRecordId, int patientID, DateTime? admissionDate = null, DateTime? dischargeDate = null, string? diagnosisPrincipal = null)
        {
            MedicalRecords newmedicalRecords = await _medicalRecordsRepository.GetMedicalRecords(medicalRecordId);
            if (newmedicalRecords == null)
            {
                return null;
            }
            else
            {
                if(admissionDate == null)
                {
                   newmedicalRecords.AdmissionDate = admissionDate;
                }
                if(dischargeDate == null)
                {
                    newmedicalRecords.DischargeDate = dischargeDate;
                }
                if (diagnosisPrincipal != null)
                {
                    newmedicalRecords.DiagnosisPrincipal = diagnosisPrincipal;
                }
            }
            return await _medicalRecordsRepository.UpdateMedicalRecords(newmedicalRecords);
        }
    }
}

