using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonaKeyCore.EntityLayer.Concrete;

namespace PersonaKeyCore.BusinessLogicLayer.Services.Abstract
{
    public interface IDeviceService
    {
        Task AddAsync(Device device);
        Task UpdateAsync(Device device);
        Task DeleteAsync(Device device);
        Task<List<Device>> GetAllAsync();
        Task<Device> GetByIdAsync(int id);
    }
}
