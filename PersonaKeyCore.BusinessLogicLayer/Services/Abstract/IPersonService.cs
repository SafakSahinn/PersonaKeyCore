using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonaKeyCore.EntityLayer.Concrete;

namespace PersonaKeyCore.BusinessLogicLayer.Services.Abstract
{
    public interface IPersonService
    {
        Task AddAsync(Person person);
        Task UpdateAsync(Person person);
        Task DeleteAsync(Person person);
        Task<List<Person>> GetAllAsync();
        Task<Person> GetByIdAsync(int id);
    }
}
