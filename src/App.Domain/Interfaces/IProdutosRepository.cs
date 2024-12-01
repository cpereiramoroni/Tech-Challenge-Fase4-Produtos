using App.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Domain.Interfaces
{
    public interface IProdutosRepository
    {
        Task<ProdutoBD> GetProdutoById(int id);
        Task<IList<ProdutoBD>> GetProdutosByIdCategoria(int? idCategoria);
        Task PostProduto(ProdutoBD cliente);
        Task UpdateProduto(ProdutoBD cliente);

        Task DeleteProduto(ProdutoBD cliente);
    }
}
