using App.Application.Interfaces;
using App.Application.ViewModels.Request;
using Corporativo.ControllerCorp;
using Corporativo.Result.Base;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace App.WebAPI.Controllers
{
    [Route("profissionais-saude")]
    public class ProfissionaisSaudeEspecialidades : BaseCorp
    {
        private readonly IProfissionaisSaudeEspecialidadesAppService _appService;
        public ProfissionaisSaudeEspecialidades(IProfissionaisSaudeEspecialidadesAppService appService)
            : base("ProfissionaisSaudeV3")
        {
            _appService = appService;
        }
        [HttpPost("{idProfissionalSaude}/especialidades")]
        [SwaggerOperation(
           Summary = "Vincula uma ou mais especialidades médicas a um determinado profissional de saúde.",
           Description = @"Endpoint para a inclusão de uma ou mais especialidades médicas em um determinado profissional de saúde, usando como parâmetro os campos abaixo:</br></br>
                        <b>Parâmetros de entrada:</b><br/>
                        &bull; <b>idProfissionalSaude</b>: ID do profissional de saúde (Tabela PRSA). &rArr; <font color='red'><b>Obrigatório</b></font></br>
                        &bull; <b>idEspecialidade </b>: ID da especialidade (Tabela ESPM) do profissional de saúde. Pode ser passada uma lista com um ou mais id's, separados por vírgula. EX: 5, 33  &rArr; <font color='red'><b>Obrigatório</b></font>       
                        &bull; <b>idUsuarioAlteracao </b>: ID do usuário que está fazendo a alteração. (Tabela USUA) &rArr; <font color='green'><b>Opcional</b></font> Quando não informado, será gravado ""null"" no banco de dados.     
                        &bull; <b>motivoAlteracao </b>: Motivo da alteração. &rArr; <font color='green'><b>Opcional</b></font> Quando não informado, será gravado ""null"" no banco de dados.</br></br>         
",

              Tags = new[] { "Especialidades" })]
        [SwaggerResponse(201, "Requisição bem sucedida, recurso criado.")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa.", typeof(ErrorValidacao))]

        public async Task<IActionResult> VincularEspecialidades([FromRoute] IdProfissionalSaude profissionalSaude, [FromQuery] IdEspecialidade especialidade, [FromBody] ProfissionalEspecialidades postEspecialidade)
        {
            _stopwatch.Start();
            if (!ModelState.IsValid)
                return FromResult(ModelState);
            return FromResult(await _appService.Post(profissionalSaude, especialidade, postEspecialidade));
        }

        [HttpDelete("{idProfissionalSaude}/especialidades")]
        [SwaggerOperation(
           Summary = "Desvincula uma ou mais especialidades médicas a um determinado profissional de saúde.",
           Description = @"Endpoint para a exclusão/desvinculo de uma ou mais especialidades médicas em um determinado profissional de saúde, usando como parâmetro os campos abaixo:</br></br>
                                <b>Parâmetros de entrada:</b><br/>
                                &bull; <b>idProfissionalSaude</b>: ID do profissional de saúde (Tabela PRSA). &rArr; <font color='red'><b>Obrigatório</b></font></br>
                                &bull; <b>idEspecialidade </b>: ID da especialidade (Tabela ESPM) do profissional de saúde. Pode ser passada uma lista com um ou mais id's, separados por vírgula. EX: 5, 33  &rArr; <font color='red'><b>Obrigatório</b></font>     
                                &bull; <b>idUsuarioAlteracao </b>: ID do usuário que está fazendo a alteração (Tabela USUA). &rArr; <font color='green'><b>Opcional</b></font> (Quando não informado será gravado ""null"" no banco de dados).      
                                &bull; <b>motivoAlteracao </b>: Motivo da alteração. &rArr; <font color='green'><b>Opcional</b></font> (Quando não informado será gravado ""null"" no banco de dados).</br></br>         
        ",

      Tags = new[] { "Especialidades" })]
        [SwaggerResponse(201, "Requisição bem sucedida, recurso criado.")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa.", typeof(ErrorValidacao))]

        public async Task<IActionResult> DeleteEspecialidade([FromRoute] IdProfissionalSaude profissionalSaude, [FromBody] DeleteEspecialidade especialidade)
        {
            _stopwatch.Start();
            if (!ModelState.IsValid)
                return FromResult(ModelState);
            return FromResult(await _appService.DeleteEspecialidade(profissionalSaude, especialidade));
        }
    }
}
