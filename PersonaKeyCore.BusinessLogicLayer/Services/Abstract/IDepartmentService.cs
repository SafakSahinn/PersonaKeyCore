using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonaKeyCore.EntityLayer.Concrete;

namespace PersonaKeyCore.BusinessLogicLayer.Services.Abstract
{
    public interface IDepartmentService
    {
        Task AddAsync(Department department);
        Task UpdateAsync(Department department);
        Task DeleteAsync(Department department);
        Task<List<Department>> GetAllAsync();
        Task<Department> GetByIdAsync(int id);
    }
}
