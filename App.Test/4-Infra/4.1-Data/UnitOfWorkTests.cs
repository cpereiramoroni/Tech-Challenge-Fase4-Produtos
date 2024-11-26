using App.Domain.Interfaces;
using App.Domain.Models;
using App.Infra.Data.UnitOfWork;
using App.Test._4_Infra._4._1_Data.Context;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._4_Infra._4._1_Data
{
    public class UnitOfWorkTests : SqlBDCorpContextTests
    {
        public IUnitOfWork _unitOfWork;

        public UnitOfWorkTests() : base()
        {
            _unitOfWork = new UnitOfWork(base._persist);
        }

        #region Commit
        [Trait("Categoria", "UnitOfWork")]
        [Fact(DisplayName = "Commit OK")]
        public async Task ValidarCommit_OK()
        {

            //Arrange
            var item = new ProfissionalSaudeEspecialidade
            {
                ID_ESPE_CD_ESPEC_MED = 2,
                ID_PRSA_CD_PROF_SAUDE = 2
            };
            //Act

            await _unitOfWork.Commit();

            //Assert
            Assert.NotNull(item);
        }

        #endregion

        #region [Dispose]

        [Trait("Categoria", "LiberarsRepository")]
        [Fact(DisplayName = "DisposeBase ")]
        public void DisposeBase()
        {
            //act
            _unitOfWork.Dispose();
            Assert.NotNull(_unitOfWork);


        }

        #endregion
    }
}
