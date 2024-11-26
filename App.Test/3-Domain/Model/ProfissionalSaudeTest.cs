using App.Domain.Models;
using System.Reflection;
using Xunit;

namespace App.Test._3_Domain
{
    public class PessoaFisicaTest
    {
        [Trait("PessoaFisica", "Domain")]
        [Fact(DisplayName = "PessoaFisica  true")]

        public void PessoaFisica_ok()
        {
            var item = MockObjects.BaseMockTest.NewModelMock<PessoaFisica>(true);

            foreach (PropertyInfo propertyInfo in item.GetType().GetProperties())
            {

                Assert.True(propertyInfo.GetValue(item) != null);
            }



        }

    }
}
