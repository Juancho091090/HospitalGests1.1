using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalGests.Repositories
{

    public interface IMedicationdeliveryRepository
    {
        Task<List<Medicationdelivery>> GetAll();
        Task<Medicationdelivery> GetMedicationdelivery(int IdDelivery);
        Task<Medicationdelivery> CreateMedicationdelivery(int idPrescription, int idPharmacy, DateTime deliDaTe, string deliveredQuantity, string state);
        Task<Medicationdelivery> UpdateMedicationdelivery(Medicationdelivery medicationdelivery);
        Task<Medicationdelivery> DeleteMedicationdelivery(int IdDelivery);
    }

    public class MedicationdeliveryRepository : IMedicationdeliveryRepository
    {
        private readonly BaseDbContext _db;

        public MedicationdeliveryRepository(BaseDbContext db)
        {
            _db = db;
        }

        public async Task<List<Medicationdelivery>> GetAll()
        {
            return await _db.Medicationdelivery.ToListAsync();
        }

        public async Task<Medicationdelivery> GetMedicationdelivery(int IdDelivery)
        {
            return await _db.Medicationdelivery.FirstOrDefaultAsync(u => u.IdDelivery == IdDelivery);
        }

        public async Task<Medicationdelivery> CreateMedicationdelivery(int idPrescription, int idPharmacy, DateTime deliDaTe, string deliveredQuantity, string state)
        {
            Medicationdelivery newMedicationdelivery = new Medicationdelivery
            {
                IdPrescription = idPrescription,
                IdPharmacy = idPharmacy,
                DeliDaTe = deliDaTe,
                DeliveredQuantity = deliveredQuantity,
                State= state,
            };

            await _db.Medicationdelivery.AddAsync(newMedicationdelivery);
            await _db.SaveChangesAsync();

            return newMedicationdelivery;
        }

        public async Task<Medicationdelivery> UpdateMedicationdelivery(Medicationdelivery medicationdelivery)
        {
            _db.Medicationdelivery.Update(medicationdelivery);
            await _db.SaveChangesAsync();

            return medicationdelivery;
        }

        public async Task<Medicationdelivery> DeleteMedicationdelivery(int IdDelivery)
        {
            Medicationdelivery medicationdelivery = await GetMedicationdelivery(IdDelivery);
            _db.Medicationdelivery.Remove(medicationdelivery);
            await _db.SaveChangesAsync();

            return medicationdelivery;
        }
    }
}

