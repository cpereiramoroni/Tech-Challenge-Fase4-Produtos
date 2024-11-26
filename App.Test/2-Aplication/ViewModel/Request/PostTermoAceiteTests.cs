using App.Application.ViewModels.Request;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace App.Test._2_Aplication.ViewModel.Request
{
    public class PostTermoAceiteTests
    {
        [Trait("Category", "PostTermoAceite")]
        [Fact(DisplayName = "PostTermoAceite Validar NOK")]
        public void PostTermoAceite_Validar_NOK()
        {
            //Arrange
            PostTermoAceite termo = new()
            {
                idFicha = "5001234567",
                idItem = 100

            };


            //Act
            ValidationContext context = new ValidationContext(termo, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(termo, context, results);

            //Assert

            Assert.False(isModelStateValid);
        }
    }
}
