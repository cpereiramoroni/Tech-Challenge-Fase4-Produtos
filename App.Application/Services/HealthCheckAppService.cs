using App.Application.Interfaces;
using App.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class HealthCheckService : IHealthCheckService
    {
        private readonly IHealthCheckRepository _healthCheckRepository;

        public HealthCheckService(IHealthCheckRepository healthCheckRepository)
        {
            _healthCheckRepository = healthCheckRepository;
        }

        public async Task<bool> HealthCheck()
        {
            return await _healthCheckRepository.Reading();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _healthCheckRepository.Dispose();
        }
    }
}
