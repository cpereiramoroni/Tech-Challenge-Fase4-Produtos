using App.Domain.Models;
using App.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public class ProdutosRepository : IProdutosRepository
    {
        private readonly MySQLContext _dbContext;

        public ProdutosRepository(MySQLContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task PostProduto(ProdutoBD Produto)
        {
            _dbContext.Produtos.Add(Produto);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IList<ProdutoBD>> GetProdutosByIdCategoria(int? idCategoria)
        {

            var query = _dbContext.Produtos.AsQueryable();

            if (idCategoria.HasValue)
            {
                query = query.Where(c => c.CategoriaId == idCategoria.Value);
            }

            return await query.ToListAsync();
        }            

        public async Task<ProdutoBD> GetProdutoById(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateProduto(ProdutoBD Produto)
        {
            _dbContext.Produtos.Update(Produto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProduto(ProdutoBD Produto)
        {
            _dbContext.Produtos.Remove(Produto);
            await _dbContext.SaveChangesAsync();
        }
    }
}
