using HospitalGests.Context;
using HospitalGests.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalGests.Repositories
{
    public interface IDepartmentsRepository
    {
        Task<List<Departments>> GetAll();
        Task<Departments> GetDepartment(int department_ID);
        Task<Departments> CreateDepartment(string name, string description);
        Task<Departments> UpdateDepartment(Departments department);
        Task<Departments> DeleteDepartment(int Department_ID);
    }

    public class DepartmentsRepository : IDepartmentsRepository
    {
        private readonly BaseDbContext _db;

        public DepartmentsRepository(BaseDbContext db)
        {
            _db = db;
        }

        public async Task<List<Departments>> GetAll()
        {
            return await _db.Departments.ToListAsync();
        }

        public async Task<Departments> GetDepartment(int departmentId)
        {
            return await _db.Departments.FirstOrDefaultAsync(d => d.Department_Id == departmentId);
        }

        public async Task<Departments> CreateDepartment(string name, string description)
        {
            Departments newDepartment = new Departments
            {
                DepartmentName = name,
                Description = description
            };

            await _db.Departments.AddAsync(newDepartment);
            await _db.SaveChangesAsync();

            return newDepartment;
        }

        public async Task<Departments> UpdateDepartment(Departments department)
        {
            _db.Departments.Update(department);
            await _db.SaveChangesAsync();

            return department;
        }

        public async Task<Departments> DeleteDepartment(int departmentId)
        {
            Departments department = await GetDepartment(departmentId);
            _db.Departments.Update(department);
            await _db.SaveChangesAsync();

            return department;
        }
    }
}

