using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeProdutos.Models;

namespace SistemaDeProdutos.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(e => e.ProdutoId);
            builder.Property(e => e.Nome).HasMaxLength(255);
            builder.Property(e => e.Preco);
            builder.Property(e => e.DataCadastro);
            builder.Property(e => e.DataAtualizacao);


        }
    }
}
