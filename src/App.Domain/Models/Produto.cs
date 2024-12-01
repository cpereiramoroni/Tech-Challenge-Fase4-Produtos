using App.Domain.Validations;

namespace App.Domain.Models
{
    public class ProdutoBD
    {

        public int Id { get; set; }
        public int CategoriaId { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public bool Status { get; set; }

        public ProdutoBD(int categoriaId, string nome, decimal preco, bool status)
        {

            CategoriaId = categoriaId;

            Nome = nome;
            Preco = preco;
            Status = status;
            ValidateEntity();
        }



        public void ValidateEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(Nome, "O nome não pode estar vazio!");
            AssertionConcern.AssertArgumentNotNullZero(Preco, "O Preco não pode estar vazio e tem que ser maior que zero!");
            AssertionConcern.AssertArgumentNotNullZero(CategoriaId, "A Categoria não pode estar vazio e tem que ser maior que zero!");
        }
    }
}
