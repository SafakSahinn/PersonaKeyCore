using Microsoft.AspNetCore.Mvc;
using PersonaKeyCore.ApiLayer.Dtos;
using PersonaKeyCore.BusinessLogicLayer.Services.Abstract;
using PersonaKeyCore.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonaKeyCore.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CardDto cardDto)
        {
            var card = new Card { CardCode = cardDto.CardCode, PersonId = cardDto.PersonId, IsActive = true };
            await _cardService.AddAsync(card);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cards = await _cardService.GetAllAsync();
            return Ok(cards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var card = await _cardService.GetByIdAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            return Ok(card);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CardDto cardDto)
        {
            var existingCard = await _cardService.GetByIdAsync(id);
            if (existingCard == null)
            {
                return NotFound();
            }

            existingCard.CardCode = cardDto.CardCode;
            existingCard.PersonId = cardDto.PersonId;
            existingCard.IsActive = true; // Veya cardDto'dan alınabilir

            await _cardService.UpdateAsync(existingCard);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var card = await _cardService.GetByIdAsync(id);
            if (card == null)
            {
                return NotFound();
            }

            await _cardService.DeleteAsync(card);
            return NoContent();
        }
    }
}