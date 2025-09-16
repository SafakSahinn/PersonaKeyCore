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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(DepartmentDto departmentDto)
        {
            var department = new Department { Name = departmentDto.Name };
            await _departmentService.AddAsync(department);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentService.GetAllAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _departmentService.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DepartmentDto departmentDto)
        {
            var existingDepartment = await _departmentService.GetByIdAsync(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }

            existingDepartment.Name = departmentDto.Name;
            await _departmentService.UpdateAsync(existingDepartment);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _departmentService.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            await _departmentService.DeleteAsync(department);
            return NoContent(); // 204 No Content
        }
    }
}