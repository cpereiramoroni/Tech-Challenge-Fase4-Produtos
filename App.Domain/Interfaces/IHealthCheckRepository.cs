using System;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface IHealthCheckRepository : IDisposable
    {
        Task<bool> Reading();
    }
}
