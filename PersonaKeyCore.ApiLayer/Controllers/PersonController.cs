using Microsoft.AspNetCore.Mvc;
using PersonaKeyCore.ApiLayer.Dtos;
using PersonaKeyCore.ApiLayer.DTOs;
using PersonaKeyCore.BusinessLogicLayer.Services.Abstract;
using PersonaKeyCore.EntityLayer.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonaKeyCore.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personService.GetAllAsync();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PersonDto personDto)
        {
            if (personDto == null)
            {
                return BadRequest();
            }

            var person = new Person
            {
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
                DepartmentId = personDto.DepartmentId,
                RoleId = personDto.RoleId
            };

            await _personService.AddAsync(person);

            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PersonDto personDto)
        {
            var existingPerson = await _personService.GetByIdAsync(id);
            if (existingPerson == null)
            {
                return NotFound();
            }

            existingPerson.FirstName = personDto.FirstName;
            existingPerson.LastName = personDto.LastName;
            existingPerson.DepartmentId = personDto.DepartmentId;
            existingPerson.RoleId = personDto.RoleId;

            await _personService.UpdateAsync(existingPerson);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            await _personService.DeleteAsync(person);
            return NoContent();
        }
    }
}