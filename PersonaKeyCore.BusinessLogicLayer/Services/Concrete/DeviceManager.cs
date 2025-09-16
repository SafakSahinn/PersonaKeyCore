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
    public class DeviceManager : IDeviceService
    {
        private readonly IGenericRepository<Device> _deviceRepository;

        public DeviceManager(IGenericRepository<Device> deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }
        public async Task AddAsync(Device device)
        {
            await _deviceRepository.AddAsync(device);
        }

        public async Task<Device> GetByIdAsync(int id)
        {
            return await _deviceRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Device device)
        {
            await _deviceRepository.UpdateAsync(device);
        }

        public async Task DeleteAsync(Device device)
        {
            await _deviceRepository.DeleteAsync(device);
        }

        public async Task<List<Device>> GetAllAsync()
        {
            return await _deviceRepository.GetAllAsync();
        }
    }
}
