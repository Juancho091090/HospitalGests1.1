using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace HospitalGests.Repositories
{

    public interface IStockmedicinesRepository
    {
        Task<List<Stockmedicines>> GetAll();
        Task<Stockmedicines> GetStockmedicines(int idstock);
        Task<Stockmedicines> CreateStockmedicines(int medicineId, int idPharmacy, int stockquantity, DateOnly lastupdate);
        Task<Stockmedicines> UpdateStockmedicines(Stockmedicines stockmedicines);
        Task<Stockmedicines> DeleteStockmedicines(int idstock);
    }

    public class StockmedicinesRepository : IStockmedicinesRepository
    {
        private readonly BaseDbContext _db;

        public StockmedicinesRepository(BaseDbContext db)
        {
            _db = db;
        }

        public async Task<List<Stockmedicines>> GetAll()
        {
            return await _db.Stockmedicines.ToListAsync();
        }

        public async Task<Stockmedicines> GetStockmedicines(int idstock)
        {
            return await _db.Stockmedicines.FirstOrDefaultAsync(u => u.Idstock == idstock);
        }

        public async Task<Stockmedicines> CreateStockmedicines(int medicineId, int idPharmacy, int stockquantity, DateOnly lastupdate)
        {
            Stockmedicines newStockmedicines = new Stockmedicines
            {
                MedicineId = medicineId,
                IdPharmacy = idPharmacy,
                Stockquantity = stockquantity,
                Lastupdate = lastupdate,
            };

            await _db.Stockmedicines.AddAsync(newStockmedicines);
            await _db.SaveChangesAsync();

            return newStockmedicines;
        }

        public async Task<Stockmedicines> UpdateStockmedicines(Stockmedicines stockmedicines)
        {
            _db.Stockmedicines.Update(stockmedicines);
            await _db.SaveChangesAsync();

            return stockmedicines;
        }

        public async Task<Stockmedicines> DeleteStockmedicines(int idstock)
        {
            Stockmedicines stockmedicines = await GetStockmedicines(idstock);
            _db.Stockmedicines.Remove(stockmedicines);
            await _db.SaveChangesAsync();

            return stockmedicines;
        }
    }
}
