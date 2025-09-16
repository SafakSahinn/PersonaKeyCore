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
    public class PersonManager : IPersonService
    {
        private readonly IGenericRepository<Person> _personRepository;

        public PersonManager(IGenericRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task AddAsync(Person person)
        {
            await _personRepository.AddAsync(person);
        }

        public async Task DeleteAsync(Person person)
        {
            await _personRepository.DeleteAsync(person);
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _personRepository.GetAllAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _personRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Person person)
        {
            await _personRepository.UpdateAsync(person);
        }
    }
}
