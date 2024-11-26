using App.Application.Interfaces;
using App.Application.Services;
using App.Application.ViewModels.Cripto;
using App.Domain.Interfaces;
using App.Domain.Models;
using App.Domain.Models.Enum;
using App.Test.MockObjects;
using Corporativo.Encrypt.Simetrico;
using Corporativo.Result;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._2_Aplication.Services
{


    public class ProfissionaisSaudeLoginAppServiceTests
    {
        private readonly IProfissionaisSaudeLoginAppService _appService;
        private readonly Mock<IProfissionaisSaudeLoginRepository> _psRepository = new();
        private readonly Mock<IUnitOfWork> _unitOfWork = new();
        private readonly Mock<IAplicacoesRepository> _repoAplicacao = new Mock<IAplicacoesRepository>();

        public ConfigCript _configCript = new ConfigCript { KeyInternal = "vvt38359hrSP1yNnyPTaKHgW" };

        public string keyAesMongo;
        public string keyRSAMongo;

        public ProfissionaisSaudeLoginAppServiceTests()
        {
            _appService = new ProfissionaisSaudeLoginAppService(_repoAplicacao.Object, _unitOfWork.Object, _psRepository.Object, _configCript);

            keyAesMongo = CorpAes.Encrypt("{\r\n   \"key\":\"dfsgtoutnf88559977841231\",\r\n   \"iv\":\"5697824531241854\"\r\n}", _configCript.KeyInternal);

            keyRSAMongo = CorpAes.Encrypt("-----BEGIN RSA PRIVATE KEY-----\r\nMIIEowIBAAKCAQEAnVI81za77FiDcNCd9iD2J4ZfZFMj4Sq2VKrt7Szuc5B7HdOh\r\nd5/7M3POD9fxtgYqRkx/0R25h1lBOOpNbbA7bwJJZOoNEvYy/UM/OxSh+jrvpYYA\r\n7mvfdIN/dHxcqoHZ73T+3208ldRzb13SayVJjwIEqNtfYKyOWaW2dtXxNHgRUH/Y\r\nf4ventdKTIeCEAM5XD0gnytjM1d2tqNrjFA5inbkls3tSlDlRXmubtImtw//GLuh\r\nquV/L7SONBp0hm8enqtfLzYkEEnt6iOV3SWr+2PZz07l5lR0lg73/eJxNGUSApmV\r\nnvntA8A0tfeFd2MkNa+SSOvYf1IMeIwsBJT5iwIDAQABAoIBAQCcunMWTNcG7F92\r\nIr9blxbj5YBfKFzUU4L18pu570tXIhclbdKspFrTtYkSS6XoG1g+VLP5ls1gQ9Ew\r\nbGva3Pk47GRF/s4rl87QdRAnQbTk35Yjps6CuEETiHWPjN2cmGSPpFTOLbtv4Qln\r\nZ2bbi3gu2mnd9z6bxwzBzs9qsFTuWSKoH7wwgM1MoZu7Ll8O2MV4XEZRN6+vFjLM\r\nbczQYnbWA2r8zfqV0yF76Ur3ikIX05qGIww4USQjmPRHFvE2o5N+EUSiDvyyC8gZ\r\nlTBl2WZe2cIdsDWnamlUMYbbo+Wmppe7FNI1h010QqK2a2wFCEBxa0FCn2ynKJKS\r\nIBUmR9FBAoGBAOtJhkiR3+2AvRBFogPJm9YzKs62a0ttPAHTwBouPWlndJK+Kx3L\r\nwKCewyBYunp++oYW9gBcfUSHp0msNSI9C45cfFilleGvBdWXeSw0k4dIi0fAuXE6\r\n284fq4trTVu7LfLM0FtnEaI20igDy7noKBzkviTx8nuxJkrZkagsK2BRAoGBAKsr\r\nqGukkLMjHCF+iFqI12Z7IW3AAvEcLkkYLe3SOyeuqEJNeh8BKg0eTrNpIDzQ8qs2\r\nRoLLuUoYJeRRZbtgy0PHC/AewfH+/S4IKYfUhpVe3b4Pa+9tz1UDhC8AP7YlEAM/\r\nPcLo6N5fLH25uuyolR5pd0tMYoCP8r0Z8AR7qYEbAoGAS9aTFekPCHqqdgg7xITD\r\nWjN75M0foFxBL0WVcdrdqI/UH0h0lVILcLo7or12ve0XywizmkI1jlU7Mp/zMGoE\r\nw4pD+j7FJM1JUCNWx0zbEIvteN9B5qFWIAZNQM8BTEP094HU1uFN6b9J1eQDUpTl\r\n+Qoxz668venHsfCW5mH2SUECgYBEoB1HAtRsrZ/iodtDCOfrE2Sknr3PMvAvp/0K\r\nAyZqU3DsHCng8lOMrOD6tyQQnekc0YbVe54O4b2XWzcBN95mjw/vNjWlswiIgwc7\r\niO5oRn96aq5ocMsWF3HQcjYY7aUM2DcHxN9QADJTObqClVgruDb2vmojhxLX0+VR\r\nts6PjwKBgCaWfpcoXU6vWKg5nWMzuXKb+p1K150A72EQ9cdCzUasAcHtXfKf0rT2\r\naTdXQJ71llTSHwmMfI86+p5s1wJ2X9kBFMooXePy06Hn3bUgcCETdBbTZ9E8x6kI\r\nvd6y9TVqg1vQqHXFy1LOFBnOdD3fd1mHqNnVthCispKtOll2jllv\r\n-----END RSA PRIVATE KEY-----", _configCript.KeyInternal);


        }


        #region validações
        void Setup_GetProfissionalSaudeById(bool isValid = true)
        {

            var profissionalSaude = new Domain.Models.ProfissionalSaude
            {
                ID_PRSA_CD_PROF_SAUDE = 1,
                ID_PEFI_CD_PESSOA_FISICA = 1001,
                ID_CTPF_SL_CATEGORIA = "teste",
                PRSA_NR_CERTIFICADO = "CRM123",
                PRSA_DS_UF_ORIGEM_CERTIFICADO = "SP"
            };


            _psRepository.Setup(x => x.GetProfissionalSaudePrsa(It.IsAny<int>()))
                .ReturnsAsync(isValid ? profissionalSaude : null);
        }

        void Setup_GetLoginIdun(bool isNull = true)
        {
            LoginUsuario result;
            if (isNull)
                result = null;
            else
                result = new LoginUsuario();

            _psRepository.Setup(x => x.GetProfissionalSaudeIdun(It.IsAny<int>()))
                         .ReturnsAsync(result);
        }

        void Setup_AddProfissionalSaude()
        {

            _psRepository.Setup(x => x.AddLoginProfissionalSaude(It.IsAny<LoginUsuario>()))
                 .Returns(Task.CompletedTask);
        }

        void SetupMock(bool isMongo = true, bool isMongoAes = true)
        {
            if (isMongo)
            {
                var item = new AplicacaoBD
                {
                    IdSenhaSegura = "10",
                    Tipo = isMongoAes ? TypeCrypt.AES.ToString() : TypeCrypt.RSA.ToString(),
                    content = isMongoAes ? keyAesMongo : keyRSAMongo
                };
                _repoAplicacao.Setup(_ => _.Detail(It.IsAny<string>(), It.IsAny<int>()))
               .ReturnsAsync(item);
            }

        }
        #endregion

        #region PostLogin
        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "Post Tudo Ok RSA")]
        public async Task PostLogin_TudoOkRSA()
        {
            //Arrange
            SetupMock(true, false);
            Setup_GetProfissionalSaudeById();
            Setup_GetLoginIdun();

            var idProfissionalSaude = MockPostPF.OKIdLogin();
            var postAplicacao = MockPostPF.OKAplicacaoLogin();

            Setup_AddProfissionalSaude();

            //Act
            var result = await _appService.PostLogin(idProfissionalSaude, postAplicacao);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.Created, result.ResultType);
        }

        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "Post Tudo Ok")]
        public async Task PostLogin_TudoOk()
        {
            //Arrange
            SetupMock(true, true);
            Setup_GetProfissionalSaudeById();
            Setup_GetLoginIdun();

            var idProfissionalSaude = MockPostPF.OKIdLogin();
            var postAplicacao = MockPostPF.OKAplicacaoLogin();

            Setup_AddProfissionalSaude();

            //Act
            var result = await _appService.PostLogin(idProfissionalSaude, postAplicacao);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.Created, result.ResultType);
        }

        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "Post Tudo error")]
        public async Task PostLogin_Error()
        {
            SetupMock(false, false);
            Setup_GetProfissionalSaudeById();
            Setup_GetLoginIdun();

            var idProfissionalSaude = MockPostPF.OKIdLogin();
            var postAplicacao = MockPostPF.OKAplicacaoLogin();

            Setup_AddProfissionalSaude();

            //Act
            var result = await _appService.PostLogin(idProfissionalSaude, postAplicacao);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }

        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "Post idPrsa não existe")]
        public async Task PostLogin_PrsaNaoExiste()
        {
            //Arrange
            SetupMock(true, true);
            Setup_GetProfissionalSaudeById(false);
            Setup_GetLoginIdun();

            var idProfissionalSaude = MockPostPF.OKIdLogin();
            var postAplicacao = MockPostPF.OKAplicacaoLogin();

            Setup_AddProfissionalSaude();

            //Act
            var result = await _appService.PostLogin(idProfissionalSaude, postAplicacao);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }

        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "Post idun já existe")]
        public async Task PostLogin_IdunJaExiste()
        {
            //Arrange
            SetupMock(true, true);
            Setup_GetProfissionalSaudeById();
            Setup_GetLoginIdun(false);

            var idProfissionalSaude = MockPostPF.OKIdLogin();
            var postAplicacao = MockPostPF.OKAplicacaoLogin();

            Setup_AddProfissionalSaude();

            //Act
            var result = await _appService.PostLogin(idProfissionalSaude, postAplicacao);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }

        #endregion

        #region Dispose
        [Trait("Categoria", "Dispose")]
        [Fact(DisplayName = "Dipose Ok")]
        public void Dispose_Ok()
        {
            //act
            _appService.Dispose();
            Assert.NotNull(_appService);
        }
        #endregion





    }



}


