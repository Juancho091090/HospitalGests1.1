using HospitalGests.Model;
using HospitalGests.Repositories;

namespace HospitalGests.Services
{

    public interface IAvailabityServices
    {
        Task<List<Availability>> GetAll();
        Task<Availability> GetAvailability(int AvailabilityId);
        Task<Availability> CreatAvailability(int doctorId, DateTime? startDateTime, DateTime? endDateTime);
        Task<Availability> DeleteAvailability(int AvailabilityId);
        Task<Availability> UpdateAvialability(int availabilityId, int doctorId, DateTime? startDateTime = null, DateTime? endDateTime = null);
    }
    public class AvailabityServices : IAvailabityServices
    { 

         public readonly IAvailabityRepository _availabityRepository;

        public AvailabityServices(IAvailabityRepository availabityRepository)
    {
            _availabityRepository = availabityRepository;
    }
    
        public async Task<Availability> CreatAvailability(int doctorId, DateTime? startDateTime, DateTime?endDateTime)
        {
            return await _availabityRepository.CreatAvailability(doctorId, startDateTime, endDateTime);
        }

        public async Task<Availability> DeleteAvailability(int AvailabilityId)
        {
            try
            {
                // Llama al método de eliminación del repositorio
                var deleteAvailability = await _availabityRepository.DeleteAvailability(AvailabilityId);
                return deleteAvailability;
            }
            catch (Exception ex)
            {
                // Maneja cualquier excepción y regresa null o lanza una nueva excepción según sea necesario
                throw new Exception("Error al eliminar la ubicación.", ex);
            }
        }

        public async Task<List<Availability>> GetAll()
        {
            return await _availabityRepository.GetAll();
        }

        public async Task<Availability> GetAvailability(int AvailabilityId)
        {
            return await _availabityRepository.GetAvailability(AvailabilityId);
        }

        public async Task<Availability> UpdateAvialability(int availabilityId, int doctorId, DateTime? startDateTime = null, DateTime? endDateTime = null)
        {
            Availability newavailability = await _availabityRepository.GetAvailability(availabilityId);

            if (newavailability == null)
            {

                return null;
                
            }
            else
            {
                if (startDateTime == null)
                {
                    newavailability.StartDateTime = (DateTime)startDateTime;
                }
                if (endDateTime == null)
                {
                    newavailability.EndDateTime = (DateTime)endDateTime;
                }
            }
            return await _availabityRepository.UpdateAvialability(newavailability);
        }
        
    }
}
