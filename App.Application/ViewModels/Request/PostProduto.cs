namespace App.Application.ViewModels.Request
{
    public class PostProduto
    {

        public string NomeProduto { get; set; }
        public decimal ValorProduto { get; set; }
        public int IdCategoria { get; set; }
        public bool Ativo { get; set; }

    }
}
