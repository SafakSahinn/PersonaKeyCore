using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonaKeyCore.EntityLayer.Concrete;

namespace PersonaKeyCore.BusinessLogicLayer.Services.Abstract
{
    public interface IAppRoleService
    {
        Task AddAsync(AppRole role);
        Task UpdateAsync(AppRole role);
        Task DeleteAsync(AppRole role);
        Task<List<AppRole>> GetAllAsync();
        Task<AppRole> GetByIdAsync(int id);
    }
}
