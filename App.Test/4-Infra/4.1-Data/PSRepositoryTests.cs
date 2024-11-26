using App.Domain.Interfaces;
using App.Domain.Models;
using App.Infra.Data.Repository;
using App.Test._4_Infra._4._1_Data.Context;
using App.Test.MockObjects;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._4_Infra._4._1_Data
{
    public class PSRepositoryTests : SqlBDCorpContextTests
    {
        private IPSRepository _repository;

        public PSRepositoryTests() : base()
        {
            _repository = new PSRepository(base._read, base._persist);
        }

        #region GetProfissionaisSaudeById
        [Trait("Categoria", "ProfissionaisSaudeRepository")]
        [Fact(DisplayName = "GetProfissionaisSaudeById OK")]

        public async Task GetProfissionaisSaudeById_OK()
        {
            //Arrange
            var idProfissionalSaude = 1;

            //Act
            var result = await _repository.GetProfissionalSaudeById(idProfissionalSaude);

            //Assert

            Assert.NotNull(result);
        }
        #endregion

        #region GetPSByIdPefi
        [Trait("Categoria", "ProfissionaisSaudeRepository")]
        [Fact(DisplayName = "GetPSByIdPefi OK")]

        public async Task GetPSByIdPefi_OK()
        {
            //Arrange
            var itemPefi = await this._read.ProfissionaisSaude.FirstOrDefaultAsync();

            //Act
            var result = await _repository.GetPSByIdPefi(itemPefi.ID_PEFI_CD_PESSOA_FISICA);

            //Assert

            Assert.NotNull(result);
        }

        #endregion

        #region AddProfissionalSaude
        [Trait("Categoria", "ProfissionaisSaudeRepository")]
        [Fact(DisplayName = "AddProfissionalSaude OK")]

        public async Task AddProfissionalSaude_OK()
        {
            //Arrange
            var itemPrsa = BaseMockTest.NewModelMock<ProfissionalSaude>(true);
            itemPrsa.ID_PRSA_CD_PROF_SAUDE = 0;

            //Act
            await _repository.AddProfissionalSaude(itemPrsa);

            //Assert

            Assert.True(itemPrsa.ID_PRSA_CD_PROF_SAUDE != 0);
        }

        #endregion

        #region UpdateProfissionalSaude
        [Trait("Categoria", "ProfissionaisSaudeRepository")]
        [Fact(DisplayName = "UpdateProfissionalSaude OK")]

        public async Task UpdateProfissionalSaude_OK()
        {
            //Arrange
            var itemPrsa = await this._read.ProfissionaisSaude.FirstOrDefaultAsync();
            itemPrsa.ID_UNID_CD_UNIDADE_FICHA = 100;

            //Act
            _repository.UpdateProfissionalSaude(itemPrsa);
            //  await this._read.SaveChangesAsync();

            //Assert

            Assert.True(itemPrsa.ID_UNID_CD_UNIDADE_FICHA == 100);
        }

        #endregion

        #region GetPSByConselhoUf
        [Trait("Categoria", "ProfissionaisSaudeRepository")]
        [Fact(DisplayName = "GetPSByConselhoUf OK")]

        public async Task GetPSByConselhoUf_OK()
        {
            //Arrange
            var item = await this._read.ProfissionaisSaude.FirstOrDefaultAsync();

            //Act
            var result = await _repository.GetPSByConselhoUf(
                item.PRSA_DS_UF_ORIGEM_CERTIFICADO,
                item.ID_CTPF_SL_CATEGORIA,
                item.PRSA_NR_CERTIFICADO);

            //Assert

            Assert.NotNull(result);
        }

        #endregion

        #region GetProfissionaisSaudeByListId
        [Trait("Categoria", "ProfissionaisSaudeRepository")]
        [Fact(DisplayName = "GetProfissionaisSaudeByListId OK")]

        public async Task GetProfissionaisSaudeByListId_OK()
        {
            //Arrange
            var item = await this._read.ProfissionaisSaude.FirstOrDefaultAsync();

            //Act
            var result = await _repository.GetProfissionaisSaudeByListId(item.ID_PRSA_CD_PROF_SAUDE);

            //Assert

            Assert.NotNull(result);
        }

        #endregion

        #region [Dispose]
        [Trait("Categoria", "LiberarsRepository")]
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
