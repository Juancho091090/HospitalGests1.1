using HospitalGests.Model;
using HospitalGests.Repositories;
using Microsoft.EntityFrameworkCore;
using static HospitalGests.Repositories.IPersonRepository;

namespace HospitalGests.Services
{
    public interface ISpecialitiesService
    {
        Task<List<Specialties>> GetAll();
        Task<Specialties> GetSpecialties(int specialitieId);
        Task<Specialties> CreateSpecialties(string specialitieName);
        Task<Specialties> UpdateSpecialties(int specialitieId, string? specialitieName = null);
        Task<Specialties> DeleteSpecialties(int specialitieId);

        public class SpecialitiesService : ISpecialitiesService
        {
            private readonly ISpecialityRepository _specialityRepository;

            public SpecialitiesService(ISpecialityRepository specialtiesRepository)
            {
                _specialityRepository = specialtiesRepository;
            }
            public async Task<Specialties> CreateSpecialties(string specialitieName)
            {
                return await _specialityRepository.CreateSpecialties(specialitieName);
            }

            public async Task<Specialties> DeleteSpecialties(int specialitieId)
            {
                return await (_specialityRepository.DeleteSpecialties(specialitieId));
            }

            public Task<List<Specialties>> GetAll()
            {
                return _specialityRepository.GetAll();
            }

            public async Task<Specialties> GetSpecialties(int specialitieId)
            {
                return await _specialityRepository.GetSpecialties(specialitieId);
            }

            public async Task<Specialties> UpdateSpecialties(int specialitieId, string? specialitieName = null)
            {
                Specialties newSpecialties = await _specialityRepository.GetSpecialties(specialitieId);
                if (newSpecialties != null)
                {
                    if (specialitieName != null)
                    {
                        newSpecialties.SpecialitieName = specialitieName;
                    }
                }
                return await _specialityRepository.UpdateSpecialties(newSpecialties);
            }
        }
    }
}