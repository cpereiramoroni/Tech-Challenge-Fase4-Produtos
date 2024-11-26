using App.Application.ViewModels.Request;
using Corporativo.Util.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace App.Test._2_Aplication.ViewModel.Request
{
    public class PostProfissionalSaudeTests
    {
        [Trait("Categoria", "PostProfissionalSaude")]
        [Fact(DisplayName = "PostProfissionalSaude Valido")]
        public void PostProfissionailSaude_OK()
        {
            //Arrange
            var postProfissionalSaude = new PostProfissionalSaude
            {
                idPessoaFisica = 1,
                permiteParticipacaoPesquisas = Status.Nao,
                permiteParticipacaoEventos = Status.Sim,
                autorizaEnvioEmails = Status.Sim,
                status = 2,
                conselhoRegional = "testeConselho",
                numeroCertificado = "123asd",
                ufCertificado = EstadoSigla.PR,
                localFormacao = "teste",
                indicacao = 1,
                scoreInformado = 1.0m,
                scoreCalculado = 1.2m,
                dataValidadeScore = "22/10/2022",
                descricaoMotivoScore = "descricao",
                unidadeFicha = "121",
                idUsuarioInclusao = 123,
                observacaoInclusao = "observacao"
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaude, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaude, context, results, true);
            //Assert
            Assert.True(isModelStateValid);
        }


        [Trait("Categoria", "PostProfissionalSaude")]
        [Theory(DisplayName = "PostProfissionalSaude NumeroCertificado Invalido")]
        [InlineData("112@3")]
        [InlineData("_sdj12")]
        [InlineData(null)]
        [InlineData("aaaaaaaaaaaaaa")]

        public void PostProfissionailSaude_NumeroCertificado_Invalido(string? NumeroCertificado)
        {
            //Arrange
            var postProfissionalSaude = new PostProfissionalSaude
            {
                idPessoaFisica = 1,
                permiteParticipacaoPesquisas = Status.Nao,
                permiteParticipacaoEventos = Status.Sim,
                autorizaEnvioEmails = Status.Sim,
                status = 2,
                conselhoRegional = "Teste",
                numeroCertificado = NumeroCertificado,
                ufCertificado = EstadoSigla.PR,
                localFormacao = "teste",
                indicacao = 1,
                scoreInformado = 1.0m,
                scoreCalculado = 1.2m,
                dataValidadeScore = "22/10/2022",
                descricaoMotivoScore = "descricao",
                unidadeFicha = "231",
                idUsuarioInclusao = 123,
                observacaoInclusao = "observacao"
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaude, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaude, context, results, true);
            //Assert
            Assert.False(isModelStateValid);
        }



        [Trait("Categoria", "PostProfissionalSaude")]
        [Theory(DisplayName = "PostProfissionalSaude anoFormacao Invalido")]
        //        [InlineData(123)]
        [InlineData(12341)]
        public void PostProfissionailSaude_AnoFormacao_Invalido(int AnoFormacao)
        {

            //Arrange
            var postProfissionalSaude = new PostProfissionalSaude
            {
                idPessoaFisica = 1,
                permiteParticipacaoPesquisas = Status.Nao,
                permiteParticipacaoEventos = Status.Sim,
                autorizaEnvioEmails = Status.Sim,
                status = 2,
                conselhoRegional = "Teste",
                numeroCertificado = "12",
                ufCertificado = EstadoSigla.PR,
                localFormacao = "asdf",
                anoFormacao = AnoFormacao,
                indicacao = 1,
                scoreInformado = 1.0m,
                scoreCalculado = 1.2m,
                dataValidadeScore = "22/10/2022",
                descricaoMotivoScore = "descricao",
                unidadeFicha = "131",
                idUsuarioInclusao = 123,
                observacaoInclusao = "observacao"
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaude, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaude, context, results, true);
            //Assert
            Assert.False(isModelStateValid);
        }

        [Trait("Categoria", "PostProfissionalSaude")]
        [Fact(DisplayName = "PostProfissionalSaude descricaoMotivoScore Invalido")]

        public void PostProfissionailSaude_descricaoMotivoScore_Invalido()
        {

            //Arrange

            var descricao = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            var postProfissionalSaude = new PostProfissionalSaude
            {
                idPessoaFisica = 1,
                permiteParticipacaoPesquisas = Status.Nao,
                permiteParticipacaoEventos = Status.Sim,
                autorizaEnvioEmails = Status.Sim,
                status = 2,
                conselhoRegional = "Teste",
                numeroCertificado = "12",
                ufCertificado = EstadoSigla.PR,
                localFormacao = "asdf",
                anoFormacao = 1998,
                indicacao = 1,
                scoreInformado = 1.0m,
                scoreCalculado = 1.2m,
                dataValidadeScore = "22/10/2022",
                descricaoMotivoScore = descricao,
                unidadeFicha = "121",
                idUsuarioInclusao = 123,
                observacaoInclusao = "observacao"
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaude, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaude, context, results, true);
            //Assert
            Assert.False(isModelStateValid);
        }

        [Trait("Categoria", "PostProfissionalSaude")]
        [Theory(DisplayName = "PostProfissionalSaude idUnidade Invalido")]
        [InlineData("1234")]
        [InlineData("11a")]
        [InlineData("asd")]

        public void PostProfissionailSaude_idUnidade_Invalido(string idUnidade)
        {

            //Arrange
            var postProfissionalSaude = new PostProfissionalSaude
            {
                idPessoaFisica = 1,
                permiteParticipacaoPesquisas = Status.Nao,
                permiteParticipacaoEventos = Status.Sim,
                autorizaEnvioEmails = Status.Sim,
                status = 2,
                conselhoRegional = "Teste",
                numeroCertificado = "12",
                ufCertificado = EstadoSigla.PR,
                localFormacao = "asdf",
                anoFormacao = 1998,
                indicacao = 1,
                scoreInformado = 1.0m,
                scoreCalculado = 1.2m,
                dataValidadeScore = "22/10/2022",
                descricaoMotivoScore = "descricao",
                unidadeFicha = idUnidade,
                idUsuarioInclusao = 123,
                observacaoInclusao = "observacao"
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaude, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaude, context, results, true);
            //Assert
            Assert.False(isModelStateValid);
        }

        [Trait("Categoria", "PostProfissionalSaude")]
        [Theory(DisplayName = "PostProfissionalSaude numeroFicha Invalido")]
        [InlineData("12345678")]
        [InlineData("teste")]

        public void PostProfissionailSaude_numeroFicha_Invalido(string NumeroFicha)
        {

            //Arrange
            var postProfissionalSaude = new PostProfissionalSaude
            {
                idPessoaFisica = 1,
                permiteParticipacaoPesquisas = Status.Nao,
                permiteParticipacaoEventos = Status.Sim,
                autorizaEnvioEmails = Status.Sim,
                status = 2,
                conselhoRegional = "Teste",
                numeroCertificado = "12",
                ufCertificado = EstadoSigla.PR,
                localFormacao = "asdf",
                anoFormacao = 1998,
                indicacao = 1,
                scoreInformado = 1.0m,
                scoreCalculado = 1.2m,
                dataValidadeScore = "22/10/2022",
                descricaoMotivoScore = "descricao",
                unidadeFicha = "123",
                numeroFicha = NumeroFicha,
                idUsuarioInclusao = 123,
                observacaoInclusao = "observacao"
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaude, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaude, context, results, true);
            //Assert
            Assert.False(isModelStateValid);
        }

        [Trait("Categoria", "PostProfissionalSaude")]
        [Fact(DisplayName = "PostProfissionalSaude observacaoInclusao Invalido")]

        public void PostProfissionailSaude_observacaoInclusao_Invalido()
        {
            var observacao = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            //Arrange
            var postProfissionalSaude = new PostProfissionalSaude
            {
                idPessoaFisica = 1,
                permiteParticipacaoPesquisas = Status.Nao,
                permiteParticipacaoEventos = Status.Sim,
                autorizaEnvioEmails = Status.Sim,
                status = 2,
                conselhoRegional = "Teste",
                numeroCertificado = "12",
                ufCertificado = EstadoSigla.PR,
                localFormacao = "asdf",
                anoFormacao = 1998,
                indicacao = 1,
                scoreInformado = 1.0m,
                scoreCalculado = 1.2m,
                dataValidadeScore = "22/10/2022",
                descricaoMotivoScore = "descricao",
                unidadeFicha = "123",
                numeroFicha = observacao,
                idUsuarioInclusao = 123,
                observacaoInclusao = "observacao"
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaude, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaude, context, results, true);

            //Assert
            Assert.False(isModelStateValid);
        }

        [Trait("Categoria", "PostProfissionalSaude")]
        [Fact(DisplayName = "PostProfissionalSaude dataValidadeScore Invalido")]

        public void PostProfissionailSaude_dataValidadeScore_Invalido()
        {
            var observacao = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            //Arrange
            var postProfissionalSaude = new PostProfissionalSaude
            {
                idPessoaFisica = 1,
                permiteParticipacaoPesquisas = Status.Nao,
                permiteParticipacaoEventos = Status.Sim,
                autorizaEnvioEmails = Status.Sim,
                status = 2,
                conselhoRegional = "Teste",
                numeroCertificado = "12",
                ufCertificado = EstadoSigla.PR,
                localFormacao = "asdf",
                anoFormacao = 1998,
                indicacao = 1,
                scoreInformado = 1.0m,
                scoreCalculado = 1.2m,
                dataValidadeScore = "22-10-2022",
                descricaoMotivoScore = "descricao",
                unidadeFicha = "123",
                numeroFicha = observacao,
                idUsuarioInclusao = 123,
                observacaoInclusao = "observacao"
            };
            //Act
            ValidationContext context = new ValidationContext(postProfissionalSaude, null, null);
            List<ValidationResult> results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(postProfissionalSaude, context, results, true);

            //Assert
            Assert.False(isModelStateValid);
        }
    }
}

