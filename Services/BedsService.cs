using HospitalGests.Model;
using HospitalGests.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalGests.Services
{
    public interface IBedService
    {
        Task<List<Beds>> GetAll();
        Task<Beds> GetBeds(int Bed_ID);
        Task<Beds> CreateBeds(int Bed_ID, int patientId, int roomId, int stock);
        Task<Beds> UpdateBeds(int bed_ID, int patientId, int roomId, int stock);
        Task<Beds> DeleteBeds(int Bed_ID);
    }

    public class BedsService : IBedService
    {
        private readonly IBedsRepository _bedsRepository;

        public BedsService(IBedsRepository bedsRepository)
        {
            _bedsRepository = bedsRepository;
        }

        public async Task<Beds> CreateBeds(int Bed_ID, int patientId, int roomId, int stock)
        {
            return await _bedsRepository.CreateBeds(Bed_ID, patientId,  roomId,  stock);

        }

        public async Task<Beds> DeleteBeds(int Bed_ID)
        {
            return await (_bedsRepository.DeleteBeds(Bed_ID));
        }

        public async Task<List<Beds>> GetAll()
        {
            return await _bedsRepository.GetAll();
        }

        public async Task<Beds> GetBeds(int Bed_ID)
        {
            return await _bedsRepository.GetBeds(Bed_ID);
        }

        public async Task<Beds> UpdateBeds(int bed_ID, int patientId, int roomId, int stock)
        {
            Beds newBeds = await _bedsRepository.GetBeds(bed_ID);
            if (newBeds == null)
            {
                return null;
            }else
            {
                if (stock != null) 
                {
                    newBeds.Stock = (int)stock;
                }
             }
            return await _bedsRepository.UpdateBeds(newBeds);
        }
    }
}
