namespace SistemaDeProdutos.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
