using App.Application.ViewModels.Enuns;
using System;

namespace App.Application.ViewModels.Response
{
    public class Produto
    {
        public Produto()
        {
                
        }
        public Produto(Domain.Models.ProdutoBD _produto)
        {

            IdProduto = _produto.Id;
            NomeProduto = _produto.Nome;
            ValorProduto = _produto.Preco;
            Ativo = _produto.Status;
            IdCategoria = _produto.CategoriaId;
            NomeCategoria = (EnumCategoria)Enum.Parse(typeof(EnumCategoria), IdCategoria.ToString());

        }

        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal ValorProduto { get; set; }
        public int IdCategoria { get; set; }
        public bool Ativo { get; set; }
        public EnumCategoria NomeCategoria { get; set; }

    }
}
