using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonaKeyCore.BusinessLogicLayer.Services.Abstract;
using PersonaKeyCore.DataAccessLayer.Repository.Abstract;
using PersonaKeyCore.EntityLayer.Concrete;

namespace PersonaKeyCore.BusinessLogicLayer.Services.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IGenericRepository<Department> _departmentRepository;

        public DepartmentManager(IGenericRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task AddAsync(Department department)
        {
            await _departmentRepository.AddAsync(department);
        }

        public async Task DeleteAsync(Department department)
        {
            await _departmentRepository.DeleteAsync(department);
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _departmentRepository.GetAllAsync();
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            return await _departmentRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Department department)
        {
            await _departmentRepository.UpdateAsync(department);
        }
    }
}
