using App.Application.ViewModels.Request;
using App.Application.ViewModels.Request.Base;
using Corporativo.Util.Enum;
using System.Collections.Generic;

namespace App.Test.MockObjects
{
    public static class MockPostPF
    {
        public static List<PostProfissionalSaude> PreCondition()
        {
            // parameters to test send email success
            return new List<PostProfissionalSaude>
            {
                new PostProfissionalSaude { idUsuarioInclusao=-100},
                new PostProfissionalSaude { idUsuarioInclusao =-10,indicacao=-00909 },
                new PostProfissionalSaude { },
                new PostProfissionalSaude { permiteParticipacaoPesquisas = null, permiteParticipacaoEventos=null, autorizaEnvioEmails=null  },
                new PostProfissionalSaude { anoFormacao=2 },
                new PostProfissionalSaude { conselhoRegional="sdfds23423423345%%%%(((*&%", numeroCertificado="sdfds23423423345%%%%(((*&%" },
                new PostProfissionalSaude {
                                            localFormacao= MockBase.GenerateStringLeng(100),
                                            observacaoInclusao=MockBase.GenerateStringLeng(200),
                                            descricaoMotivoScore=MockBase.GenerateStringLeng(300)
                                           },
                 new PostProfissionalSaude {
                                            status=50,
                                            ufCertificado=null,
                                           },
                new PostProfissionalSaude {
                                            scoreInformado=0,
                                            scoreCalculado=0,
                                            dataValidadeScore="2050/31/80"
                                           },
                new PostProfissionalSaude {
                                            numeroFicha="123",
                                            unidadeFicha="11111"
                                           },
            };
        }

        public static List<PostProfissionalSaude> OK()
        {
            return new List<PostProfissionalSaude> {
            new PostProfissionalSaude
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
            }
        };
        }

        public static IdProfissionalSaude OKIdLogin()
        {
            return new IdProfissionalSaude
            {
                idProfissionalSaude = 1,
            };
        }


        public static PostAplicacao OKAplicacaoLogin()
        {
            return new PostAplicacao
            {
                idAplicacao = "app",
                idMarca = 1
            };
        }

        public static PostProfissionalSaude OkPrsaLogin()
        {
            return new PostProfissionalSaude
            {
                conselhoRegional = "123",
                ufCertificado = EstadoSigla.SP,
                status = 1,
                idPessoaFisica = 1,
                numeroCertificado = "123"
            };
        }

        public static PostTermoAceite OkTermo()
        {
            return new PostTermoAceite
            {
                idFicha = "5001234567",
                idItem = 100,
                idStatus = 20,
                numeroIp = "10.55.55.55",

            };
        }


    }

}
