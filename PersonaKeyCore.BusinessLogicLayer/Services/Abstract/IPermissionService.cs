using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonaKeyCore.EntityLayer.Concrete;

namespace PersonaKeyCore.BusinessLogicLayer.Services.Abstract
{
    public interface IPermissionService
    {
        Task AddAsync(Permission permission);
        Task UpdateAsync(Permission permission);
        Task DeleteAsync(Permission permission);
        Task<List<Permission>> GetAllAsync();
        Task<Permission> GetByIdAsync(int id);
    }
}
