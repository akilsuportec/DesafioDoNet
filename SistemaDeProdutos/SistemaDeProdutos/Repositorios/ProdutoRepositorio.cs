using Microsoft.Data.SqlClient;
using SistemaDeProdutos.Data;
using SistemaDeProdutos.Models;
using SistemaDeProdutos.Repositorios.Interfaces;

namespace SistemaDeProdutos.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly SistemaDeProdutosDBContext _dbContext;
        public ProdutoRepositorio(SistemaDeProdutosDBContext sistemaDeProdutosDBContext)
        {
            _dbContext = sistemaDeProdutosDBContext;
        }       
         
        public IEnumerable<Produto> ListarProdutos()
        {
            List<Produto> produtos = new List<Produto>();

            using (SqlConnection connection = new SqlConnection("Server=(LocalDB)\\MSSQLLocalDB;DataBase=DBSistemaProdutos"))
            {
                try
                {
                    connection.Open();

                    string selectSql = "SELECT ProdutoId, Nome, Preco, DataCadastro, DataAtualizacao FROM Produtos";

                    using (SqlCommand command = new SqlCommand(selectSql, connection))
                    {
                        using (SqlDataReader reader =  command.ExecuteReader())
                        {
                            while ( reader.Read())
                            {
                                Produto produto = new Produto
                                {
                                    ProdutoId = reader.GetInt32(reader.GetOrdinal("ProdutoId")),
                                    Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                    Preco = reader.GetDecimal(reader.GetOrdinal("Preco")),
                                    DataCadastro = reader.GetDateTime(reader.GetOrdinal("DataCadastro")),
                                    DataAtualizacao = reader.GetDateTime(reader.GetOrdinal("DataAtualizacao"))
                                };

                                produtos.Add(produto);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao listar produtos: " + ex.Message);
                }
            }

            return produtos;
        }

        public  Produto ObterProdutoPorId(int id)
        {
            Produto produto = null;

            using (SqlConnection connection = new SqlConnection("Server=(LocalDB)\\MSSQLLocalDB;DataBase=DBSistemaProdutos"))
            {
                try
                {
                    connection.Open();

                    string selectSql = "SELECT ProdutoId, Nome, Preco, DataCadastro, DataAtualizacao FROM Produtos WHERE ProdutoId = @Id";

                    using (SqlCommand command = new SqlCommand(selectSql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader =  command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                produto = new Produto
                                {
                                    ProdutoId = reader.GetInt32(reader.GetOrdinal("ProdutoId")),
                                    Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                    Preco = reader.GetDecimal(reader.GetOrdinal("Preco")),
                                    DataCadastro = reader.GetDateTime(reader.GetOrdinal("DataCadastro")),
                                    DataAtualizacao = reader.GetDateTime(reader.GetOrdinal("DataAtualizacao"))
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao obter o produto: " + ex.Message);
                }
            }

            return produto;
        }

        public bool CadastrarProduto(Produto produto)
        {
            using (SqlConnection connection = new SqlConnection("Server=(LocalDB)\\MSSQLLocalDB;DataBase=DBSistemaProdutos"))
            {
                try
                {
                    connection.Open();

                    string  insertSql = "INSERT INTO Produtos (Nome, Preco, DataCadastro, DataAtualizacao) VALUES (@Nome, @Preco, @DataCadastro, @DataAtualizacao)";

                    using (SqlCommand command = new SqlCommand(insertSql, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", produto.Nome);
                        command.Parameters.AddWithValue("@Preco", produto.Preco);
                        command.Parameters.AddWithValue("@DataCadastro", produto.DataCadastro);
                        command.Parameters.AddWithValue("@DataAtualizacao", produto.DataAtualizacao);

                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao cadastrar o produto: " + ex.Message);
                    return false;
                }
            }
        }

        public bool AtualizarProduto(int id, Produto produto)
        {
            using (SqlConnection connection = new SqlConnection("Server=(LocalDB)\\MSSQLLocalDB;DataBase=DBSistemaProdutos"))
            {
                try
                {
                    connection.Open();

                    string updateSql = "UPDATE Produtos SET Nome = @Nome, Preco = @Preco, DataCadastro = @DataCadastro, @DataAtualizacao = DataAtualizacao  WHERE ProdutoId = @Id";

                    using (SqlCommand command = new SqlCommand(updateSql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", produto.ProdutoId);
                        command.Parameters.AddWithValue("@Nome", produto.Nome);
                        command.Parameters.AddWithValue("@Preco", produto.Preco);
                        command.Parameters.AddWithValue("@DataCadastro", produto.DataCadastro);
                        command.Parameters.AddWithValue("@DataAtualizacao", produto.DataAtualizacao);

                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao atualizar o produto: " + ex.Message);
                    return false;
                }
            }
        }

        public bool ApagarProdutoPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection("Server=(LocalDB)\\MSSQLLocalDB;DataBase=DBSistemaProdutos"))
            {
                try
                {
                    connection.Open();

                    string deleteSql = "DELETE FROM Produtos WHERE ProdutoId = @Id";

                    using (SqlCommand command = new SqlCommand(deleteSql, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        int rowsAffected =  command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao apagar o produto: " + ex.Message);
                    return false;
                }
            }
        }

    }
}
