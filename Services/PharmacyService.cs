using HospitalGests.Model;
using HospitalGests.Repositories;

namespace HospitalGests.Services
{
    public interface IPharmacyService
    {

        Task<List<Pharmacy>> GetAll();
        Task<Pharmacy> GetPharmacy(int IdPharmacy);
        Task<Pharmacy> CreatePharmacy(string pharmacyname, string direcction, string email, string phone, string others);
        Task<Pharmacy> UpdatePharmacy(int idPharmacy, string? pharmacyname = null, string? direcction = null, string? email = null, string? phone = null, string? others = null);
        Task<Pharmacy> DeletePharmacy(int IdPharacy);
    }
    public class PharmacyService : IPharmacyService

    {
        public readonly IPharmacyRepository _pharmacyRepository;
        public PharmacyService(IPharmacyRepository pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }

        public async Task<Pharmacy> CreatePharmacy(string pharmacyname, string direcction, string email, string phone, string others)
        {
            return await _pharmacyRepository.CreatePharmacy(pharmacyname, direcction, email, phone, others);
        }

        public async Task<Pharmacy> DeletePharmacy(int IdPharmacy)
        {
            return await (_pharmacyRepository.DeletePharmacy(IdPharmacy));
        }

        public async Task<List<Pharmacy>> GetAll()
        {
            return await _pharmacyRepository.GetAll();
        }

        public async Task<Pharmacy> GetPharmacy(int IdPharmacy)
        {
            return await _pharmacyRepository.GetPharmacy(IdPharmacy);
        }

        public async Task<Pharmacy> UpdatePharmacy(int idPharmacy, string? pharmacyname = null, string? direcction = null, string? email = null, string? phone = null, string? others = null)
        {
            Pharmacy newPharmacy = await _pharmacyRepository.GetPharmacy(idPharmacy);
            if (newPharmacy == null)
            {
                return null;
            }
            else
            {
                if (pharmacyname != null)
                {
                    newPharmacy.Pharmacyname = pharmacyname;
                }
                if (direcction != null)
                {
                    newPharmacy.Direcction = direcction;
                }
                if (email != null)
                {
                    newPharmacy.Email = email;
                }

                if (phone != null)
                {
                    newPharmacy.Phone = phone;
                }
                if (others != null)
                {
                    newPharmacy.Others = others;
                }
            }

            return await _pharmacyRepository.UpdatePharmacy(newPharmacy);
        }

    }
}