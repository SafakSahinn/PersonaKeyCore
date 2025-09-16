using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonaKeyCore.EntityLayer.Concrete;

namespace PersonaKeyCore.BusinessLogicLayer.Services.Abstract
{
    public interface ICardService
    {
        Task AddAsync(Card card);
        Task UpdateAsync(Card card);
        Task DeleteAsync(Card card);
        Task<List<Card>> GetAllAsync();
        Task<Card> GetByIdAsync(int id);
    }
}
