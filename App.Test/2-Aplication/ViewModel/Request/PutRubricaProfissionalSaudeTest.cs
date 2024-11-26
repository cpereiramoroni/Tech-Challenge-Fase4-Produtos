using App.Application.ViewModels.Request;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace App.Test._2_Aplication.ViewModel.Request
{
    public class PutRubricaProfissionalSaudeTest
    {
        [Trait("Category", "PutRubricaProfissioalSaude")]
        [Fact(DisplayName = "PutRubricaProfissioalSaude Validar OK")]
        public void PutRubricaProfissioalSaude_Validar_OK()
        {
            //Arrange
            PutRubricaProfissionalSaude putRubricaProfissionalSaude = new()
            {
                base64RubricaGif = "R0lGODlhAQABAIAAAAUEBAAAACwAAAAAAQABAAACAkQBADs=",
                base64RubricaPng = "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"
            };

            //Act
            ValidationContext context = new(putRubricaProfissionalSaude, null, null);
            List<ValidationResult> results = new();
            var isModelStateValid = Validator.TryValidateObject(putRubricaProfissionalSaude, context, results);

            //Assert
            Assert.True(isModelStateValid);
        }

        [Trait("Category", "PutRubricaProfissioalSaude")]
        [Fact(DisplayName = "PutRubricaProfissioalSaude Imagem GIF é Inválida")]
        public void PutRubricaProfissioalSaude_ImagemGIF_Invalida()
        {
            //Arrange
            PutRubricaProfissionalSaude putRubricaProfissionalSaude = new()
            {
                base64RubricaGif = "nome",
                base64RubricaPng = "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"
            };

            //Act
            ValidationContext context = new(putRubricaProfissionalSaude, null, null);
            List<ValidationResult> results = new();
            var isModelStateValid = Validator.TryValidateObject(putRubricaProfissionalSaude, context, results);

            //Assert
            Assert.False(isModelStateValid);
        }

        [Trait("Category", "PutRubricaProfissioalSaude")]
        [Fact(DisplayName = "PutRubricaProfissioalSaude Imagem PNG é Inválida")]
        public void PutRubricaProfissioalSaude_ImagemPNG_Invalida()
        {
            //Arrange
            PutRubricaProfissionalSaude putRubricaProfissionalSaude = new()
            {
                base64RubricaGif = "R0lGODlhAQABAIAAAAUEBAAAACwAAAAAAQABAAACAkQBADs=",
                base64RubricaPng = "nome"
            };

            //Act
            ValidationContext context = new(putRubricaProfissionalSaude, null, null);
            List<ValidationResult> results = new();
            var isModelStateValid = Validator.TryValidateObject(putRubricaProfissionalSaude, context, results);

            //Assert
            Assert.False(isModelStateValid);
        }

        [Trait("Category", "PutRubricaProfissioalSaude")]
        [Fact(DisplayName = "PutRubricaProfissioalSaude Imagens estão Inválidas")]
        public void PutRubricaProfissioalSaude_Imagens_GIF_e_PNG_Invalidas()
        {
            //Arrange
            PutRubricaProfissionalSaude putRubricaProfissionalSaude = new()
            {
                base64RubricaGif = "nome",
                base64RubricaPng = "nome"
            };

            //Act
            ValidationContext context = new(putRubricaProfissionalSaude, null, null);
            List<ValidationResult> results = new();
            var isModelStateValid = Validator.TryValidateObject(putRubricaProfissionalSaude, context, results);

            //Assert
            Assert.False(isModelStateValid);
        }

        [Trait("Category", "PutRubricaProfissioalSaude")]
        [Fact(DisplayName = "PutRubricaProfissioalSaude Imagens Não Existe")]
        public void PutRubricaProfissioalSaude_Imagens_Não_Existe()
        {
            //Arrange
            PutRubricaProfissionalSaude putRubricaProfissionalSaude = new()
            {
                base64RubricaGif = "srtNcAfcAAPX19fT09P////Hx8e/v7+7u7urq6uvr6+fn5+b",
                base64RubricaPng = "srtNcAfcAAPX19fT09P////Hx8e/v7+7u7urq6uvr6+fn5+b"
            };

            //Act
            ValidationContext context = new(putRubricaProfissionalSaude, null, null);
            List<ValidationResult> results = new();
            var isModelStateValid = Validator.TryValidateObject(putRubricaProfissionalSaude, context, results);

            //Assert
            Assert.False(isModelStateValid);
        }
    }
}
