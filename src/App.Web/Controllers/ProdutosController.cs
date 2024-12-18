using App.Application.Interfaces;
using App.Application.ViewModels.Request;
using App.Application.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Api.Controllers
{
    [ApiController]
    [Route("produtos/")]
    public class ProdutosController : ControllerBase
    {

        private readonly IProdutosService _produtosService;

        public ProdutosController(IProdutosService produtosService)
        {
            _produtosService = produtosService;
        }



        #region [GET/produtos]
        [SwaggerResponse(200, "Consulta executada com sucesso!", typeof(List<Produto>))]
        [SwaggerResponse(204, "Requisição concluída, porém não há dados de retorno!")]
        [SwaggerResponse(400, "Condição prévia dada em um ou mais dos campos avaliado como falsa.")]
        [HttpGet("")]
        [SwaggerOperation(
            Summary = "Busca todos os produtos.",
            Description = @"Endpoint para retornar os produtos que foram cadastrados no sistema. A busca pode ser feita pelos filtros abaixo:</br></br>
                            <b>Parâmetros de entrada:</b></br></br>
                             &bull; <b>idCategoria</b>:  Id da categoria do produto. &rArr; <font color='green'><b>Opcional</b></font><br>
                             <strong> 1 = </strong> Lanche<br/>
                             <strong> 2 = </strong> Acompanhamento<br/>
                             <strong> 3 = </strong>  Bebida<br/>
                             <strong> 4 = </strong> Sobremesa
                        
            ",
            Tags = new[] { "Produtos" }
        )]
        [Consumes("application/json")]
        public async Task<IActionResult> GetProdutos([FromQuery] int? IdCategoria)
        {

            var lstRtn = await _produtosService.GetProdutoByCategoria(IdCategoria);
            if (lstRtn.Count == 0)
                return NoContent();
            return Ok(lstRtn);
        }
        #endregion


        #region POST/produtos
        [SwaggerResponse(201, "A solicitação foi atendida e resultou na criação de um ou mais novos recursos.")]
        [SwaggerResponse(400, "A solicitação não pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisição requer autenticação do usuário!")]
        [SwaggerResponse(403, "Privilégios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado não existe!")]
        [SwaggerResponse(400, "Condição prévia dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condição inesperada!")]
        [HttpPost("")]
        [SwaggerOperation(
       Summary = "Endpoint para criação de um novo produto.",
       Description = @"Endpoint para criar um novo produto.</br></br>
                            <b>Parâmetros de entrada:</b></br></br>
                              &bull; <b>nomeProduto</b>:  Nome do produto. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                              &bull; <b>Ativo</b>: True ou False. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                              &bull; <b>valorProduto</b>: Valor do produto. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                              &bull; <b>idCategoria</b>: ID da categoria. Escolher 1 item da lista &rArr; <font color='red'><b>Obrigatório</b></font>                        
                             <strong> 1 = </strong> Lanche<br/>
                             <strong> 2 = </strong> Acompanhamento<br/>
                             <strong> 3 = </strong>  Bebida<br/>
                             <strong> 4 = </strong> Sobremesa                       
", Tags = new[] { "Produtos" }
   )]
        [Consumes("application/json")]
        public async Task<IActionResult> Post([FromBody] PostProduto input)
        {
            await _produtosService.PostProduto(input);
            return StatusCode((int)HttpStatusCode.Created);

        }
        #endregion

        #region PATCH/produtos/{idProduto}
        [SwaggerResponse(200, "A solicitação foi atendida e resultou na criação de um ou mais novos recursos.")]
        [SwaggerResponse(400, "A solicitação não pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisição requer autenticação do usuário!")]
        [SwaggerResponse(403, "Privilégios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado não existe!")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condição inesperada!")]
        [HttpPatch("{idProduto}")]
        [SwaggerOperation(
   Summary = "Endpoint para atualizar produto já existente.",
   Description = @"Endpoint para atualizar produto.</br></br>
                            <b>Parâmetros de entrada:</b></br></br>
                              &bull; <b>idProduto</b>:  Id do produto que deseja atualizar. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                              &bull; <b>nomeProduto</b>: Nome do produto. &rArr; <font color='green'><b>Opcional</b></font><br>
                              &bull; <b>Ativo</b>: True ou False. &rArr; <font color='red'><b>Obrigatório</b></font><br>
                              &bull; <b>valorProduto</b>: Valor do produto. &rArr; <font color='green'><b>Opcional</b></font><br>
                              &bull; <b>idCategoria</b>: ID da categoria. Escolher 1 item da lista &rArr; <font color='green'><b>Opcional</b></font><br>
                              <strong> 1 = </strong> Lanche<br/>
                             <strong> 2 = </strong> Acompanhamento<br/>
                             <strong> 3 = </strong>  Bebida<br/>
                             <strong> 4 = </strong> Sobremesa                       
        ",
            Tags = new[] { "Produtos" }
        )]
        [Consumes("application/json")]
        public async Task<IActionResult> Patch([FromRoute] int idProduto, [FromBody] PatchProduto input)
        {
            await _produtosService.UpdateProdutoById(idProduto, input);

            return Ok("Atualizado com sucesso!");
        }
        #endregion

        #region DELETE/produtos/{IdProduto}
        [SwaggerResponse(200, "Deletado com sucesso!")]
        [SwaggerResponse(400, "A solicitação não pode ser entendida pelo servidor devido a sintaxe malformada!")]
        [SwaggerResponse(401, "Requisição requer autenticação do usuário!")]
        [SwaggerResponse(403, "Privilégios insuficientes!")]
        [SwaggerResponse(404, "O recurso solicitado não existe!")]
        [SwaggerResponse(412, "Condição prévia dada em um ou mais dos campos avaliado como falsa!")]
        [SwaggerResponse(500, "Servidor encontrou uma condição inesperada!")]
        [HttpDelete("{idProduto}")]
        [SwaggerOperation(
           Summary = "Endpoint para deletar produto do sistema pelo id.",
           Description = @"Endpoint para deletar um determinado produto.</br></br>
                            <b>Parâmetros de entrada:</b></br></br>
                             &bull; <b>idProduto</b>:  Identificador único do produto. &rArr; <font color='red'><b>Obrigatório</b></font>",
           Tags = new[] { "Produtos" }
       )]
        [Consumes("application/json")]
        public async Task<IActionResult> DeleteProdutos([FromRoute] int idProduto)
        {
            await _produtosService.DeleteProdutoById(idProduto);
            return Ok("Produto deletado com sucesso");
        }
        #endregion





    }
}