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
    public class CardManager : ICardService
    {
        private readonly IGenericRepository<Card> _cardRepository;

        public CardManager(IGenericRepository<Card> cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task AddAsync(Card card)
        {
            await _cardRepository.AddAsync(card);
        }

        public async Task DeleteAsync(Card card)
        {
            await _cardRepository.DeleteAsync(card);
        }

        public async Task<List<Card>> GetAllAsync()
        {
            return await _cardRepository.GetAllAsync();
        }

        public async Task<Card> GetByIdAsync(int id)
        {
            return await _cardRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Card card)
        {
            await _cardRepository.UpdateAsync(card);
        }
    }
}
