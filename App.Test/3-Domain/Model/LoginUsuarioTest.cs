using App.Domain.Models;
using System.Reflection;
using Xunit;

namespace App.Test._3_Domain
{
    public class LoginUsuarioTest
    {
        [Trait("LoginUsuario", "Domain")]
        [Fact(DisplayName = "LoginUsuario  true")]

        public void LoginUsuario_ok()
        {
            var item = MockObjects.BaseMockTest.NewModelMock<LoginUsuario>(true);

            foreach (PropertyInfo propertyInfo in item.GetType().GetProperties())
            {

                Assert.True(propertyInfo.GetValue(item) != null);
            }



        }

    }
}
