using App.Application.Interfaces;
using App.Application.ViewModels.Request;
using App.Application.ViewModels.Response;
using App.Domain.Interfaces;
using App.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProdutosService : IProdutosService
    {
        private readonly IProdutosRepository _repository;

        public ProdutosService(IProdutosRepository repository)
        {
            _repository = repository;
        }

        public async Task PostProduto(PostProduto input)
        {
            var item = new ProdutoBD(input.IdCategoria, input.NomeProduto, input.ValorProduto, input.Ativo);
            await _repository.PostProduto(item);
        }

        public async Task UpdateProdutoById(int produtoId, PatchProduto input)
        {


            ProdutoBD item = await ExistProduto(produtoId);

            item.Status = input.Ativo ?? item.Status;
            item.Preco = input.ValorProduto ?? item.Preco;
            item.Nome = !string.IsNullOrEmpty(input.NomeProduto) ? input.NomeProduto : item.Nome;

            item.ValidateEntity();

            await _repository.UpdateProduto(item);

        }


        public async Task DeleteProdutoById(int produtoId)
        {
            var item = await ExistProduto(produtoId);

            await _repository.DeleteProduto(item);
        }
        public async Task<IList<Produto>> GetProdutoByCategoria(int? IdCategoria)
        {

            var lstProduto = await _repository.GetProdutosByIdCategoria(IdCategoria);
            if (lstProduto is null)
                return default;

            return lstProduto.Select(s => new Produto(s)).ToList();
        }

        #region Uteis
        private async Task<ProdutoBD> ExistProduto(int produtoId)
        {
            var itemProduto = await _repository.GetProdutoById(produtoId);
            if (itemProduto is null)
                throw new ValidationException("Produto não encontrado.");

            return itemProduto;
        }


        #endregion

    }
}