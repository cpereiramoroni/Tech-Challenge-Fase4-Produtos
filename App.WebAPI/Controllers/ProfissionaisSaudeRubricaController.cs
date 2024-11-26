using App.Application.Interfaces;
using App.Application.ViewModels.Request;
using Corporativo.ControllerCorp;
using Corporativo.Result.Base;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace App.WebAPI.Controllers
{
    [Route("profissionais-saude-fleury")]
    public class ProfissionaisSaudeRubricaController : BaseCorp
    {
        private readonly IProfissionaisSaudeRubricaAppService _appService;

        public ProfissionaisSaudeRubricaController(IProfissionaisSaudeRubricaAppService appService)
            : base("ProfissionaisSaudeV3")
        {
            _appService = appService;
        }

        [HttpPost("/rubrica")]
        [SwaggerOperation(
           Summary = "Gravação de rubrica de profissional de saúde Fleury.",
           Description = @"Endpoint para gravação da rubrica de profissionais de saúde Fleury, usando como parâmetro os campos abaixo:</br></br>
                        <b>Parâmetros de entrada:</b><br/>
                        &bull; <b>idProfissionalSaudeFleury</b>: Identificação (ID) do profissional de saúde Fleury. (Tabela MDFL). &rArr; <font color='red'><b>Obrigatório</b></font> quando o campo idProfissionalSaude não for informado</br>
                        &bull; <b>idProfissionalSaude </b>: Identificação (ID) do profissional de saúde Fleury. (Tabela PRSA). &rArr; <font color='red'><b>Obrigatório</b></font> campo idProfissionalSaudeFleury não for informado</br>
                        &bull; <b>base64RubricaGif </b>: Base64 da imagem em GIF da assinatura (rubrica) do profissional de saúde. &rArr; <font color='red'><b>Obrigatório</b></font></br>
                        &bull; <b>base64RubricaPng </b>: Base64 da imagem em PNG da assinatura (rubrica) do profissional de saúde. &rArr; <font color='green'><b>Opcional</b></font> </br></br>         
                        ",
              Tags = new[] { "Rubricas" })]
        [SwaggerResponse(201, "Requisição bem sucedida, recurso criado.")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa.", typeof(ErrorValidacao))]
        public async Task<IActionResult> PostRubricaProfissionalSaude([FromBody] PostRubricaProfissionalSaude postProfissionalSaudeRubrica)
        {
            _stopwatch.Start();
            if (!ModelState.IsValid)
                return FromResult(ModelState);
            return FromResult(await _appService.PostRubrica(postProfissionalSaudeRubrica));
        }

        [HttpPut("{idProfissionalSaudeFleury}/rubrica")]
        [SwaggerOperation(
           Summary = "Atualização da rubrica do profissional de saúde Fleury.",
           Description = @"Endpoint para a atualização da rubrica dos profissionais de saúde Fleury.</br></br>
                        <b>Parâmetros de entrada:</b><br/>
                        &bull; <b>idProfissionalSaudeFleury</b>: Identificação (ID) do profissional de saúde Fleury (Tabela MDFL). &rArr; <font color='red'><b>Obrigatório</b></font></br>
                        &bull; <b>base64RubricaGif </b>: Base64 da imagem em GIF da assinatura (rubrica) do profissional de saúde. &rArr; <font color='red'><b>Obrigatório</b></font></br>
                        &bull; <b>base64RubricaPng </b>: Base64 da imagem em PNG da assinatura (rubrica) do profissional de saúde. &rArr; <font color='red'><b>Obrigatório</b></font> </br></br>         
                        ",
              Tags = new[] { "Rubricas" })]
        [SwaggerResponse(200, "Requisição bem sucedida, recurso atualizado.")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa.", typeof(ErrorValidacao))]
        public async Task<IActionResult> PutRubricaProfissionalSaude([FromRoute] int idProfissionalSaudeFleury, [FromBody] PutRubricaProfissionalSaude putProfissionalSaudeRubrica)
        {
            _stopwatch.Start();
            if (!ModelState.IsValid)
                return FromResult(ModelState);
            return FromResult(await _appService.PutRubrica(idProfissionalSaudeFleury, putProfissionalSaudeRubrica));
        }
    }
}
