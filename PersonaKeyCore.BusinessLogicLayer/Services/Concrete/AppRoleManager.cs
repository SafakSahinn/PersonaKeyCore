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
    public class AppRoleManager : IAppRoleService
    {
        private readonly IGenericRepository<AppRole> _appRoleRepository;

        public AppRoleManager(IGenericRepository<AppRole> appRoleRepository)
        {
            _appRoleRepository = appRoleRepository;
        }
        public async Task AddAsync(AppRole role)
        {
            await _appRoleRepository.AddAsync(role);
        }

        public async Task<AppRole> GetByIdAsync(int id)
        {
            // Identity'nin Id'si string olduğu için bu metodun adaptasyonu gerekebilir
            return await _appRoleRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(AppRole role)
        {
            await _appRoleRepository.UpdateAsync(role);
        }

        public async Task DeleteAsync(AppRole role)
        {
            await _appRoleRepository.DeleteAsync(role);
        }

        public async Task<List<AppRole>> GetAllAsync()
        {
            return await _appRoleRepository.GetAllAsync();
        }
    }
}
