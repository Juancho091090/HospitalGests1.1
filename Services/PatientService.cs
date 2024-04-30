using HospitalGests.Model;
using HospitalGests.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace HospitalGests.Services
{
    public interface IPatientService
    {
        Task<List<Patients>> GetAll();
        Task<Patients> GetPatients(int patientId);
        Task<Patients> CreatePatients(int IdPerson);
        Task<Patients> UpdatePatients(int patientId, int IdPerson );
        Task<Patients> DeletePatients(int patientId);
    }
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Patients> CreatePatients(int IdPerson)
        {
            return await _patientRepository.CreatePatients(IdPerson);
        }

        public async Task<Patients> DeletePatients(int patientId)
        {
            return await (_patientRepository.DeletePatients(patientId));
        }

        public async Task<List<Patients>> GetAll()
        {
            return await _patientRepository.GetAll();
        }

        public async Task<Patients> GetPatients(int patientId)
        {
            return await (_patientRepository.GetPatients(patientId));
        }

        public async Task<Patients> UpdatePatients(int patientId, int IdPerson)
        {
            Patients newPatients = await _patientRepository.GetPatients(patientId);
            if (newPatients != null)
            {
                return await _patientRepository.UpdatePatients(newPatients);

            }
            return null;
        }
    }
}
