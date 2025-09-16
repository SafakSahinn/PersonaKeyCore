using Microsoft.AspNetCore.Mvc;
using PersonaKeyCore.ApiLayer.Dtos;
using PersonaKeyCore.BusinessLogicLayer.Services.Abstract;
using PersonaKeyCore.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonaKeyCore.ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessLogController : ControllerBase
    {
        private readonly IAccessLogService _accessLogService;

        public AccessLogController(IAccessLogService accessLogService)
        {
            _accessLogService = accessLogService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AccessLogDto accessLogDto)
        {
            var accessLog = new AccessLog
            {
                PersonId = accessLogDto.PersonId,
                DoorId = accessLogDto.DoorId,
                Status = accessLogDto.Status,
                AccessTime = DateTime.Now
            };
            await _accessLogService.AddAsync(accessLog);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accessLogs = await _accessLogService.GetAllAsync();
            return Ok(accessLogs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var accessLog = await _accessLogService.GetByIdAsync(id);
            if (accessLog == null)
            {
                return NotFound();
            }
            return Ok(accessLog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AccessLogDto accessLogDto)
        {
            var existingLog = await _accessLogService.GetByIdAsync(id);
            if (existingLog == null)
            {
                return NotFound();
            }

            // Normalde log verileri güncellenmez, ancak bu örnek için ekliyoruz
            existingLog.PersonId = accessLogDto.PersonId;
            existingLog.DoorId = accessLogDto.DoorId;
            existingLog.Status = accessLogDto.Status;

            await _accessLogService.UpdateAsync(existingLog);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var accessLog = await _accessLogService.GetByIdAsync(id);
            if (accessLog == null)
            {
                return NotFound();
            }

            await _accessLogService.DeleteAsync(accessLog);
            return NoContent();
        }
    }
}