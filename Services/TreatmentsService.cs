using HospitalGests.Model;
using HospitalGests.Repositories;

namespace HospitalGests.Services
{
    public interface ITreatmentsService
    {

        Task<List<Treatments>> GetAll();
        Task<Treatments> GetTreatments(int treatmentId);
        Task<Treatments> CreateTreatments(int medicalRecordID, string treatmentType, string dosage);
        Task<Treatments> UpdateTreatments(int treatmentId, int medicalRecordID, string? treatmentType = null, string? dosage = null);
        Task<Treatments> DeleteTreatments(int treatmentId);
    }
    public class TreatmentsService : ITreatmentsService

    {
        public readonly ITreatmentRepository _treatmentsRepository;
        public TreatmentsService(ITreatmentRepository treatmentsRepository)
        {
            _treatmentsRepository = treatmentsRepository;
        }

        public async Task<Treatments> CreateTreatments(int medicalRecordID, string treatmentType, string dosage)
        {
            return await _treatmentsRepository.CreateTreatments(medicalRecordID, treatmentType, dosage);
        }

        public async Task<Treatments> DeleteTreatments(int treatmentId)
        {
            return await (_treatmentsRepository.DeleteTreatments(treatmentId));
        }

        public async Task<List<Treatments>> GetAll()
        {
            return await _treatmentsRepository.GetAll();
        }

        public async Task<Treatments> GetTreatments(int treatmentId)
        {
            return await _treatmentsRepository.GetTreatments(treatmentId);
        }

        public async Task<Treatments> UpdateTreatments(int treatmentId, int medicalRecordID, string? treatmentType = null, string? dosage = null)
        {
            Treatments newTreatments = await _treatmentsRepository.GetTreatments(treatmentId);
            if (newTreatments == null)
            {
                return null;
            }
            else
            {
                if (treatmentType != null)
                {
                    newTreatments.TreatmentType = treatmentType;
                }
                if (dosage != null)
                {
                    newTreatments.Dosage = dosage;
                }
            }
            return await _treatmentsRepository.UpdateTreatments(newTreatments);
        }

    }
}
