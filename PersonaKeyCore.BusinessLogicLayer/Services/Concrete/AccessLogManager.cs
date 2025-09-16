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
    public class AccessLogManager : IAccessLogService
    {
        private readonly IGenericRepository<AccessLog> _accessLogRepository;

        public AccessLogManager(IGenericRepository<AccessLog> accessLogRepository)
        {
            _accessLogRepository = accessLogRepository;
        }

        public async Task AddAsync(AccessLog accessLog)
        {
            await _accessLogRepository.AddAsync(accessLog);
        }

        public async Task<AccessLog> GetByIdAsync(int id)
        {
            return await _accessLogRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(AccessLog accessLog)
        {
            await _accessLogRepository.UpdateAsync(accessLog);
        }

        public async Task DeleteAsync(AccessLog accessLog)
        {
            await _accessLogRepository.DeleteAsync(accessLog);
        }

        public async Task<List<AccessLog>> GetAllAsync()
        {
            return await _accessLogRepository.GetAllAsync();
        }
    }
}
