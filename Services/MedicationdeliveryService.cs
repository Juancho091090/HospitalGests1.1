using HospitalGests.Model;
using HospitalGests.Repositories;

namespace HospitalGests.Services
{
    public interface IMedicationdeliveryService
    {
        Task<List<Medicationdelivery>> GetAll();
        Task<Medicationdelivery> GetMedicationdelivery(int IdDelivery);
        Task<Medicationdelivery> CreateMedicationdelivery(int idPrescription, int idPharmacy, DateTime deliDaTe, string deliveredQuantity, string state);
        Task<Medicationdelivery> UpdateMedicationdelivery(int iddelivery, int idPrescription, int idPharmacy, DateTime? deliDaTi=null, string? deliveredQuantity=null, string? state=null);
        Task<Medicationdelivery> DeleteMedicationdelivery(int IdDelivery);
    }


        public class MedicationdeliveryService : IMedicationdeliveryService

    {
        public readonly IMedicationdeliveryRepository _medicationdeliveryRepository;

        public MedicationdeliveryService(IMedicationdeliveryRepository medicationdeliveryRepository)
        {
            _medicationdeliveryRepository = medicationdeliveryRepository;
        }

        public async Task<Medicationdelivery> CreateMedicationdelivery(int idPrescription, int idPharmacy, DateTime deliDaTe, string deliveredQuantity, string state)
        {
            return await _medicationdeliveryRepository.CreateMedicationdelivery(idPrescription,  idPharmacy, deliDaTe,  deliveredQuantity,  state);
        }

        public async Task<Medicationdelivery> DeleteMedicationdelivery(int IdDelivery)
        {
            return await (_medicationdeliveryRepository.DeleteMedicationdelivery(IdDelivery));
        }

        public async Task<List<Medicationdelivery>> GetAll()
        {
            return await _medicationdeliveryRepository.GetAll();
        }

        public async Task<Medicationdelivery> GetMedicationdelivery(int IdDelivery)
        {
            return await _medicationdeliveryRepository.GetMedicationdelivery(IdDelivery);
        }

        public async Task<Medicationdelivery> UpdateMedicationdelivery(int IdDelivery, int idPrescription, int idPharmacy, DateTime? deliDaTe = null, string? deliveredQuantity = null, string? state = null)
        {
            Medicationdelivery newMedicationdelivery = await _medicationdeliveryRepository.GetMedicationdelivery(IdDelivery);
            if (newMedicationdelivery == null)
            {
                return null;
            }
            else
            {
                if (deliDaTe != null)
                {
                    newMedicationdelivery.DeliDaTe = (DateTime)deliDaTe;
                }
                if (deliveredQuantity != null)
                {
                    newMedicationdelivery.DeliveredQuantity = deliveredQuantity;
                }
                if (state != null)
                {
                    newMedicationdelivery.State = state;
                }
               
            }
            return await _medicationdeliveryRepository.UpdateMedicationdelivery(newMedicationdelivery);
        }

    }
}

