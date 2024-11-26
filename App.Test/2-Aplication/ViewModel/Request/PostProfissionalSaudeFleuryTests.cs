using App.Application.ViewModels.Request;
using Corporativo.Util.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace App.Test._2_Aplication.ViewModel.Request
{
    public class PostProfissionalSaudeFleuryTests
    {
        [Trait("Categoria", "PostProfissionalSaudeFleury")]
        [Fact(DisplayName = "PostProfissionalSaudeFleury Valido")]
        public void PostProfissionailSaudeFleury_OK()
        {
            //Arrange
            var postProfissionalSaudeFleury = new PostProfissionalSaudeFleury
            {
                idProfissionalSaude = 404,
                ramalFleury = 2221,
                status = 3,
                categoriaFleury = CategoriaFleury.S,
                numeroProntuario = 0,
                nomeEmpresaAssociada = "testeEmpresa",
                dataInicioSocio = "22/10/2022",
                areaInteressePesquisa = "testeArea",
                descricaoResponsabilidade = "teste",
                nomeConjuge = "teste",
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = "teste",
                divulgaDataNascimento = Status.Nao,
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaudeFleury, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaudeFleury, context, results, true);
            //Assert
            Assert.True(isModelStateValid);
        }


        [Trait("Categoria", "PostProfissionalSaude")]
        [Fact(DisplayName = "PostProfissionalSaude idProfissionalSaude Invalido")]


        public void PostProfissionailSaude_idProfissionalSaude_Invalido()
        {

            //Arrange
            var postProfissionalSaudeFleury = new PostProfissionalSaudeFleury
            {
                idProfissionalSaude = -404,
                ramalFleury = 2221,
                status = 3,
                categoriaFleury = CategoriaFleury.A,
                numeroProntuario = 0,
                nomeEmpresaAssociada = "testeEmpresa",
                dataInicioSocio = "22/10/2022",
                areaInteressePesquisa = "testeArea",
                descricaoResponsabilidade = "teste",
                nomeConjuge = "teste",
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = "teste",
                divulgaDataNascimento = Status.Nao,
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaudeFleury, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaudeFleury, context, results, true);
            //Assert
            Assert.False(isModelStateValid);
        }

        [Trait("Categoria", "PostProfissionalSaude")]
        [Fact(DisplayName = "PostProfissionalSaude ramalFleury Invalido")]

        public void PostProfissionailSaude_ramalFleury_Invalido()
        {

            //Arrange
            var postProfissionalSaudeFleury = new PostProfissionalSaudeFleury
            {
                idProfissionalSaude = 404,
                ramalFleury = -222,
                status = 3,
                categoriaFleury = CategoriaFleury.S,
                numeroProntuario = 0,
                nomeEmpresaAssociada = "testeEmpresa",
                dataInicioSocio = "22/10/2022",
                areaInteressePesquisa = "testeArea",
                descricaoResponsabilidade = "teste",
                nomeConjuge = "teste",
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = "teste",
                divulgaDataNascimento = Status.Nao,
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaudeFleury, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaudeFleury, context, results, true);

            //Assert
            Assert.False(isModelStateValid);
        }


        [Trait("Categoria", "PostProfissionalSaudeFleury")]
        [Fact(DisplayName = "PostProfissionalSaudeFleury status Invalido")]

        public void PostProfissionailSaudeFleuryConselhoRegionalInvalido()
        {
            //Arrange
            var postProfissionalSaudeFleury = new PostProfissionalSaudeFleury
            {
                idProfissionalSaude = 404,
                ramalFleury = 2221,
                status = -1,
                categoriaFleury = CategoriaFleury.S,
                numeroProntuario = 0,
                nomeEmpresaAssociada = "testeEmpresa",
                dataInicioSocio = "22/10/2022",
                areaInteressePesquisa = "testeArea",
                descricaoResponsabilidade = "teste",
                nomeConjuge = "teste",
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = "teste",
                divulgaDataNascimento = Status.Nao,
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaudeFleury, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaudeFleury, context, results, true);
            //Assert
            Assert.False(isModelStateValid);
        }


        [Trait("Categoria", "PostProfissionalSaudeFleury")]
        [Fact(DisplayName = "PostProfissionalSaudeFleury status null")]

        public void PostProfissionailSaudeFleurystatusNull()
        {
            //Arrange
            var postProfissionalSaudeFleury = new PostProfissionalSaudeFleury
            {
                idProfissionalSaude = 404,
                ramalFleury = 2221,
                status = null,
                categoriaFleury = CategoriaFleury.S,
                numeroProntuario = 0,
                nomeEmpresaAssociada = "testeEmpresa",
                dataInicioSocio = "22/10/2022",
                areaInteressePesquisa = "testeArea",
                descricaoResponsabilidade = "teste",
                nomeConjuge = "teste",
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = "teste",
                divulgaDataNascimento = Status.Nao,
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaudeFleury, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaudeFleury, context, results, true);
            //Assert
            Assert.False(isModelStateValid);
        }



        [Trait("Categoria", "PostProfissionalSaude")]
        [Fact(DisplayName = "PostProfissionalSaude categoria Invalido")]

        public void PostProfissionailSaude_categoria_Invalido()
        {

            //Arrange
            var postProfissionalSaudeFleury = new PostProfissionalSaudeFleury
            {
                idProfissionalSaude = 404,
                ramalFleury = -222,
                status = 3,
                categoriaFleury = 0,
                numeroProntuario = 0,
                nomeEmpresaAssociada = "testeEmpresa",
                dataInicioSocio = "22/10/2022",
                areaInteressePesquisa = "testeArea",
                descricaoResponsabilidade = "teste",
                nomeConjuge = "teste",
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = "teste",
                divulgaDataNascimento = Status.Nao,
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaudeFleury, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaudeFleury, context, results, true);

            //Assert
            Assert.False(isModelStateValid);
        }

        [Trait("Categoria", "PostProfissionalSaude")]
        [Fact(DisplayName = "PostProfissionalSaude numeroProntuario Invalido")]
        public void PostProfissionailSaude_numeroProntuario_Invalido()
        {

            //Arrange
            var postProfissionalSaudeFleury = new PostProfissionalSaudeFleury
            {
                idProfissionalSaude = 404,
                ramalFleury = -222,
                status = 3,
                categoriaFleury = 0,
                numeroProntuario = -10,
                nomeEmpresaAssociada = "testeEmpresa",
                dataInicioSocio = "22/10/2022",
                areaInteressePesquisa = "testeArea",
                descricaoResponsabilidade = "teste",
                nomeConjuge = "teste",
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = "teste",
                divulgaDataNascimento = Status.Nao,
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaudeFleury, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaudeFleury, context, results, true);

            //Assert
            Assert.False(isModelStateValid);
        }

        [Trait("Categoria", "PostProfissionalSaude")]
        [Fact(DisplayName = "PostProfissionalSaude nomeEmpresaAssociada Invalido")]

        public void PostProfissionailSaude_nomeEmpresaAssociada_Invalido()
        {


            //Arrange
            var postProfissionalSaudeFleury = new PostProfissionalSaudeFleury
            {
                idProfissionalSaude = 404,
                ramalFleury = 2221,
                status = 3,
                categoriaFleury = CategoriaFleury.S,
                numeroProntuario = 0,
                nomeEmpresaAssociada = "Nome empresa associada deve conter menos de trinta caracteres",
                dataInicioSocio = "22/10/2022",
                areaInteressePesquisa = "testeArea",
                descricaoResponsabilidade = "teste",
                nomeConjuge = "teste",
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = "teste",
                divulgaDataNascimento = Status.Nao,
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaudeFleury, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaudeFleury, context, results, true);

            //Assert
            Assert.False(isModelStateValid);
        }

        [Trait("Categoria", "PostProfissionalSaude")]
        [Fact(DisplayName = "PostProfissionalSaude dataInicioSocio Invalido")]


        public void PostProfissionailSaudeFleury_dataInicioSocio_Invalido()
        {

            //Arrange
            var postProfissionalSaudeFleury = new PostProfissionalSaudeFleury
            {
                idProfissionalSaude = 404,
                ramalFleury = 2221,
                status = 3,
                categoriaFleury = CategoriaFleury.P,
                numeroProntuario = 0,
                nomeEmpresaAssociada = "testeEmpresa",
                dataInicioSocio = null,
                areaInteressePesquisa = "testeArea",
                descricaoResponsabilidade = "teste",
                nomeConjuge = "teste",
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = "teste",
                divulgaDataNascimento = Status.Nao,
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaudeFleury, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaudeFleury, context, results, true);
            //Assert
            Assert.False(isModelStateValid);
        }

        [Trait("Categoria", "PostProfissionalSaude")]
        [Fact(DisplayName = "PostProfissionalSaude areaInteressePesquisa Invalido")]
        public void PostProfissionailSaude_areaInteressePesquisa_Invalido()
        {

            //Arrange
            var postProfissionalSaudeFleury = new PostProfissionalSaudeFleury
            {
                idProfissionalSaude = 404,
                ramalFleury = 2221,
                status = 3,
                categoriaFleury = CategoriaFleury.S,
                numeroProntuario = 0,
                nomeEmpresaAssociada = "testeEmpresa",
                dataInicioSocio = "22/10/2022",
                areaInteressePesquisa = "area interesse pesquisa com mais de vinte caracteres",
                descricaoResponsabilidade = "teste",
                nomeConjuge = "teste",
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = "teste",
                divulgaDataNascimento = Status.Nao,
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaudeFleury, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaudeFleury, context, results, true);
            //Assert
            Assert.False(isModelStateValid);
        }

        [Trait("Categoria", "PostProfissionalSaude")]
        [Fact(DisplayName = "PostProfissionalSaude descricaoResponsabilidade Invalido")]
        public void PostProfissionailSaude_descricaoResponsabilidade_Invalido()
        {

            //Arrange
            var postProfissionalSaudeFleury = new PostProfissionalSaudeFleury
            {
                idProfissionalSaude = 404,
                ramalFleury = 2221,
                status = 3,
                categoriaFleury = CategoriaFleury.S,
                numeroProntuario = 0,
                nomeEmpresaAssociada = "testeEmpresa",
                dataInicioSocio = "22/10/2022",
                areaInteressePesquisa = "testeArea",
                descricaoResponsabilidade = "descricao responsabilidade com mais de vinte caracteres",
                nomeConjuge = "teste",
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = "teste",
                divulgaDataNascimento = Status.Nao,
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaudeFleury, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaudeFleury, context, results, true);
            //Assert
            Assert.False(isModelStateValid);
        }


        [Trait("Categoria", "PostProfissionalSaudeFleury")]
        [Fact(DisplayName = "PostProfissionalSaudeFleury nomeConjuge Invalido")]


        public void PostProfissionailSaude_nomeConjuge_Invalido()
        {
            //Arrange
            var postProfissionalSaudeFleury = new PostProfissionalSaudeFleury
            {
                idProfissionalSaude = 404,
                ramalFleury = 2221,
                status = 3,
                categoriaFleury = CategoriaFleury.S,
                numeroProntuario = 0,
                nomeEmpresaAssociada = "testeEmpresa",
                dataInicioSocio = "22/10/2022",
                areaInteressePesquisa = "testeArea",
                descricaoResponsabilidade = "teste",
                nomeConjuge = "teste com mais de cinquenta caracteres no nome do conjuge",
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = "teste",
                divulgaDataNascimento = Status.Nao,
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaudeFleury, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaudeFleury, context, results, true);
            //Assert
            Assert.False(isModelStateValid);
        }


        [Trait("Categoria", "PostProfissionalSaude")]
        [Fact(DisplayName = "PostProfissionalSaude divulgaNomeConjuge Invalido")]

        public void PostProfissionailSaude_divulgaNomeConjuge_Invalido()
        {

            //Arrange
            var postProfissionalSaudeFleury = new PostProfissionalSaudeFleury
            {
                idProfissionalSaude = 404,
                ramalFleury = -222,
                status = 3,
                categoriaFleury = CategoriaFleury.F,
                numeroProntuario = 0,
                nomeEmpresaAssociada = "testeEmpresa",
                dataInicioSocio = "22/10/2022",
                areaInteressePesquisa = "testeArea",
                descricaoResponsabilidade = "teste",
                nomeConjuge = "teste",
                divulgaNomeConjuge = 0,
                motivoAfastamento = "teste",
                divulgaDataNascimento = Status.Nao,
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaudeFleury, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaudeFleury, context, results, true);

            //Assert
            Assert.False(isModelStateValid);
        }


        [Trait("Categoria", "PostProfissionalSaude")]
        [Fact(DisplayName = "PostProfissionalSaude motivoAfastamento Invalido")]

        public void PostProfissionailSaude_motivoAfastamento_Invalido()
        {

            //Arrange



            var postProfissionalSaudeFleury = new PostProfissionalSaudeFleury
            {
                idProfissionalSaude = 404,
                ramalFleury = 2221,
                status = 0,
                categoriaFleury = CategoriaFleury.S,
                numeroProntuario = 0,
                nomeEmpresaAssociada = "testeEmpresa",
                dataInicioSocio = "22/10/2022",
                areaInteressePesquisa = "testeArea",
                descricaoResponsabilidade = "teste",
                nomeConjuge = "teste",
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = null,
                divulgaDataNascimento = Status.Nao,
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaudeFleury, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaudeFleury, context, results, true);
            //Assert
            Assert.False(isModelStateValid);
        }


        [Trait("Categoria", "PostProfissionalSaude")]
        [Fact(DisplayName = "PostProfissionalSaude divulgaDataNascimento Invalido")]

        public void PostProfissionailSaude_divulgaDataNascimento_Invalido()
        {

            //Arrange
            var postProfissionalSaudeFleury = new PostProfissionalSaudeFleury
            {
                idProfissionalSaude = 404,
                ramalFleury = -222,
                status = 3,
                categoriaFleury = CategoriaFleury.F,
                numeroProntuario = 0,
                nomeEmpresaAssociada = "testeEmpresa",
                dataInicioSocio = "22/10/2022",
                areaInteressePesquisa = "testeArea",
                descricaoResponsabilidade = "teste",
                nomeConjuge = "teste",
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = "teste",
                divulgaDataNascimento = 0,
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaudeFleury, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaudeFleury, context, results, true);

            //Assert
            Assert.False(isModelStateValid);
        }



        [Trait("Categoria", "PostProfissionalSaude")]
        [Fact(DisplayName = "PostProfissionalSaude _status_0_motivoAfastamento")]

        public void PostProfissionailSaude_status_0_motivoAfastamento()
        {

            //Arrange
            var postProfissionalSaudeFleury = new PostProfissionalSaudeFleury
            {
                idProfissionalSaude = 404,
                ramalFleury = -222,
                status = 0,
                categoriaFleury = CategoriaFleury.F,
                numeroProntuario = 0,
                nomeEmpresaAssociada = "testeEmpresa",
                dataInicioSocio = "22/10/2022",
                areaInteressePesquisa = "testeArea",
                descricaoResponsabilidade = "teste",
                nomeConjuge = "teste",
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = string.Empty,
                divulgaDataNascimento = 0,
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaudeFleury, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaudeFleury, context, results, true);

            //Assert
            Assert.False(isModelStateValid);
        }




    }
}

