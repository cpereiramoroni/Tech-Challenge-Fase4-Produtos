using App.Application.ViewModels.Response;
using System.Reflection;
using Xunit;

namespace App.Test._2_Aplication.ViewModel.Response
{
    public class ProfissionalSaudeFleuryTest
    {
        [Trait("ProfissionalSaudeFleury", "ViewModel")]
        [Fact(DisplayName = "ProfissionalSaudeFleury  true")]

        public void Complemento_retornar_PSFDeveRetornar_ok()
        {
            var item = MockObjects.BaseMockTest.NewModelMock<ProfissionalSaudeFleury>(true);

            foreach (PropertyInfo propertyInfo in item.GetType().GetProperties())
            {

                Assert.True(propertyInfo.GetValue(item) != null);
            }



        }

    }
}
