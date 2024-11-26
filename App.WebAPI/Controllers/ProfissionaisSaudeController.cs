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
    public class ProfissionaisSaudeController : BaseCorp
    {
        private readonly IPSAppService _appService;
        public ProfissionaisSaudeController(IPSAppService appService)
            : base("ProfissionaisSaudeV3")
        {
            _appService = appService;
        }
        [HttpPost()]
        [SwaggerOperation(
           Summary = "Criação de Cadastro de Profissionais de Saúde.",
           Description = @":</br>Endpoint para criação de cadastro e login de profissional de saúde na tabela PRSA e IDUN. O endpoint possui algumas validações nos campos de entrada:</br>
                        <b>Parâmetros de entrada:</b><br/>
                        &bull; <b>idPessoaFisica</b>: ID único da tabela PEFI do banco de dados. &rArr; <font color='red'><b>Obrigatório</b></font></br>
                        &bull; <b>permiteParticipacaoPesquisas</b>: Indica se o PS permite que seus dados de contato sejam compartilhados em participações de pesquisas. Os valores possíveis são “Sim” ou “Nao”. &rArr; <font color='red'><b>Obrigatório</b></font></br>
                        &bull; <b>permiteParticipacaoEventos</b>: Indica se o PS permite que seus dados sejam compartilhados em participações em eventos. Os valores possíveis são “Sim” ou “Nao”. &rArr; <font color='red'><b>Obrigatório</b></font></br>
                        &bull; <b>autorizaEnvioEmails</b>: Indica se o PS permite que seja enviado e-mail para o e-mail cadastrado. Os valores possíveis são “Sim” ou “Nao”. &rArr; <font color='red'><b>Obrigatório</b></font></br>
                        &bull; <b>status</b>: Indica a situação do PS no momento do cadastro. Pode ser passado o valor de 1 a 5, sendo:<br>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1 = Ativo<br>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2 = Falecido<br>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3 = Aposentado<br>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4 = Não Exerce<br>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;5 = Acadêmico<br/>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Obs.:Quando passado 5 (Acadêmico) o campo 'numeroCertificado” será gravado automaticamente com AC+idPefi no banco de dados</b>&rArr; <font color='red'><b>Obrigatório</b></font></br>    
                        &bull; <b>conselhoRegional</b>: Sigla do conselho a qual o PS pertence ou quando acadêmico, sua futura sigla. EX: CRM, CRO, CRF, etc. O valor informado será validado na tabela CTPF. &rArr; <font color='red'><b>Obrigatório</b></font></br>
                        &bull; <b>numeroCertificado</b>: Número do certificado de classe. O campo se torna <font color='green'><b>Opcional</b></font> quando o campo “status=5”. &rArr; <font color='red'><b>Obrigatório</b></font></br>
                        &bull; <b>ufCertificado</b>: Sigla do estado a qual a classe do PS está vinculada ou quando acadêmico, informar local onde pretende vincular sua classe futuramente. EX: SP, RJ, PR, etc. &rArr; <font color='red'><b>Obrigatório</b></font></br>
                        <br>&nbsp;<font color='red'>*Os campos abaixo são opcionais e quando não informados serão gravados como “NULL” no banco de dados:</font><br/>
                        &bull; <b>localFormacao</b>: Local de formação do PS limitado a 80 caracteres. &rArr;  <font color='green'><b>Opcional</b></font><br/>
                        &bull; <b>anoFormacao</b>: Ano de formação do PS. Numérico de 4 digitos. Se não passado, gravar NULL Ex: 2022. &rArr;  <font color='green'><b>Opcional</b></font><br/>
                        &bull; <b>indicacao</b>: Quando for indicação de um PS Interno, informar o id do PS que consta na tabela MDFL. &rArr;  <font color='green'><b>Opcional</b></font><br/>
                        &bull; <b>scoreInformado</b>: Score informado para o PS. Campos do tipo numeric (9, 2). EX 10.00 ou 100.99 .&rArr;  <font color='green'><b>Opcional</b></font><br/>
                        &bull; <b>scoreCalculado</b>: Score calculado para o PS. Campos do tipo numeric (9, 2). EX 10.00 ou 100.99 . &rArr;  <font color='green'><b>Opcional</b></font><br/>
                        &bull; <b>dataValidadeScore</b>: Data de validade do score. O formato a ser passado é dd/MM/yyyy. Ex: 07/05/2022. &rArr;  <font color='green'><b>Opcional</b></font><br/>
                        &bull; <b>descricaoMotivoScore</b>: Descrição para o Score limitado a 100 caracteres. &rArr;  <font color='green'><b>Opcional</b></font><br/>
                        &bull; <b>unidadeFicha</b>: Número da unidade da ficha que está gerando o cadastro com até 3 números. &rArr;  <font color='green'><b>Opcional</b></font><br/>
                        &bull; <b>numeroFicha</b>: Número da ficha que está gerando o cadastro com até 7 números &rArr;  <font color='green'><b>Opcional</b></font><br/>
                        &bull; <b>idUsuarioInclusao</b>: ID do usuário (tabela USUA) que está fazendo a inclusão. &rArr;  <font color='green'><b>Opcional</b></font><br/>
                        &bull; <b>observacaoInclusao</b>: Observação sobre a inclusão do PS limitado a 80 caracteres. &rArr;  <font color='green'><b>Opcional</b></font>
                    ",
              Tags = new[] { "Profissionais de Saúde" })]
        [SwaggerResponse(201, "Requisição bem sucedida, recurso criado.")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa.", typeof(ErrorValidacao))]

        public async Task<IActionResult> Post([FromBody] PostProfissionalSaude postProfissionalSaude)
        {
            _stopwatch.Start();
            if (!ModelState.IsValid)
                return FromResult(ModelState);
            return FromResult(await _appService.Post(postProfissionalSaude));
        }

        #region POST termo-aceite

        [HttpPost("{idProfissionalSaude}/termo-aceite")]
        [SwaggerOperation(
          Summary = "Gravação do termo de aceite de um determinado profissional de saúde.",
          Description = @"Endpoint para gravar o termo de aceite do profissional de saúde para visualização de imagem/laudo de um determinado exame/item de uma ficha. Os campos para cadastro são:</br></br>
                        <b>Parâmetros de entrada:</b><br/>
                        &bull; <b>idProfissionalSaude</b>: ID do profissional de saúde (Tabela PRSA).  &rArr; <font color='red'><b>Obrigatório</b></font></br>
                        &bull; <b>idFicha </b>: ID da ficha composto pelo número da unidade mais número da ficha, totalizando 10 dígitos.  &rArr; <font color='red'><b>Obrigatório</b></font><br>
                        &bull; <b>idItem </b>: Número do item da ficha. &rArr; <font color='red'><b>Obrigatório</b></font>                                  
                        &bull; <b>idStatus </b>: ID do status do item no momento do aceite pelo profissional de saúde. Os status aceitos são os mesmos da tabela (STIF)  &rArr; <font color='red'><b>Obrigatório</b></font><br>
                        &bull; <b>numeroIp </b>:  Endereço eletrônico (IP) da máquina onde foi dado o aceite.  &rArr; <font color='green'><b>Opcional</b></font><br></b></font>",

             Tags = new[] { "Profissionais de Saúde" })]
        [SwaggerResponse(201, "Requisição bem sucedida, recurso criado.")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa.", typeof(ErrorValidacao))]

        public async Task<IActionResult> PostTermoAceite([FromRoute] IdProfissionalSaude profissionalSaude, [FromBody] PostTermoAceite postTermoAceite)
        {
            _stopwatch.Start();
            if (!ModelState.IsValid)
                return FromResult(ModelState);
            return FromResult(await _appService.PostTermoAceite(profissionalSaude, postTermoAceite));
        }

        #endregion

        #region PATCH /profissionais-saude/{idProfissionalSaude}
        [HttpPatch("{idProfissionalSaude}")]
        [SwaggerOperation(
          Summary = "Atualização parcial de cadastro de um determinado profissional de saúde na tabela PRSA",
          Description = @"Endpoint para atualização de informações gravadas na tabela PRSA de um determinado profissional de saúde conforme campos abaixo:</br></br>
                        <b>Parâmetros de entrada:</b><br/>
                        &bull; <b>idProfissionalSaude</b>: ID do profissional de saúde (Tabela PRSA). &rArr; <font color='red'><b>Obrigatório</b></font></br>
                        &bull; <b>idUsuarioAlteracao</b>: ID do usuário que está fazendo a alteração de acordo com a tabela USUA. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                        &bull; <b>motivoAlteracao</b>: Descrição do motivo da alteração do cadastro limitado a 50 caracteres. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                        &bull; <b>conselhoRegional</b>: Sigla do conselho a qual o PS pertence ou quando acadêmico, sua futura sigla. EX: CRM, CRO, CRF, etc. O valor informado será validado na tabela CTPF. &rArr; <font color='green'><b>Opcional</b></font><br></b></font>
                        &bull; <b>numeroCertificado</b>: Número do certificado de classe. &rArr; <font color='green'><b>Opcional</b></font><br></b></font>
                        &bull; <b>ufCertificado</b>: Sigla do estado a qual a classe do PS está vinculada ou quando acadêmico, informar local onde pretende vincular sua classe futuramente. EX: SP, RJ, PR, etc. &rArr; <font color='green'><b>Opcional</b></font><br></b></font>
                        &bull; <b>idStatus</b>: Indica a situação do PS no momento do cadastro. Pode ser passado o valor de 1 a 5, sendo: <br>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1 = Ativo<br>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2 = Falecido<br>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3 = Aposentado<br>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;4 = Não Exerce<br>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;5 = Acadêmico<br/>
            ",
             Tags = new[] { "Profissionais de Saúde" })]
        [SwaggerResponse(200, "Requisição bem sucedida, recurso criado.")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa.", typeof(ErrorValidacao))]

        public async Task<IActionResult> PatchProfissionalSaude([FromRoute] IdProfissionalSaude profissionalSaude, [FromBody] PatchProfissionalSaude patchProfissionalSaude)
        {
            _stopwatch.Start();
            if (!ModelState.IsValid)
                return FromResult(ModelState);
            return FromResult(await _appService.PatchProfissionalSaude(profissionalSaude, patchProfissionalSaude));
        }
        #endregion
    }
}
