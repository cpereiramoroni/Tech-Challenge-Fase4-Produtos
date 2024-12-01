using App.Application.ViewModels.Request;
using App.Application.ViewModels.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Application.Interfaces
{
    public interface IProdutosService
    {
        Task PostProduto(PostProduto input);

        Task UpdateProdutoById(int produtoId, PatchProduto filtro);

        Task DeleteProdutoById(int produtoId);

        Task<IList<Produto>> GetProdutoByCategoria(int? IdCategoria);


    }
}
