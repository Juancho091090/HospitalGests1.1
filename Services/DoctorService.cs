using HospitalGests.Model;
using HospitalGests.Repositories;

namespace HospitalGests.Services
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetAll();
        Task<Doctor> GetDoctor(int doctorId);
        Task<Doctor> CreateDoctor(int idPerson, int specialitieId, string observations);
        Task<Doctor> UpdateDoctor(int doctor_Id, int idPerson, int? specialitieId = null, string? observations = null);
        Task<Doctor> DeleteDoctor(int doctorId);
    }

    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<List<Doctor>> GetAll()
        {
            return await _doctorRepository.GetAll();
        }

        public async Task<Doctor> GetDoctor(int doctorId)
        {
            return await _doctorRepository.GetDoctor(doctorId);
        }

        public async Task<Doctor> CreateDoctor(int idPerson, int specialitieId, string observations)
        {
            return await _doctorRepository.CreateDoctor(idPerson,  specialitieId, observations);
        }

        public async Task<Doctor> UpdateDoctor(int doctor_Id, int idPerson,  int? specialitieId = null,  string? observations = null)
        {
            Doctor newDoctor = await _doctorRepository.GetDoctor(doctor_Id);
            if (newDoctor == null)
            {
                return null;
            }
            else
            {            
                if (observations == null)
                {
                    newDoctor.Observations = observations;
                }
            }
            return await _doctorRepository.UpdateDoctor(newDoctor);

        }

        public async Task<Doctor> DeleteDoctor(int DoctorId)
        {
            return await (_doctorRepository.DeleteDoctor(DoctorId));
        }
    }
}
