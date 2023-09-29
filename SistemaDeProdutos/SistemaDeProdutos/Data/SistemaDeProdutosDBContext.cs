using Microsoft.EntityFrameworkCore;
using SistemaDeProdutos.Data.Map;
using SistemaDeProdutos.Models;

namespace SistemaDeProdutos.Data
{
    public class SistemaDeProdutosDBContext : DbContext
    {
        public SistemaDeProdutosDBContext(DbContextOptions<SistemaDeProdutosDBContext> options) : base(options)
        {
             
        }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
