using HospitalGests.Model;
using HospitalGests.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalGests.Services
{
    public interface IDepartmentService
    {
        Task<List<Departments>> GetAll();
        Task<Departments> GetDepartment(int department_ID);
        Task<Departments> CreateDepartment(string name, string description);
        Task<Departments> UpdateDepartment(int department_ID, string? name = null, string? description=null);
        Task<Departments> DeleteDepartment(int department_ID);
    }

    public class DepartmentsService : IDepartmentService
    {
        private readonly IDepartmentsRepository _departmentsRepository;

        public DepartmentsService(IDepartmentsRepository departmentsRepository)
        {
            _departmentsRepository = departmentsRepository;
        }

        public async Task<Departments> CreateDepartment(string name, string description)
        {
            return await _departmentsRepository.CreateDepartment(name, description);
        }

        public async Task<Departments> DeleteDepartment(int department_ID)
        {
            return await (_departmentsRepository.DeleteDepartment(department_ID));
        }

        public Task<List<Departments>> GetAll()
        {
            return _departmentsRepository.GetAll();
        }

        public async Task<Departments> GetDepartment(int department_ID)
        {
            return await _departmentsRepository.GetDepartment(department_ID);
        }

        public async Task<Departments> UpdateDepartment(int department_ID, string? name = null, string? description = null)
        {
           Departments newDepartments = await _departmentsRepository.GetDepartment(department_ID);
            if (newDepartments == null)
            {
                return null;
            }
            else
            {
                if (name != null)
                {
                    newDepartments.DepartmentName = name; 
                }
                if(description != null)
                {
                    newDepartments.Description = description;
                }
            }
            return await _departmentsRepository.UpdateDepartment(newDepartments);
        }

    }
}
