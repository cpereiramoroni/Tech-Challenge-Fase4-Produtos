namespace App.Application.ViewModels.Request
{
    public class PatchProduto
    {
        public string NomeProduto { get; set; }
        public decimal? ValorProduto { get; set; }
        public int? IdCategoria { get; set; }
        public bool? Ativo { get; set; }

    }
}
