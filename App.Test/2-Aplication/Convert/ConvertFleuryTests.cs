using App.Application.AutoMapper;
using App.Test.MockObjects;
using System.Linq;
using Xunit;

namespace App.Test._2_Aplication.ViewModel.Request
{
    public class ConvertFleuryTests
    {
        [Trait("Category", "ConvertFleuryTests")]
        [Fact(DisplayName = "GetPS Validar OK")]
        public void GetPS_OK()
        {
            //Arrange
            var post = MockPostPF.OK().FirstOrDefault();


            //Act
            var rtnBD = ConvertFleury.GetPS(post);

            //Assert
            Assert.NotNull(rtnBD);
        }


        [Trait("Category", "ConvertFleuryTests")]
        [Fact(DisplayName = "GetLoginPS Validar OK")]
        public void GetLoginPS_OK()
        {
            //Arrange
            var id = MockPostPF.OKIdLogin();
            var post = MockPostPF.OkPrsaLogin();


            //Act
            var rtnBD = ConvertFleury.GetLoginPS(id, post);

            //Assert
            Assert.NotNull(rtnBD);
        }



    }
}
