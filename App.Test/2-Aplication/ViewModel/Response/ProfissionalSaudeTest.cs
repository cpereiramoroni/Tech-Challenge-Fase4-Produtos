using App.Application.ViewModels.Response;
using System.Reflection;
using Xunit;

namespace App.Test._2_Aplication.ViewModel.Response
{
    public class ProfissionalSaudeTest
    {
        [Trait("ProfissionalSaude", "ViewModel")]
        [Fact(DisplayName = "ProfissionalSaude  true")]

        public void Complemento_retornar_PSFDeveRetornar_ok()
        {
            var item = MockObjects.BaseMockTest.NewModelMock<ProfissionalSaude>(true);

            foreach (PropertyInfo propertyInfo in item.GetType().GetProperties())
            {

                Assert.True(propertyInfo.GetValue(item) != null);
            }



        }

    }
}
