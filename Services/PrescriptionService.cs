using HospitalGests.Model;
using HospitalGests.Repositories;

namespace HospitalGests.Services
{
    public interface IPrescriptionService
    {
        Task<List<Prescriptions>> GetAll();
        Task<Prescriptions> GetPrescriptions(int idPrescription);
        Task<Prescriptions> CreatePrescriptions(int medicalRecordId, int medicineId, string dose, string duration, DateOnly dateissue, string state);
        Task<Prescriptions> UpdatePrescriptions(int idPrescription, int medicalRecordId, int? medicineId = null, string? dose=null, string? duration=null, DateOnly? dateissue=null, string? state=null);
        Task<Prescriptions> DeletePrescriptions(int idPrescription);
    }


        public class PrescriptionService : IPrescriptionService

    {
        public readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }

        public async Task<Prescriptions> CreatePrescriptions(int medicalRecordId, int medicineId, string dose, string duration, DateOnly dateissue, string state)
        {
            return await _prescriptionRepository.CreatePrescriptions(medicalRecordId, medicineId, dose, duration, dateissue, state);
        }

        public async Task<Prescriptions> DeletePrescriptions(int idPrescription)
        {
            return await (_prescriptionRepository.DeletePrescriptions(idPrescription));
        }

        public async Task<List<Prescriptions>> GetAll()
        {
            return await _prescriptionRepository.GetAll();
        }

        public async Task<Prescriptions> GetPrescriptions(int idPrescription)
        {
            return await _prescriptionRepository.GetPrescriptions(idPrescription);
        }

        public async Task<Prescriptions> UpdatePrescriptions(int idPrescription, int medicalRecordId, int? medicineId = null, string? dose = null, string? duration = null, DateOnly? dateissue = null, string? state = null)
        {
            Prescriptions newPrescriptions = await _prescriptionRepository.GetPrescriptions(idPrescription);
            if (newPrescriptions == null)
            {
                return null;
            }
            else
            {
                if (dose != null)
                {
                    newPrescriptions.Dose = dose;
                }
                if (duration != null)
                {
                    newPrescriptions.Duration = duration;
                }
                if (dateissue != null)
                {
                    newPrescriptions.Dateissue = (DateOnly)dateissue;
                }
                if (state != null)
                {
                    newPrescriptions.State = state;
                }
            }

            return await _prescriptionRepository.UpdatePrescriptions(newPrescriptions);
        }

    }
}


