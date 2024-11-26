using System;
using System.Threading.Tasks;

namespace App.Application.Interfaces
{
    public interface IHealthCheckService : IDisposable
    {
        Task<bool> HealthCheck();
    }
}
