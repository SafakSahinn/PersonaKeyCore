using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonaKeyCore.EntityLayer.Concrete;

namespace PersonaKeyCore.BusinessLogicLayer.Services.Abstract
{
    public interface IRefreshTokenService
    {
        Task AddAsync(RefreshToken token);
        Task UpdateAsync(RefreshToken token);
        Task DeleteAsync(RefreshToken token);
        Task<List<RefreshToken>> GetAllAsync();
        Task<RefreshToken> GetByIdAsync(int id);
    }
}
