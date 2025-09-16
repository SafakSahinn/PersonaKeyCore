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
    public class AppUserManager : IAppUserService
    {
        private readonly IGenericRepository<AppUser> _appUserRepository;

        public AppUserManager(IGenericRepository<AppUser> appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task AddAsync(AppUser user)
        {
            await _appUserRepository.AddAsync(user);
        }

        public async Task<AppUser> GetByIdAsync(int id)
        {
            // Identity'nin Id'si string olduğu için bu metodun adaptasyonu gerekebilir
            // Ancak genel yapı bu şekilde kalabilir
            return await _appUserRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(AppUser user)
        {
            await _appUserRepository.UpdateAsync(user);

        }
        public async Task DeleteAsync(AppUser user)
        {
            await _appUserRepository.DeleteAsync(user);
        }

        public async Task<List<AppUser>> GetAllAsync()
        {
            return await _appUserRepository.GetAllAsync();
        }
    }
}
