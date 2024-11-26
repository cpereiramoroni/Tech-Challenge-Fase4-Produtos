
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
using System.Threading.Tasks;
using Xunit;

namespace App.Test._2_Aplication.Services
{
    public class PsFleuryAppServiceTests
    {
        private readonly IPSFleuryAppService _appService;


        private readonly Mock<IPSRepository> _psRepository = new Mock<IPSRepository>();
        private readonly Mock<IPSFleuryRepository> _psFleuryRepository = new Mock<IPSFleuryRepository>();
        private readonly Mock<IPessoasFisicaRepository> _pefiRepository = new Mock<IPessoasFisicaRepository>();
        private readonly Mock<ILogPSRepository> _logPSRepository = new Mock<ILogPSRepository>();
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();


        public PsFleuryAppServiceTests()
        {
            _appService = new PsFleuryAppService(_unitOfWork.Object, _psRepository.Object, _psFleuryRepository.Object, _pefiRepository.Object, _logPSRepository.Object);
        }


        #region post ProfissionalSaudeFleury
        [Trait("Categoria", "ProfissionaisSaudeFleuryAppService")]
        [Fact(DisplayName = "PostProfissionalSaudeFleury Profissional Saude Fleury Inexistente")]
        public async Task PostProfissionalSaudeFleury_ProfissionalSaudeFleuryInexistente()
        {
            //Arrange
            var postPSF = new PostProfissionalSaudeFleury()
            {
                idProfissionalSaude = 498,
                ramalFleury = 222,
                status = 3,
                categoriaFleury = CategoriaFleury.S,
                numeroProntuario = 0,
                nomeEmpresaAssociada = null,
                dataInicioSocio = "22/10/2022",
                areaInteressePesquisa = null,
                descricaoResponsabilidade = null,
                nomeConjuge = null,
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = null,
                divulgaDataNascimento = Status.Nao
            };

            _psRepository.Setup(x => x.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(new List<ProfissionalSaude>());


            //Act
            var result = await _appService.PostPsFleury(postPSF);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }


        [Trait("Categoria", "ProfissionaisSaudeFleuryAppService")]
        [Fact(DisplayName = "ProfissionaisSaudeFleuryAppService Ja existe")]
        public async Task PostProfissionaisSaudeFleuryAppServiceJaExiste()
        {
            //Arrange            

            var postPSF = new PostProfissionalSaudeFleury()
            {
                idProfissionalSaude = 444,
                ramalFleury = 222,
                status = 3,
                categoriaFleury = CategoriaFleury.S,
                numeroProntuario = 0,
                nomeEmpresaAssociada = null,
                dataInicioSocio = "22/10/2022",
                areaInteressePesquisa = null,
                descricaoResponsabilidade = null,
                nomeConjuge = null,
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = null,
                divulgaDataNascimento = Status.Nao
            };

            _psRepository.Setup(x => x.GetProfissionalSaudeById(It.IsAny<int>())).ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaude>(1));

            _psFleuryRepository.Setup(x => x.GetPSFleuryByIdProfissionalSaude(It.IsAny<int>())).ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaudeFleury>(1));

            //Act            
            var result = await _appService.PostPsFleury(postPSF);

            //Assert            
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }

        [Trait("Categoria", "ProfissionaisSaudeFleuryAppService")]
        [Fact(DisplayName = "Post OK")]
        public async Task Post_OK()
        {
            //Arrange            

            var postPSF = new PostProfissionalSaudeFleury()
            {
                idProfissionalSaude = 444,
                ramalFleury = 222,
                status = 3,
                categoriaFleury = CategoriaFleury.S,
                numeroProntuario = 0,
                nomeEmpresaAssociada = null,
                dataInicioSocio = "22/10/2022",
                areaInteressePesquisa = null,
                descricaoResponsabilidade = null,
                nomeConjuge = null,
                divulgaNomeConjuge = Status.Nao,
                motivoAfastamento = null,
                divulgaDataNascimento = Status.Nao
            };

            _psRepository.Setup(x => x.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaude>(1));

            _psFleuryRepository.Setup(x => x.GetPSFleuryByIdProfissionalSaude(It.IsAny<int>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaudeFleury>(0));

            _psFleuryRepository.Setup(x => x.AddProfissionalSaudeFleury(It.IsAny<ProfissionalSaudeFleury>()));

            _logPSRepository.Setup(x => x.InsertLog(It.IsAny<int>(), It.IsAny<Int16?>(), It.IsAny<int?>(), It.IsAny<bool>()));

            _psRepository.Setup(s => s.GetProfissionaisSaudeByListId(It.IsAny<int>())).ReturnsAsync(

                new ProfissionalSaude { ID_PEFI_CD_PESSOA_FISICA = 100, ID_PRSA_CD_PROF_SAUDE = 101 });

            _pefiRepository.Setup(pf => pf.GetPessoaFisicaById(It.IsAny<int>())).ReturnsAsync(new PessoaFisica { ID_PEFI_CD_PESSOA_FISICA = 101 });

            _pefiRepository.Setup(of => of.UpdatePessoaFisica(It.IsAny<PessoaFisica>()));

            //Act            
            var result = await _appService.PostPsFleury(postPSF);

            //Assert            
            Assert.NotNull(result);
            Assert.Equal(ResultType.Created, result.ResultType);
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
