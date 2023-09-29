using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SistemaDeProdutos.Models;
using SistemaDeProdutos.Repositorios.Interfaces;

namespace SistemaDeProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        public  ActionResult<List<Produto>> ListarTodosProdutos()
        {
           var produtos=  _produtoRepositorio.ListarProdutos();

            return Ok(produtos);    

        }

        [HttpGet("{id}")]
        public ActionResult<Produto> ObterPorId(int id)
        {
            Produto produto = _produtoRepositorio.ObterProdutoPorId(id);

            if (produto != null)
            {
                return Ok(produto);
            }
            else
            {
                return NotFound("Produto não encontrado.");
            }
        }


        [HttpPut("{id}")]
    public ActionResult AtualizarProduto(int id, [FromBody] Produto produto)
    {
        bool atualizado = _produtoRepositorio.AtualizarProduto(id, produto);

        if (atualizado)
        {
            return Ok("Produto atualizado com sucesso.");
        }
        else
        {
            return NotFound("Produto não encontrado ou erro ao atualizar.");
        }
    }

        [HttpPost]
        public ActionResult CadastrarProduto([FromBody] Produto produto)
        {
            bool cadastrado = _produtoRepositorio.CadastrarProduto(produto);

            if (cadastrado)
            {
                return Ok("Produto cadastrado com sucesso.");
            }
            else
            {
                return BadRequest("Erro ao cadastrar o produto.");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> Apagar(int id)
        {
            bool excluido =  _produtoRepositorio.ApagarProdutoPorId(id);

            if (excluido)
            {
                return Ok("Produto excluído com sucesso.");
            }
            else
            {
                return NotFound("Produto não encontrado ou erro ao excluir.");
            }
        }


    }
}
