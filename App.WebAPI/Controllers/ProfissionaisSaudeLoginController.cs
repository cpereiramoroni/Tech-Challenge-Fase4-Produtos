using App.Application.Interfaces;
using App.Application.ViewModels.Request;
using App.Application.ViewModels.Request.Base;
using Corporativo.ControllerCorp;
using Corporativo.Result.Base;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace App.WebAPI.Controllers
{
    [Route("Login")]
    public class ProfissionaisSaudeLoginController : BaseCorp
    {
        private readonly IProfissionaisSaudeLoginAppService _appService;
        public ProfissionaisSaudeLoginController(IProfissionaisSaudeLoginAppService appService)
            : base("ProfissionaisSaudeV3")
        {
            _appService = appService;
        }

        #region Post Login PRSA
        [HttpPost("/aplicacoes/{idAplicacao}/marcas/{idMarca}/profissionais-saude/{idProfissionalSaude}/login")]
        [SwaggerOperation(
            Summary = "Criação de login/senha para um profissional de saúde que ainda não tem um login cadastrado na tabela IDUN.",
           Description = @"Endpoint para criação de login/senha de profissional de saúde na tabela IDUN.</br></br>
             <b>Parâmetros de entrada:</b><br/>
              &bull; <b>idAplicacao</b>: Identificação da aplicação cadastrada no banco de dados Mongo. &rArr; <font color='red'><b>Obrigatório</b></font></br>
			  &bull; <b>idMarca</b>: Identificação da Marca no banco de dados BDCORP (Tabela Marc) &rArr; <font color='red'><b>Obrigatório</b></font></br>
               &bull; <b>idProfissionalSaude</b>: ID único da tabela PRSA do banco de dados &rArr; <font color='red'><b>Obrigatório</b></font></br></br> ",

            Tags = new[] { "Login" })]
        [SwaggerResponse(201, "Requisição bem sucedida, recurso criado.")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa.", typeof(ErrorValidacao))]
        public async Task<IActionResult> PostLogin([FromRoute] PostAplicacao postAplicacao,
                                                               IdProfissionalSaude idPrsa)

        {
            this._stopwatch.Start();
            if (!ModelState.IsValid)
                return FromResult(ModelState);
            return FromResult(await _appService.PostLogin(idPrsa, postAplicacao));
        }
        #endregion
    }
}
