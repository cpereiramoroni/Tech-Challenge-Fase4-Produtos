using App.Application.ViewModels.Request;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace App.Test._2_Aplication.ViewModel.Request
{
    public class PostEspecialidadeTests
    {
        [Trait("Category", "PostEspecialidade")]
        [Fact(DisplayName = "PostEspecialidade Validar OK")]
        public void PostEspecialidade_Validar_OK()
        {
            //Arrange
            ProfissionalEspecialidades postEspecialidade = new ProfissionalEspecialidades()
            {
                idUsuarioAlteracao = 1,
                motivoAlteracao = "teste"
            };


            //Act
            ValidationContext context = new ValidationContext(postEspecialidade, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postEspecialidade, context, results);

            //Assert

            Assert.True(isModelStateValid);
        }
    }
}
