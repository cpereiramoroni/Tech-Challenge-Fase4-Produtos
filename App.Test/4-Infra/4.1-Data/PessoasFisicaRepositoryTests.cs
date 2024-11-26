using App.Domain.Interfaces;

using App.Infra.Data.Repository;
using App.Test._4_Infra._4._1_Data.Context;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._4_Infra._4._1_Data
{
    public class PessoasFisicaRepositoryTests : SqlBDCorpContextTests
    {
        public IPessoasFisicaRepository _repository;
        public PessoasFisicaRepositoryTests() : base()
        {
            _repository = new PessoasFisicaRepository(base._read);
        }

        #region GetPessoasFisicaById

        [Trait("Categoria", "PessoasFisicaRepository")]
        [Fact(DisplayName = "GetPessoasFisicaById OK")]
        public async Task GetPessoasFisicaById_OK()
        {

            var item = base._read.PessoaFisicas.FirstOrDefault();
            //Act
            var result = await _repository.GetPessoaFisicaById(item.ID_PEFI_CD_PESSOA_FISICA);

            //Assert
            Assert.True(result != null);

        }

        [Trait("Categoria", "PessoasFisicaRepository")]
        [Fact(DisplayName = "UpdatePessoaFisica OK")]
        public async Task UpdatePessoaFisica_OK()
        {

            var item = base._read.PessoaFisicas.FirstOrDefault();
            //Act
            await _repository.UpdatePessoaFisica(item);

            //Assert
            Assert.True(item != null);

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
