using App.Domain.Interfaces;

using App.Infra.Data.Repository;
using App.Test._4_Infra._4._1_Data.Context;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._4_Infra._4._1_Data
{
    public class CategoriasRepositoryTests : SqlBDCorpContextTests
    {
        public ICategoriasRepository _repository;
        public CategoriasRepositoryTests() : base()
        {
            _repository = new CategoriasRepository(base._read);
        }

        #region GetCategoriasById

        [Trait("Categoria", "CategoriasRepository")]
        [Fact(DisplayName = "GetCategoriasById OK")]
        public async Task GetCategoriasById_OK()
        {

            var item = base._read.Categorias.FirstOrDefault();
            //Act
            var result = await _repository.GetCategoriaBySigla(item.ID_CTPF_SL_CATEGORIA);

            //Assert
            Assert.True(result != null);
        }

        #endregion


        #region [Dispose]

        [Trait("Categoria", "Dispose")]
        [Fact(DisplayName = "DisposeBase ")]
        public void DisposeBase()
        {
            //act
            _repository.Dispose();
            Assert.NotNull(_repository);


        }

        #endregion
    }
}
