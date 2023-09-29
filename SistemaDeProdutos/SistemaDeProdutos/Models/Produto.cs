using System.ComponentModel.DataAnnotations;

namespace SistemaDeProdutos.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public decimal Preco { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
        [Required]
        public DateTime? DataAtualizacao { get; set; }
    }
}
