using SistemaDeProdutos.Models;

namespace SistemaDeProdutos.Repositorios.Interfaces
{
    public interface IProdutoRepositorio
    {      
        bool CadastrarProduto(Produto produto);
        bool AtualizarProduto(int id, Produto produto);
        IEnumerable<Produto> ListarProdutos();
        Produto ObterProdutoPorId(int id);
        bool ApagarProdutoPorId(int id);

    }
}
