using App.Application.Interfaces;
using App.Application.Services;
using App.Application.ViewModels.Request;
using App.Domain.Interfaces;
using App.Domain.Models;
using App.Test.MockObjects;
using Corporativo.Result;
using Corporativo.Util.Enum;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._2_Aplication.Services
{
    public class PSAppServiceTests
    {
        public IPSAppService _appService;

        private readonly Mock<IPSRepository> _PSRepository = new Mock<IPSRepository>();
        private readonly Mock<ICategoriasRepository> _CategoriasRepository = new Mock<ICategoriasRepository>();
        private readonly Mock<IPSFleuryRepository> _PSFleuryRepository = new Mock<IPSFleuryRepository>();
        private readonly Mock<IPessoasFisicaRepository> _PessoasFisicaRepository = new Mock<IPessoasFisicaRepository>();
        private readonly Mock<IUsuariosRepository> _UsuariosRepository = new Mock<IUsuariosRepository>();
        private readonly Mock<ILogPSRepository> _LogPSRepository = new Mock<ILogPSRepository>();

        private readonly Mock<IUnitOfWork> _IUnitOfWork = new Mock<IUnitOfWork>();
        private readonly Mock<ITermoAceiteRepository> _termoAceiteRepository = new Mock<ITermoAceiteRepository>();

        public PSAppServiceTests()
        {
            _appService = new PSAppService(_PSRepository.Object,
                                           _CategoriasRepository.Object,
                                           _PSFleuryRepository.Object,
                                           _PessoasFisicaRepository.Object,
                                           _UsuariosRepository.Object,
                                           _LogPSRepository.Object,
                                           _IUnitOfWork.Object,
                                           _termoAceiteRepository.Object);
        }
        #region Setups Valitation
        void Setup_GetCategoriaBySigla(bool isValid = true)
        {
            var itemRtn = BaseMockTest.NewModelMock<Categoria>(isValid);
            _CategoriasRepository.Setup(x => x.GetCategoriaBySigla(It.IsAny<string>()))
                .ReturnsAsync(itemRtn);
        }
        void Setup_GetProfissionalSaudeById(bool isValid = true)
        {
            var itemRtn = BaseMockTest.NewModelMock<ProfissionalSaudeFleury>(isValid);
            _PSFleuryRepository.Setup(x => x.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(itemRtn);
        }
        void Setup_GetPessoaFisicaById(bool isValid = true)
        {
            var itemRtn = BaseMockTest.NewModelMock<PessoaFisica>(isValid);
            _PessoasFisicaRepository.Setup(x => x.GetPessoaFisicaById(It.IsAny<int>()))
                .ReturnsAsync(itemRtn);
        }
        void Setup_GetPSByIdPefi(bool isCadastrado = true)
        {
            IList<ProfissionalSaude> itemRtn;
            if (isCadastrado)
                itemRtn = BaseMockTest.ListNewModelMock<ProfissionalSaude>(10);
            else
                itemRtn = new List<ProfissionalSaude>();

            _PSRepository.Setup(x => x.GetPSByIdPefi(It.IsAny<int>()))
                .ReturnsAsync(itemRtn);
        }

        void Setup_GetPSByConselhoUf(bool isCadastrado = false)
        {
            IList<ProfissionalSaude> itemRtn = new List<ProfissionalSaude>();

            if (isCadastrado)
                itemRtn = BaseMockTest.ListNewModelMock<ProfissionalSaude>(10);


            _PSRepository.Setup(x => x.GetPSByConselhoUf(It.IsIn<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(itemRtn);

            _PSRepository.Setup(x => x.GetPSByConselhoUf(EstadoSigla.PR.ToString(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(itemRtn);
        }

        void Setup_GetById(bool isValid = true)
        {
            var itemRtn = BaseMockTest.NewModelMock<Usuario>(isValid);
            _UsuariosRepository.Setup(x => x.GetById(It.IsAny<int>()))
                .ReturnsAsync(itemRtn);
        }

        void Setup_GetFichaItem(bool isValid = true)
        {
            var itemRtn = BaseMockTest.NewModelMock<TermoAceiteBD>(isValid);
            _termoAceiteRepository.Setup(x => x.GetFichaItem(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(itemRtn);
        }

        void Setup_GetStatus(bool isValid = true)
        {
            var itemRtn = BaseMockTest.NewModelMock<TermoAceiteBD>(isValid);
            _termoAceiteRepository.Setup(x => x.GetStatus(It.IsAny<int?>()))
                .ReturnsAsync(itemRtn);
        }

        void Setup_GetTermos(bool isValid = false)
        {
            var itemRtn = BaseMockTest.NewModelMock<TermoAceiteBD>(isValid);
            _termoAceiteRepository.Setup(x => x.GetTermos(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(itemRtn);
        }

        void Setup_GetProfissionaisSaudeByListId(bool isValid = true)
        {
            var itemRtn = BaseMockTest.NewModelMock<ProfissionalSaude>(isValid);
            _PSRepository.Setup(x => x.GetProfissionaisSaudeByListId(It.IsAny<int>()))
                .ReturnsAsync(itemRtn);
        }

        #endregion

        #region Setups Save
        void Setup_AddProfissionalSaude()
        {
            var itemRtn = BaseMockTest.NewModelMock<ProfissionalSaude>();
            _PSRepository.Setup(x => x.AddProfissionalSaude(It.IsAny<ProfissionalSaude>()));
        }

        void Setup_UpdateProfissionalSaude()
        {
            var itemRtn = BaseMockTest.NewModelMock<ProfissionalSaude>();
            _PSRepository.Setup(x => x.UpdateProfissionalSaude(It.IsAny<ProfissionalSaude>()));
        }

        void Setup_InsertLog()
        {
            var itemRtn = BaseMockTest.NewModelMock<ProfissionalSaude>();
            _LogPSRepository.Setup(x => x.InsertLog(It.IsAny<int>(), It.IsAny<Int16?>(), It.IsAny<int?>(), It.IsAny<bool>()));
        }

        void Setup_InsertLog_Error()
        {
            _LogPSRepository.Setup(x => x.InsertLog(It.IsAny<int>(), It.IsAny<Int16?>(), It.IsAny<int?>(), It.IsAny<bool>()))
                .ThrowsAsync(new Exception("Erro Ao Inserir no Log "));

        }

        void Setup_AddTermoAceite()
        {
            var itemRtn = BaseMockTest.NewModelMock<TermoAceiteBD>();
            _termoAceiteRepository.Setup(x => x.AddTermoAceite(It.IsAny<TermoAceiteBD>()));
        }
        #endregion

        #region Post
        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "Post Tudo Ok")]
        public async Task Post_TudoOk()
        {
            //Arrange
            Setup_GetCategoriaBySigla();
            Setup_GetProfissionalSaudeById();
            Setup_GetPessoaFisicaById();
            Setup_GetPSByIdPefi(false);

            Setup_GetById();



            Setup_AddProfissionalSaude();

            Setup_UpdateProfissionalSaude();
            Setup_InsertLog();

            Setup_GetPSByConselhoUf();

            var itemPost = MockPostPF.OK().First();


            //Act
            var result = await _appService.Post(itemPost);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.Created, result.ResultType);
        }

        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "Post Exception Log deve ser OK")]
        public async Task Post_Tudo_Ok_memso_ErroLOg()
        {
            //Arrange
            Setup_GetCategoriaBySigla();
            Setup_GetProfissionalSaudeById();
            Setup_GetPessoaFisicaById();
            Setup_GetPSByIdPefi(false);

            Setup_GetById();
            Setup_AddProfissionalSaude();
            Setup_UpdateProfissionalSaude();
            Setup_GetPSByConselhoUf();

            Setup_InsertLog_Error();

            var itemPost = MockPostPF.OK().First();

            //Act
            var result = await _appService.Post(itemPost);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.Created, result.ResultType);
        }

        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "Post SiglaErrada ")]
        public async Task Post_SiglaErrada()
        {
            //Arrange
            Setup_GetCategoriaBySigla(false);

            var itemPost = MockPostPF.OK().First();

            //Act
            var result = await _appService.Post(itemPost);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }


        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "Post PsIndicacaoErrada ")]
        public async Task Post_PsIndicacaoErrada()
        {
            //Arrange


            Setup_GetCategoriaBySigla();
            Setup_GetProfissionalSaudeById(false);

            var itemPost = MockPostPF.OK().First();
            itemPost.indicacao = 10;

            //Act
            var result = await _appService.Post(itemPost);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }


        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "Post PFErrada ")]
        public async Task Post_PFERRADA()
        {
            //Arrange


            Setup_GetCategoriaBySigla();
            Setup_GetProfissionalSaudeById();
            Setup_GetPessoaFisicaById(false);

            var itemPost = MockPostPF.OK().First();

            //Act
            var result = await _appService.Post(itemPost);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }


        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "Post GetPSByIdPefiErrado ")]
        public async Task Post_GetPSByIdPefiERRADA()
        {
            //Arrange


            Setup_GetCategoriaBySigla();
            Setup_GetProfissionalSaudeById();
            Setup_GetPessoaFisicaById();
            Setup_GetPSByIdPefi(isCadastrado: true);


            var itemPost = MockPostPF.OK().First();

            //Act
            var result = await _appService.Post(itemPost);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }


        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "Post GetPSByConselhoUfErrada ")]
        public async Task Post_GetPSByConselhoUfERRADA()
        {
            //Arrange


            Setup_GetCategoriaBySigla();
            Setup_GetProfissionalSaudeById();
            Setup_GetPessoaFisicaById();
            Setup_GetPSByIdPefi(false);
            Setup_GetPSByConselhoUf(isCadastrado: true);

            var itemPost = MockPostPF.OK().First();

            //Act
            var result = await _appService.Post(itemPost);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }


        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "Post _GetByIdERRADAUsuarioInclusao ")]
        public async Task Post_GetByIdERRADAUsuarioInclusao()
        {
            //Arrange

            Setup_GetCategoriaBySigla();
            Setup_GetProfissionalSaudeById();
            Setup_GetPessoaFisicaById();
            Setup_GetPSByIdPefi(false);
            Setup_GetPSByConselhoUf();
            Setup_GetById(false);

            var itemPost = MockPostPF.OK().First();

            //Act
            var result = await _appService.Post(itemPost);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }


        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "Post _GetByIdZeroUsuarioInclusao ")]
        public async Task Post_GetByIdZeroUsuarioInclusao()
        {
            //Arrange

            Setup_GetCategoriaBySigla();
            Setup_GetProfissionalSaudeById();
            Setup_GetPessoaFisicaById();
            Setup_GetPSByIdPefi(false);
            Setup_GetPSByConselhoUf();
            Setup_GetById(true);

            var itemPost = MockPostPF.OK().First();

            itemPost.idUsuarioInclusao = 0;

            //Act
            var result = await _appService.Post(itemPost);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.Created, result.ResultType);
        }


        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "Post _GetByIdZeroUsuarioInclusao ")]
        public async Task Post_GetByIdZeroUsuarioInclusao_null()
        {
            //Arrange

            Setup_GetCategoriaBySigla();
            Setup_GetProfissionalSaudeById();
            Setup_GetPessoaFisicaById();
            Setup_GetPSByIdPefi(false);
            Setup_GetPSByConselhoUf();
            Setup_GetById(true);

            var itemPost = MockPostPF.OK().First();

            itemPost.idUsuarioInclusao = null;

            //Act
            var result = await _appService.Post(itemPost);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.Created, result.ResultType);
        }





        #endregion

        #region Post Termo Aceite
        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "PostTermoAceite Tudo Ok")]
        public async Task PostTermoAceite_TudoOk()
        {
            //Arrange
            Setup_GetProfissionaisSaudeByListId();
            Setup_GetFichaItem();
            Setup_GetStatus();
            Setup_GetTermos();

            Setup_AddTermoAceite();

            var id = MockPostPF.OKIdLogin();
            var itemPost = MockPostPF.OkTermo();


            //Act
            var result = await _appService.PostTermoAceite(id, itemPost);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.Created, result.ResultType);
        }


        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "PostTermoAceite PRSA nao existe")]
        public async Task PostTermoAceite_IdPrsaNaoExiste()
        {
            //Arrange
            Setup_GetProfissionaisSaudeByListId(false);
            Setup_GetFichaItem();
            Setup_GetStatus();
            Setup_GetTermos();

            Setup_AddTermoAceite();

            var id = MockPostPF.OKIdLogin();
            var itemPost = MockPostPF.OkTermo();


            //Act
            var result = await _appService.PostTermoAceite(id, itemPost);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }

        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "PostTermoAceite idFicha e idItem nao existem")]
        public async Task PostTermoAceite_IdFichaItemNaoExistem()
        {
            //Arrange
            Setup_GetProfissionaisSaudeByListId();
            Setup_GetFichaItem(false);
            Setup_GetStatus();
            Setup_GetTermos();

            Setup_AddTermoAceite();

            var id = MockPostPF.OKIdLogin();
            var itemPost = MockPostPF.OkTermo();


            //Act
            var result = await _appService.PostTermoAceite(id, itemPost);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }

        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "PostTermoAceite idStatus nao existe")]
        public async Task PostTermoAceite_IdStatusNaoExiste()
        {
            //Arrange
            Setup_GetProfissionaisSaudeByListId();
            Setup_GetFichaItem();
            Setup_GetStatus(false);
            Setup_GetTermos();

            Setup_AddTermoAceite();

            var id = MockPostPF.OKIdLogin();
            var itemPost = MockPostPF.OkTermo();


            //Act
            var result = await _appService.PostTermoAceite(id, itemPost);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }


        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "PostTermoAceite ja existe termo")]
        public async Task PostTermoAceite_JaExisteTermo()
        {
            //Arrange
            Setup_GetProfissionaisSaudeByListId();
            Setup_GetFichaItem();
            Setup_GetStatus();
            Setup_GetTermos(true);

            Setup_AddTermoAceite();

            var id = MockPostPF.OKIdLogin();
            var itemPost = MockPostPF.OkTermo();


            //Act
            var result = await _appService.PostTermoAceite(id, itemPost);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }

        #endregion

        #region Patch ProfissionalSaude
        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "PatchProfissionalSaude Tudo Ok")]
        public async Task PatchProfissionalSaude_TudoOk()
        {
            Setup_GetProfissionalSaudeById();
            Setup_GetCategoriaBySigla();
            Setup_GetById();

            //Arrange
            var idPS = new IdProfissionalSaude
            {
                idProfissionalSaude = 2
            };

            var patch = new PatchProfissionalSaude
            {
                idUsuarioAlteracao = 123,
                motivoAlteracao = "motivo",
                conselhoRegional = "CRM",
                ufCertificado = "SP",
                idStatus = 5
            };

            Setup_UpdateProfissionalSaude();

            var result = await _appService.PatchProfissionalSaude(idPS, patch);

            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }

        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "PatchProfissionalSaude PRSA nao existe")]
        public async Task PatchProfissionalSaude_IdPrsaNaoExiste()
        {
            //Arrange
            Setup_GetProfissionalSaudeById(false);
            Setup_GetCategoriaBySigla();
            Setup_GetById();

            var idPS = new IdProfissionalSaude
            {
                idProfissionalSaude = 2
            };

            var patch = new PatchProfissionalSaude
            {
                idUsuarioAlteracao = 123,
                motivoAlteracao = "motivo",
                conselhoRegional = "CRM",
                idStatus = 5
            };

            Setup_UpdateProfissionalSaude();

            //Act
            var result = await _appService.PatchProfissionalSaude(idPS, patch);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }

        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "PatchProfissionalSaude idUsuarioAlteracao nao existe")]
        public async Task PatchProfissionalSaude_IdUsuaNaoExiste()
        {
            //Arrange
            Setup_GetProfissionalSaudeById();
            Setup_GetCategoriaBySigla();
            Setup_GetById(false);

            var idPS = new IdProfissionalSaude
            {
                idProfissionalSaude = 2
            };

            var patch = new PatchProfissionalSaude
            {
                idUsuarioAlteracao = 257,
                motivoAlteracao = "motivo",
                conselhoRegional = "CRM",
                idStatus = 5
            };

            Setup_UpdateProfissionalSaude();

            //Act
            var result = await _appService.PatchProfissionalSaude(idPS, patch);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }

        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "PatchProfissionalSaude CTPF nao existe")]
        public async Task PatchProfissionalSaude_CTPFNaoExiste()
        {
            //Arrange
            Setup_GetProfissionalSaudeById();
            Setup_GetCategoriaBySigla(false);
            Setup_GetById();

            var idPS = new IdProfissionalSaude
            {
                idProfissionalSaude = 2
            };

            var patch = new PatchProfissionalSaude
            {
                idUsuarioAlteracao = 123,
                motivoAlteracao = "motivo",
                conselhoRegional = "NAO",
                idStatus = 5
            };

            Setup_UpdateProfissionalSaude();

            //Act
            var result = await _appService.PatchProfissionalSaude(idPS, patch);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }

        [Trait("Categoria", "PSAppService")]
        [Fact(DisplayName = "PatchProfissionalSaude UfInvalida")]
        public async Task PatchProfissionalSaude_UfInvalida()
        {
            //Arrange
            Setup_GetProfissionalSaudeById();
            Setup_GetCategoriaBySigla();
            Setup_GetById();

            var idPS = new IdProfissionalSaude
            {
                idProfissionalSaude = 2
            };

            var patch = new PatchProfissionalSaude
            {
                idUsuarioAlteracao = 123,
                motivoAlteracao = "motivo",
                conselhoRegional = "CRM",
                ufCertificado = "AA",
                idStatus = 5
            };

            Setup_UpdateProfissionalSaude();

            //Act
            var result = await _appService.PatchProfissionalSaude(idPS, patch);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }
        #endregion

        #region [Dispose]
        [Trait("Categoria", "Service")]
        [Fact(DisplayName = "Dispose ")]
        public void Dispose()
        {
            //act
            _appService.Dispose();
            Assert.NotNull(_appService);

        }

        #endregion
    }
}
