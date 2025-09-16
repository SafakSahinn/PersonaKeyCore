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
    public class DoorManager : IDoorService
    {
        private readonly IGenericRepository<Door> _doorRepository;

        public DoorManager(IGenericRepository<Door> doorRepository)
        {
            _doorRepository = doorRepository;
        }

        public async Task AddAsync(Door door)
        {
            await _doorRepository.AddAsync(door);
        }

        public async Task DeleteAsync(Door door)
        {
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
