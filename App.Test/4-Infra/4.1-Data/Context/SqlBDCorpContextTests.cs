using App.Domain.Models;
using App.Infra.Data.Context;
using App.Test.MockObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace App.Test._4_Infra._4._1_Data.Context
{
    public class SqlBDCorpContextTests : IDisposable
    {
        public SqlBDCorpContext _persist;

        public SqlBDCorpReadContext _read;



        public SqlBDCorpContextTests()
        {


            var databaseName = "TesteBDCorp" + Guid.NewGuid().ToString();

            var options = new DbContextOptionsBuilder<SqlBDCorpContext>()
                    .UseInMemoryDatabase(databaseName: databaseName)
                    .Options;
            _persist =
                    new SqlBDCorpContext(options);

            _read = new SqlBDCorpReadContext(options);
            InitializeBDAsync();
        }

        #region [Test SqlBDCorpContext]
        [Trait("Categoria", "SqlDBCorpContext")]
        [Fact(DisplayName = "SqlDBCorpContext Valido ")]
        public async Task Context_Validar_DeveEstarValido()
        {
            //act
            var resultProfissionaisSaude = await _persist.ProfissionaisSaude.AnyAsync();
            var resultEspecialidades = await _persist.Especialidades.AnyAsync();
            var resultProfissionalEspecialidade = await _persist.ProfissionaisEspecialidades.AnyAsync();

            //asset
            Assert.True(resultProfissionaisSaude);
            Assert.True(resultEspecialidades);
            Assert.True(resultProfissionalEspecialidade);
        }
        #endregion

        #region Test SqlBdCorpReadContext
        [Trait("Categoria", "SqlDBCorpReadContext")]
        [Fact(DisplayName = "SqlDBCorpReadContext ")]
        public async Task ReadContext_Validar_DeveEstarValido()
        {
            //act
            var resultProfissionaisSaude = await _read.ProfissionaisSaude.AnyAsync();
            var resultEspecialidades = await _read.Especialidades.AnyAsync();
            var resultProfissionalEspecialidade = await _read.ProfissionaisEspecialidades.AnyAsync();

            //asset
            Assert.True(resultProfissionaisSaude);
            Assert.True(resultEspecialidades);
            Assert.True(resultProfissionalEspecialidade);
        }




        #endregion

        #region InitializeBD
        private void InitializeBDAsync()
        {
            var listEspecialidades = new List<Especialidade>();
            for (int i = 1; i < 11; i++)
            {
                listEspecialidades.Add(new Especialidade
                {
                    ID_ESPE_CD_ESPEC_MED = i

                });
            }

            _persist.Especialidades.AddRange(listEspecialidades);

            var listProfissionaisSaude = new List<ProfissionalSaude>();
            for (int i = 1; i < 11; i++)
            {
                var profissionalSaude = BaseMockTest.NewModelMock<ProfissionalSaude>(true);
                profissionalSaude.ID_PRSA_CD_PROF_SAUDE = i;
                listProfissionaisSaude.Add(profissionalSaude);

            }
            _persist.AddRange(listProfissionaisSaude);


            var profissionalSaudeEspecialidade = new ProfissionalSaudeEspecialidade()
            {
                ID_PRSA_CD_PROF_SAUDE = 1,
                ID_ESPE_CD_ESPEC_MED = 1
            };

            _persist.ProfissionaisEspecialidades.Add(profissionalSaudeEspecialidade);

            _persist.Categorias.AddRange(BaseMockTest.ListNewModelMock<Categoria>(10));

            var listPSF = BaseMockTest.ListNewModelMock<ProfissionalSaudeFleury>(10);
            for (int i = 0; i < listPSF.Count; i++)
            {
                listPSF[i].ID_MDFL_CD_MEDICO_FLEURY = 0;
                //listPSF[i].ID_PRSA_CD_PROF_SAUDE = listProfissionaisSaude.FirstOrDefault().ID_PRSA_CD_PROF_SAUDE; 
            }
            _persist.ProfissionaisSaudeFleury.AddRange(listPSF);

            var lstPF = new List<PessoaFisica>();
            lstPF.Add(new PessoaFisica { });
            lstPF.Add(new PessoaFisica { });

            _persist.PessoaFisicas.AddRange(lstPF); ;


            _persist.LoginUsuarios.Add(new LoginUsuario
            {
                IDUN_DS_LOGIN = "Teste",
                IDUN_CD_TIPO_LOGIN_SENHA = "dd",
                IDUN_DH_CRIACAO = DateTime.Now,
                IDUN_DS_SENHA = "dfsdf",
                ID_IDUN_CD_USUARIO_GEN = listPSF[0].ID_PRSA_CD_PROF_SAUDE

            });
            _persist.SaveChanges();
            CloneForContextRead();
        }

        private void CloneForContextRead()
        {
            _read.ProfissionaisSaude = _persist.ProfissionaisSaude;
            _read.Especialidades = _persist.Especialidades;
            _read.ProfissionaisEspecialidades = _persist.ProfissionaisEspecialidades;
            _read.Categorias = _persist.Categorias;

            _read.ProfissionaisSaudeFleury = _persist.ProfissionaisSaudeFleury;
            _read.PessoaFisicas = _persist.PessoaFisicas;
            _read.LoginUsuarios = _persist.LoginUsuarios;
            _read.SaveChanges();
        }
        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _persist.Dispose();
            _read.Dispose();
        }
    }
}

