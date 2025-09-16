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
    public class RefreshTokenManager : IRefreshTokenService
    {
        private readonly IGenericRepository<RefreshToken> _refreshTokenRepository;

        public RefreshTokenManager(IGenericRepository<RefreshToken> refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task AddAsync(RefreshToken token)
        {
            await _refreshTokenRepository.AddAsync(token);
        }

        public async Task<RefreshToken> GetByIdAsync(int id)
        {
            return await _refreshTokenRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(RefreshToken token)
        {
            await _refreshTokenRepository.UpdateAsync(token);
        }

        public async Task DeleteAsync(RefreshToken token)
        {
            await _refreshTokenRepository.DeleteAsync(token);
        }

        public async Task<List<RefreshToken>> GetAllAsync()
        {
            return await _refreshTokenRepository.GetAllAsync();
        }
    }
}
