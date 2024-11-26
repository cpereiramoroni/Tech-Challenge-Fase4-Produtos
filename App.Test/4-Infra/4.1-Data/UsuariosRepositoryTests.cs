using App.Domain.Interfaces;

using App.Infra.Data.Repository;
using App.Test._4_Infra._4._1_Data.Context;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._4_Infra._4._1_Data
{
    public class UsuariosRepositoryTests : SqlBDCorpContextTests
    {
        public IUsuariosRepository _repository;
        public UsuariosRepositoryTests() : base()
        {
            _repository = new UsuariosRepository(base._read);
        }

        #region GetUsuariosById

        [Trait("Categoria", "UsuariosRepository")]
        [Fact(DisplayName = "GetUsuariosById OK")]
        public async Task GetUsuariosById_OK()
        {

            await base._read.Usuarios.AddAsync(new Domain.Models.Usuario { ID_USUA_CD_USUARIO = 100 });
            await base._read.SaveChangesAsync();
            //Act
            var result = await _repository.GetById(100);
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
