using App.Application.ViewModels.Request;
using App.Test.MockObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace App.Test._2_Aplication.ViewModel.Request
{
    public class PatchProfissionalSaudeTests
    {
        [Trait("Category", "PatchProfissionalSaude")]
        [Fact(DisplayName = "PatchProfissionalSaude Validar OK ")]
        public void DocumentoDependente_Validar_OK_motivo_reprovacao()
        {
            //Arrange
            var idProfissionalSaude = MockPostPF.OKIdLogin();

            PatchProfissionalSaude patch = new()
            {
                idUsuarioAlteracao = 123,
                motivoAlteracao = "motivo",
                idStatus = 5
            };

            //Act
            ValidationContext context = new(patch, null, null);
            List<ValidationResult> results = new();
            var isModelStateValid = Validator.TryValidateObject(patch, context, results);

            //Assert
            Assert.True(isModelStateValid);
        }
    }
}
