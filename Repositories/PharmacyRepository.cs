using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace HospitalGests.Repositories
{

    public interface IPharmacyRepository
    {
        Task<List<Pharmacy>> GetAll();
        Task<Pharmacy> GetPharmacy(int IdPharmacy);
        Task<Pharmacy> CreatePharmacy(string pharmacyname, string direcction, string email, string phone, string others);
        Task<Pharmacy> UpdatePharmacy(Pharmacy pharmacy );
        Task<Pharmacy> DeletePharmacy(int IdPharacy);
    }

    public class PharmacyRepository: IPharmacyRepository
    {
        private readonly BaseDbContext _db;

        public PharmacyRepository(BaseDbContext db)
        {
            _db = db;
        }

        public async Task<List<Pharmacy>> GetAll()
        {
            return await _db.Pharmacies.ToListAsync();
        }

        public async Task<Pharmacy> GetPharmacy(int IdPharmacy)
        {
            return await _db.Pharmacies.FirstOrDefaultAsync(u => u.IdPharmacy == IdPharmacy);
        }

        public async Task<Pharmacy> CreatePharmacy(string pharmacyname, string direcction, string email, string phone, string others)
        {
            Pharmacy newPharmacy = new Pharmacy
            {
                Pharmacyname = pharmacyname,
                Direcction = direcction,
                Email = email,
                Phone = phone,
                Others = others,


            };

            await _db.Pharmacies.AddAsync(newPharmacy);
            await _db.SaveChangesAsync();

            return newPharmacy;
        }

        public async Task<Pharmacy> UpdatePharmacy(Pharmacy pharmacy)
        {
            _db.Pharmacies.Update(pharmacy);
            await _db.SaveChangesAsync();

            return pharmacy;
        }

        public async Task<Pharmacy> DeletePharmacy(int IdPharmacy)
        {
            Pharmacy pharmacy = await GetPharmacy(IdPharmacy);
            _db.Pharmacies.Remove(pharmacy);
            await _db.SaveChangesAsync();

            return pharmacy;
        }
    }
}
