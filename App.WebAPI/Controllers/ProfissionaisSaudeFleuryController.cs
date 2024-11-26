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
    public class ProfissionaisSaudeFleuryController : BaseCorp
    {
        private readonly IPSFleuryAppService _appService;

        public ProfissionaisSaudeFleuryController(IPSFleuryAppService appService
            )
            : base("ProfissionaisSaudeV3")
        {
            _appService = appService;
        }

        [HttpPost("{idProfissionalSaude}/interno")]
        [SwaggerOperation(
         Summary = "Criação de Cadastro de Profissionais de Saúde Interno/Fleury.",
         Description = @"Endpoint para criação de cadastro de profissional de saúde interno Fleury na tabela MDFL. O endpoint possui algumas validações nos campos de entrada, conforme segue abaixo:<br></br>
                        <b>Parâmetros de entrada:</b><br/>
                        &bull; <b>idProfissionalSaude</b>: Identificação do profissional de saúde (tabela PRSA). &rArr; <font color='red'><b>Obrigatório</b></font></br>
                        &bull; <b>ramalFleury</b>: Número do ramal interno do PS Fleury. &rArr; <font color='red'><b>Obrigatório</b></font>        
                        &bull; <b>status</b>: Indica a situação do PS Interno no momento do cadastro. Pode ser passado o valor de 0 a 3: &rArr; <font color='red'><b>Obrigatório</b></font></br>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;0 = Afastado<br>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1 = Ativo<br>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2 = Desvinculado<br>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3 = Em treinamento                                   
                        &bull; <b>categoriaFleury</b>: Sigla da Categoria do PS Fleury. As letras aceitas são: &rArr; <font color='red'><b>Obrigatório</b></font></br>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;S = Associado<br>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;A = Médico Atendimento<br>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;C = Médico Consultor Externo<br>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;F = Médico Funcionário<br>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;P = Médico Sócio              
                        &bull; <b>divulgaNomeConjuge</b>: Indica se o PS autoriza a divulgação do nome do conjuge. Os valores possíveis são “Sim” ou “Nao”. &rArr; <font color='red'><b>Obrigatório</b></font>                 
                        &bull; <b>divulgaDataNascimento</b>: Indica se a data de nascimento pode ser divulgada. Os valores possíveis são “Sim” ou “Nao”. &rArr; <font color='red'><b>Obrigatório</b></font></br>
                           <br>&nbsp;<font color='red'>*Os campos abaixo são opcionais e quando não informados serão gravados como “NULL” no banco de dados:</font><br/>
                        &bull; <b>numeroProntuario</b>: Número do prontuário. &rArr;  <font color='green'><b>Opcional</b></font><br/>
                        &bull; <b>nomeEmpresaAssociada</b>: Nome da empresa associada, limitado a 30 caracteres. &rArr;  <font color='green'><b>Opcional</b></font><br/>
                        &bull; <b>dataInicioSocio</b>: O campo se torna <font color='red'><b>Obrigatório</b></font>  quando o campo “categoriaFleury = P”. &rArr;  <font color='green'><b>Opcional</b></font><br/>
                        &bull; <b>areaInteressePesquisa</b>: Área de interesse de pesquisa limitado a 20 caracteres .&rArr;  <font color='green'><b>Opcional</b></font><br/>
                        &bull; <b>descricaoResponsabilidade</b>: Descrição da responsabilidade limitado a 20 caracteres. &rArr;  <font color='green'><b>Opcional</b></font><br/>
                        &bull; <b>nomeConjuge</b>: Nome do conjuge do PS limitado a 50 caracteres. &rArr;  <font color='green'><b>Opcional</b></font><br/>
                        &bull; <b>motivoAfastamento</b>: Descreve o motivo de afastamento do PS limitado a 50 caracteres. O campo se torna <font color='red'><b>Obrigatório</b></font>  quando o campo “status = 0” &rArr;  <font color='green'><b>Opcional</b></font><br/>
                       

                    ",
            Tags = new[] { "Profissionais de Saúde" })]
        [SwaggerResponse(201, "Requisição bem sucedida, recurso criado.")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa.", typeof(ErrorValidacao))]
        public async Task<IActionResult> PostPsFleury(PostProfissionalSaudeFleury postProfissionalSaudeFleury)
        {
            _stopwatch.Start();
            if (!ModelState.IsValid)
                return FromResult(ModelState);
            return FromResult(await _appService.PostPsFleury(postProfissionalSaudeFleury));
        }

    }
}
