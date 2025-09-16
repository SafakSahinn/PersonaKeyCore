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
    public class RoleManager : IRoleService
    {
        private readonly IGenericRepository<Role> _roleRepository;

        public RoleManager(IGenericRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task AddAsync(Role role)
        {
            await _roleRepository.AddAsync(role);
        }

        public async Task<Role> GetByIdAsync(int id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Role role)
        {
            await _roleRepository.UpdateAsync(role);
        }

        public async Task DeleteAsync(Role role)
        {
            await _roleRepository.DeleteAsync(role);
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await _roleRepository.GetAllAsync();
        }
    }
}
