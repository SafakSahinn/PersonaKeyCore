using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonaKeyCore.EntityLayer.Concrete;

namespace PersonaKeyCore.BusinessLogicLayer.Services.Abstract
{
    public interface IDoorService
    {
        Task AddAsync(Door door);
        Task UpdateAsync(Door door);
        Task DeleteAsync(Door door);
        Task<List<Door>> GetAllAsync();
        Task<Door> GetByIdAsync(int id);
    }
}
