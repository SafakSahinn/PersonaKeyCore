using PersonaKeyCore.BusinessLogicLayer.Services.Abstract;
using PersonaKeyCore.DataAccessLayer.Repository.Abstract;
using PersonaKeyCore.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonaKeyCore.BusinessLogicLayer.Services.Concrete
{
    public class DoorManager : IDoorService
    {
        private readonly IGenericRepository<Door> _doorRepository;
        private readonly IGenericRepository<Permission> _permissionRepository;
        private readonly IGenericRepository<AccessLog> _accessLogRepository;
        private readonly IGenericRepository<Device> _deviceRepository; // Yeni eklenen repository

        public DoorManager(IGenericRepository<Door> doorRepository,
                           IGenericRepository<Permission> permissionRepository,
                           IGenericRepository<AccessLog> accessLogRepository,
                           IGenericRepository<Device> deviceRepository) // Constructor güncellendi
        {
            _doorRepository = doorRepository;
            _permissionRepository = permissionRepository;
            _accessLogRepository = accessLogRepository;
            _deviceRepository = deviceRepository; // Yeni repository ataması
        }

        public async Task AddAsync(Door door)
        {
            await _doorRepository.AddAsync(door);
        }

        public async Task DeleteAsync(Door door)
        {
            // İlgili Permission kayıtlarını bulup siliyoruz
            var permissionsToDelete = await _permissionRepository.GetAllAsync();
            foreach (var permission in permissionsToDelete.Where(p => p.DoorId == door.Id).ToList())
            {
                await _permissionRepository.DeleteAsync(permission);
            }

            // İlgili AccessLog kayıtlarını bulup siliyoruz
            var logsToDelete = await _accessLogRepository.GetAllAsync();
            foreach (var log in logsToDelete.Where(l => l.DoorId == door.Id).ToList())
            {
                await _accessLogRepository.DeleteAsync(log);
            }

            // İlgili Device kayıtlarını bulup siliyoruz
            var devicesToDelete = await _deviceRepository.GetAllAsync();
            foreach (var device in devicesToDelete.Where(d => d.DoorId == door.Id).ToList())
            {
                await _deviceRepository.DeleteAsync(device);
            }

            // En son Door entity'sini siliyoruz
            await _doorRepository.DeleteAsync(door);
        }

        public async Task<List<Door>> GetAllAsync()
        {
            return await _doorRepository.GetAllAsync();
        }

        public async Task<Door> GetByIdAsync(int id)
        {
            return await _doorRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Door door)
        {
            await _doorRepository.UpdateAsync(door);
        }
    }
}