using App.Domain.Interfaces;
using App.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace App.Infra.Data.Repository
{
    public class HealthCheckRepository : IHealthCheckRepository
    {
        private readonly MySQLContext _context;

        public HealthCheckRepository(MySQLContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public async Task<bool> Reading()
        {
            try
            {
                await _context.Database.OpenConnectionAsync();
                await _context.Database.ExecuteSqlRawAsync("SELECT 1");
                await _context.Database.CloseConnectionAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
