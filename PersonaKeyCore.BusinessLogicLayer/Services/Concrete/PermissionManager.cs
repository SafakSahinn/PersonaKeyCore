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
    public class PermissionManager : IPermissionService
    {
        private readonly IGenericRepository<Permission> _permissionRepository;

        public PermissionManager(IGenericRepository<Permission> permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }
        public async Task AddAsync(Permission permission)
        {
            await _permissionRepository.AddAsync(permission);
        }

        public async Task<Permission> GetByIdAsync(int id)
        {
            return await _permissionRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Permission permission)
        {
            await _permissionRepository.UpdateAsync(permission);
        }

        public async Task DeleteAsync(Permission permission)
        {
            await _permissionRepository.DeleteAsync(permission);
        }

        public async Task<List<Permission>> GetAllAsync()
        {
            return await _permissionRepository.GetAllAsync();
        }
    }
}
