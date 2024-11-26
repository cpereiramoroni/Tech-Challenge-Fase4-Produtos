using App.Application.Interfaces;
using App.Application.Services;
using App.Application.ViewModels.Request;
using App.Domain.Interfaces;
using App.Domain.Models;
using App.Test.MockObjects;
using Corporativo.Result;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._2_Aplication.Services
{
    public class ProfissionaisSaudeEspecialidadesAppServiceTests
    {
        public IProfissionaisSaudeEspecialidadesAppService _appService;

        private readonly Mock<IProfissionaisEspecialidadesRepository> _psEsRepository = new Mock<IProfissionaisEspecialidadesRepository>();
        private readonly Mock<IEspecialidadesRepository> _especialidadesRepository = new Mock<IEspecialidadesRepository>();
        private readonly Mock<IUsuariosRepository> _usuaRepository = new();
        private readonly Mock<IPSRepository> _psRepository = new Mock<IPSRepository>();
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();

        public ProfissionaisSaudeEspecialidadesAppServiceTests()
        {
            _appService = new ProfissionaisSaudeEspecialidadesAppService(_unitOfWork.Object, _especialidadesRepository.Object, _psEsRepository.Object, _psRepository.Object, _usuaRepository.Object);
        }


        #region Post
        [Trait("Categoria", "ProfissionaisSaudeEspecialidadeAppService")]
        [Fact(DisplayName = "PostProfissionalEspecialidade Tudo Ok")]
        public async Task PostProfissionalEspecialidade_TudoOk()
        {
            //Arrange
            var profissionalSaude = new IdProfissionalSaude
            {
                idProfissionalSaude = 1
            };
            var especialidade = new IdEspecialidade
            {
                idEspecialidade = "1,2,3"
            };
            //Arrange
            var postEspecialidade = new ProfissionalEspecialidades
            {
                motivoAlteracao = "teste",
                idUsuarioAlteracao = 123
            };
            var usuarioBd = BaseMockTest.NewModelMock<Usuario>(true);
            _usuaRepository.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(usuarioBd);

            _especialidadesRepository.Setup(x => x.GetEspecialidadesById(It.IsAny<List<int>>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<Especialidade>(1));
            _psRepository.Setup(x => x.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaude>(1));
            _psEsRepository.Setup(x => x.GetEspecialidadesCadastradas(It.IsAny<List<int>>(), It.IsAny<List<int>>()))
                .ReturnsAsync(new List<ProfissionalSaudeEspecialidade>());
            _psEsRepository.Setup(x => x.InserirProfissionaisEspecialidades(It.IsAny<List<ProfissionalSaudeEspecialidade>>()))
                .Returns(Task.CompletedTask);


            //Act
            var result = await _appService.Post(profissionalSaude, especialidade, postEspecialidade);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.Created, result.ResultType);
        }

        [Trait("Categoria", "ProfissionaisSaudeEspecialidadeAppService")]
        [Fact(DisplayName = "PostProfissionalEspecialidade idUsuarioAlteracao Inexistente")]
        public async Task PostProfissionalEspecialidade_idUsuarioAlteracao_Inexistente()
        {
            //Arrange
            var profissionalSaude = new IdProfissionalSaude
            {
                idProfissionalSaude = 1
            };
            var especialidade = new IdEspecialidade
            {
                idEspecialidade = "1,2,3"
            };
            //Arrange
            var postEspecialidade = new ProfissionalEspecialidades
            {
                motivoAlteracao = "teste",
                idUsuarioAlteracao = 123
            };


            _especialidadesRepository.Setup(x => x.GetEspecialidadesById(It.IsAny<List<int>>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<Especialidade>(1));
            _psRepository.Setup(x => x.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaude>(1));
            _psEsRepository.Setup(x => x.GetEspecialidadesCadastradas(It.IsAny<List<int>>(), It.IsAny<List<int>>()))
                .ReturnsAsync(new List<ProfissionalSaudeEspecialidade>());
            _psEsRepository.Setup(x => x.InserirProfissionaisEspecialidades(It.IsAny<List<ProfissionalSaudeEspecialidade>>()))
                .Returns(Task.CompletedTask);


            //Act
            var result = await _appService.Post(profissionalSaude, especialidade, postEspecialidade);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }



        [Trait("Categoria", "ProfissionaisSaudeEspecialidadeAppService")]
        [Fact(DisplayName = "PostProfissionalEspecialidade motivoAlteracao idUsuario null")]
        public async Task PostProfissionalEspecialidade_motivoAlt_idUsua_null()
        {
            //Arrange
            var profissionalSaude = new IdProfissionalSaude
            {
                idProfissionalSaude = 1
            };
            var especialidade = new IdEspecialidade
            {
                idEspecialidade = "1,2,3"
            };
            //Arrange
            var postEspecialidade = new ProfissionalEspecialidades();
            var usuarioBd = BaseMockTest.NewModelMock<Usuario>(true);
            _usuaRepository.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(usuarioBd);
            _especialidadesRepository.Setup(x => x.GetEspecialidadesById(It.IsAny<List<int>>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<Especialidade>(1));
            _psRepository.Setup(x => x.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaude>(1));
            _psEsRepository.Setup(x => x.GetEspecialidadesCadastradas(It.IsAny<List<int>>(), It.IsAny<List<int>>()))
                .ReturnsAsync(new List<ProfissionalSaudeEspecialidade>());
            _psEsRepository.Setup(x => x.InserirProfissionaisEspecialidades(It.IsAny<List<ProfissionalSaudeEspecialidade>>()))
                .Returns(Task.CompletedTask);


            //Act
            var result = await _appService.Post(profissionalSaude, especialidade, postEspecialidade);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.Created, result.ResultType);
        }

        [Trait("Categoria", "ProfissionaisSaudeEspecialidadeAppService")]
        [Fact(DisplayName = "PostProfissionalEspecialidade Profissional Saude Inexistente")]
        public async Task PostProfissionalEspecialidade_ProfissionalSaudeInexistente()
        {
            //Arrange
            var profissionalSaude = new IdProfissionalSaude
            {
                idProfissionalSaude = 1
            };
            var especialidade = new IdEspecialidade
            {
                idEspecialidade = "1,2,3"
            };
            //Arrange
            var postEspecialidade = new ProfissionalEspecialidades
            {
                motivoAlteracao = "teste",
                idUsuarioAlteracao = 123
            };
            var usuarioBd = BaseMockTest.NewModelMock<Usuario>(true);
            _usuaRepository.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(usuarioBd);

            _psRepository.Setup(x => x.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(new List<ProfissionalSaude>());

            //Act
            var result = await _appService.Post(profissionalSaude, especialidade, postEspecialidade);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }


        [Trait("Categoria", "ProfissionaisSaudeEspecialidadeAppService")]
        [Fact(DisplayName = "PostProfissionalEspecialidades Especialidade Inexistente")]
        public async Task PostProfissionalEspecialidades_EspecialidadeInexistente()
        {
            //Arrange
            var profissionalSaude = new IdProfissionalSaude
            {
                idProfissionalSaude = 1
            };
            var especialidade = new IdEspecialidade
            {
                idEspecialidade = "1,2,3"
            };
            //Arrange
            var postEspecialidade = new ProfissionalEspecialidades
            {
                motivoAlteracao = "teste",
                idUsuarioAlteracao = 123
            };
            var usuarioBd = BaseMockTest.NewModelMock<Usuario>(true);
            _usuaRepository.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(usuarioBd);
            _psRepository.Setup(x => x.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaude>(1));
            _especialidadesRepository.Setup(x => x.GetEspecialidadesById(It.IsAny<List<int>>()))
                .ReturnsAsync(new List<Especialidade>());

            //Act
            var result = await _appService.Post(profissionalSaude, especialidade, postEspecialidade);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }

        [Trait("Categoria", "ProfissionaisSaudeEspecialidadeAppService")]
        [Fact(DisplayName = "PostProfissionalEspecialidade Especialidade Ja Vinculada")]
        public async Task PostProfissionalEspecialidade_EspecialidadeJaVinculada()
        {
            //Arrange
            var profissionalSaude = new IdProfissionalSaude
            {
                idProfissionalSaude = 1
            };
            var especialidade = new IdEspecialidade
            {
                idEspecialidade = "1,2,3"
            };
            //Arrange
            var postEspecialidade = new ProfissionalEspecialidades
            {
                motivoAlteracao = "teste",
                idUsuarioAlteracao = 123
            };
            var usuarioBd = BaseMockTest.NewModelMock<Usuario>(true);
            _usuaRepository.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(usuarioBd);

            _psRepository.Setup(x => x.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaude>(1));
            _especialidadesRepository.Setup(x => x.GetEspecialidadesById(It.IsAny<List<int>>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<Especialidade>(1));
            _psEsRepository.Setup(x => x.GetEspecialidadesCadastradas(It.IsAny<List<int>>(), It.IsAny<List<int>>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaudeEspecialidade>(1));


            //Act
            var result = await _appService.Post(profissionalSaude, especialidade, postEspecialidade);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }
        #endregion

        #region Delete
        [Trait("Categoria", "ProfissionalSaudeEspecialidadeAppService")]
        [Fact(DisplayName = "DeleteEspecialidade Ok")]
        public async Task DeleteEspecialidade_Ok()
        {
            //Arrange
            var profissionalSaude = new IdProfissionalSaude
            {
                idProfissionalSaude = 1
            };
            var especialidade = new DeleteEspecialidade
            {
                idUsuarioAlteracao = 1,
                motivoAlteracao = "teste",
                idEspecialidade = "1,2"
            };

            var listVinculos = new List<ProfissionalSaudeEspecialidade>();
            foreach (var idEsp in especialidade.idEspecialidade.Split(","))
            {
                listVinculos.Add(new ProfissionalSaudeEspecialidade
                {
                    ID_ESPE_CD_ESPEC_MED = int.Parse(idEsp),
                    ID_PRSA_CD_PROF_SAUDE = profissionalSaude.idProfissionalSaude
                });
            }
            var usuarioBd = BaseMockTest.NewModelMock<Usuario>(true);
            _usuaRepository.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(usuarioBd);

            _psRepository.Setup(r => r.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaude>(1));
            _psEsRepository.Setup(r => r.GetEspecialidadesCadastradas(It.IsAny<List<int>>(), It.IsAny<List<int>>()))
                .ReturnsAsync(listVinculos);

            //Act
            var result = await _appService.DeleteEspecialidade(profissionalSaude, especialidade);

            //Assert
            Assert.Equal(ResultType.Success, result.ResultType);
        }

        [Trait("Categoria", "ProfissionalSaudeEspecialidadeAppService")]
        [Fact(DisplayName = "DeleteEspecialidade idUsuarioAlteracao Inexistente")]
        public async Task DeleteEspecialidade_idUsuarioAlteracao_Inexistente()
        {
            //Arrange
            var profissionalSaude = new IdProfissionalSaude
            {
                idProfissionalSaude = 1
            };
            var especialidade = new DeleteEspecialidade
            {
                idUsuarioAlteracao = 1,
                motivoAlteracao = "teste",
                idEspecialidade = "1,2"
            };

            var listVinculos = new List<ProfissionalSaudeEspecialidade>();
            foreach (var idEsp in especialidade.idEspecialidade.Split(","))
            {
                listVinculos.Add(new ProfissionalSaudeEspecialidade
                {
                    ID_ESPE_CD_ESPEC_MED = int.Parse(idEsp),
                    ID_PRSA_CD_PROF_SAUDE = profissionalSaude.idProfissionalSaude
                });
            }
            _psRepository.Setup(r => r.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaude>(1));
            _psEsRepository.Setup(r => r.GetEspecialidadesCadastradas(It.IsAny<List<int>>(), It.IsAny<List<int>>()))
                .ReturnsAsync(listVinculos);

            //Act
            var result = await _appService.DeleteEspecialidade(profissionalSaude, especialidade);

            //Assert
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }


        [Trait("Categoria", "ProfissionalSaudeEspecialidadeAppService")]
        [Fact(DisplayName = "DeleteEspecialidade Somente Campos Obrigatorios Ok")]
        public async Task DeleteEspecialidade_SomenteCamposObrigatorios_Ok()
        {
            //Arrange
            var profissionalSaude = new IdProfissionalSaude
            {
                idProfissionalSaude = 1
            };
            var especialidade = new DeleteEspecialidade
            {
                idEspecialidade = "1,2"
            };

            var listVinculos = new List<ProfissionalSaudeEspecialidade>();
            foreach (var idEsp in especialidade.idEspecialidade.Split(","))
            {
                listVinculos.Add(new ProfissionalSaudeEspecialidade
                {
                    ID_ESPE_CD_ESPEC_MED = int.Parse(idEsp),
                    ID_PRSA_CD_PROF_SAUDE = profissionalSaude.idProfissionalSaude
                });
            }
            var usuarioBd = BaseMockTest.NewModelMock<Usuario>(true);
            _usuaRepository.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(usuarioBd);

            _psRepository.Setup(r => r.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaude>(1));
            _psEsRepository.Setup(r => r.GetEspecialidadesCadastradas(It.IsAny<List<int>>(), It.IsAny<List<int>>()))
                .ReturnsAsync(listVinculos);

            //Act
            var result = await _appService.DeleteEspecialidade(profissionalSaude, especialidade);

            //Assert
            Assert.Equal(ResultType.Success, result.ResultType);
        }

        [Trait("Categoria", "ProfissionalSaudeEspecialidadeAppService")]
        [Fact(DisplayName = "DeleteEspecialidade Ok")]
        public async Task DeleteEspecialidade_ProfissionalSaudeInexistente()
        {
            //Arrange
            var profissionalSaude = new IdProfissionalSaude
            {
                idProfissionalSaude = 1
            };
            var especialidade = new DeleteEspecialidade
            {
                idUsuarioAlteracao = 1,
                motivoAlteracao = "teste",
                idEspecialidade = "1,2"
            };
            var usuarioBd = BaseMockTest.NewModelMock<Usuario>(true);
            _usuaRepository.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(usuarioBd);

            _psRepository.Setup(r => r.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(new List<ProfissionalSaude>());

            //Act
            var result = await _appService.DeleteEspecialidade(profissionalSaude, especialidade);

            //Assert
            Assert.Equal(ResultType.PreCondition, result.ResultType);
        }


        [Trait("Categoria", "ProfissionalSaudeEspecialidadeAppService")]
        [Fact(DisplayName = "DeleteEspecialidade Especialidades Nao Cadastradas")]
        public async Task DeleteEspecialidade_EspecialidadesNaoCadastradas()
        {
            //Arrange
            var profissionalSaude = new IdProfissionalSaude
            {
                idProfissionalSaude = 1
            };
            var especialidade = new DeleteEspecialidade
            {
                idUsuarioAlteracao = 1,
                motivoAlteracao = "teste",
                idEspecialidade = "1,2,3,4"
            };

            var listVinculos = new List<ProfissionalSaudeEspecialidade>();
            foreach (var idEsp in "1,2".Split(","))
            {
                listVinculos.Add(new ProfissionalSaudeEspecialidade
                {
                    ID_ESPE_CD_ESPEC_MED = int.Parse(idEsp),
                    ID_PRSA_CD_PROF_SAUDE = profissionalSaude.idProfissionalSaude
                });
            }
            var usuarioBd = BaseMockTest.NewModelMock<Usuario>(true);
            _usuaRepository.Setup(r => r.GetById(It.IsAny<int>()))
                .ReturnsAsync(usuarioBd);

            _psRepository.Setup(r => r.GetProfissionalSaudeById(It.IsAny<int>()))
                .ReturnsAsync(BaseMockTest.ListNewModelMock<ProfissionalSaude>(1));
            _psEsRepository.Setup(r => r.GetEspecialidadesCadastradas(It.IsAny<List<int>>(), It.IsAny<List<int>>()))
                .ReturnsAsync(listVinculos);

            //Act
            var result = await _appService.DeleteEspecialidade(profissionalSaude, especialidade);

            //Assert
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
