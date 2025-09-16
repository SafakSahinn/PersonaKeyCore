using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonaKeyCore.EntityLayer.Concrete;

namespace PersonaKeyCore.BusinessLogicLayer.Services.Abstract
{
    public interface IAccessLogService
    {
        Task AddAsync(AccessLog accessLog);
        Task UpdateAsync(AccessLog accessLog);
        Task DeleteAsync(AccessLog accessLog);
        Task<List<AccessLog>> GetAllAsync();
        Task<AccessLog> GetByIdAsync(int id);
    }
}
