using HospitalGests.Model;
using HospitalGests.Repositories;

namespace HospitalGests.Services
{
    public interface IStockmedicinesService
    {
        Task<List<Stockmedicines>> GetAll();
        Task<Stockmedicines> GetStockmedicines(int idstock);
        Task<Stockmedicines> CreateStockmedicines(int medicineId, int idPharmacy, int stockquantity, DateOnly lastupdate);
        Task<Stockmedicines> UpdateStockmedicines(int idstock, int medicineId, int idPharmacy, int? stockquantity=null, DateOnly? lastupdate=null);
        Task<Stockmedicines> DeleteStockmedicines(int idstock);
    }


    public class StockmedicinesService : IStockmedicinesService

    {
        public readonly IStockmedicinesRepository _stockmedicinesRepository;

        public StockmedicinesService(IStockmedicinesRepository stockmedicinesRepository)
        {
            _stockmedicinesRepository = stockmedicinesRepository;
        }

        public async Task<Stockmedicines> CreateStockmedicines(int medicineId, int idPharmacy, int stockquantity, DateOnly lastupdate)
        {
            return await _stockmedicinesRepository.CreateStockmedicines(medicineId,  idPharmacy,  stockquantity,  lastupdate);
        }

        public async Task<Stockmedicines> DeleteStockmedicines(int idstock)
        {
            return await (_stockmedicinesRepository.DeleteStockmedicines(idstock));
        }

        public async Task<List<Stockmedicines>> GetAll()
        {
            return await _stockmedicinesRepository.GetAll();
        }

        public async Task<Stockmedicines> GetStockmedicines(int idstock)
        {
            return await _stockmedicinesRepository.GetStockmedicines(idstock);
        }

        public async Task<Stockmedicines> UpdateStockmedicines(int idstock, int medicineId, int idPharmacy, int? stockquantity = null, DateOnly? lastupdate = null)
        {
            Stockmedicines newStockmedicines = await _stockmedicinesRepository.GetStockmedicines(idstock);
            if (newStockmedicines == null)
            {
                return null;
            }
            else
            {
                if (stockquantity != null)
                {
                    newStockmedicines.Stockquantity = (int)stockquantity;
                }
                if (lastupdate != null)
                {
                    newStockmedicines.Lastupdate = (DateOnly)lastupdate;
                }
            }

            return await _stockmedicinesRepository.UpdateStockmedicines(newStockmedicines);
        }

    }
}
