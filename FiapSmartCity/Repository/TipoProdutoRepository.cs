using FiapSmartCity.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FiapSmartCity.Repository
{
    public class TipoProdutoRepository
    {
        public IList<TipoProduto> Listar()
        {
            IList<TipoProduto> lista = new List<TipoProduto>();

            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT IDTIPO, DESCRICAOTIPO, COMERCIALIZADO FROM TIPOPRODUTO  ";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    // Recupera os dados
                    TipoProduto tipoProd = new TipoProduto();
                    tipoProd.IdTipo = Convert.ToInt32(dataReader["IDTIPO"]);
                    tipoProd.DescricaoTipo = dataReader["DESCRICAOTIPO"].ToString();
                    tipoProd.Comercializado = dataReader["COMERCIALIZADO"].Equals("1");

                    // Adiciona o modelo da lista
                    lista.Add(tipoProd);
                }

                connection.Close();

            } // Finaliza o objeto connection

            // Retorna a lista
            return lista;
        }

        public TipoProduto Consultar(int id)
        {

            TipoProduto tipoProd = new TipoProduto();

            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT IDTIPO, DESCRICAOTIPO, COMERCIALIZADO FROM TIPOPRODUTO WHERE IDTIPO = @IDTIPO ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDTIPO", id);
                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    // Recupera os dados
                    tipoProd.IdTipo = Convert.ToInt32(dataReader["IDTIPO"]);
                    tipoProd.DescricaoTipo = dataReader["DESCRICAOTIPO"].ToString();
                    tipoProd.Comercializado = dataReader["COMERCIALIZADO"].Equals("1");
                }

                connection.Close();

            } // Finaliza o objeto connection

            // Retorna a lista
            return tipoProd;
        }

        public void Inserir(TipoProduto tipoProduto)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "INSERT INTO TIPOPRODUTO ( DESCRICAOTIPO, COMERCIALIZADO ) VALUES ( @descr, @comerc ) ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.AddWithValue("@descr", tipoProduto.DescricaoTipo);
                command.Parameters.AddWithValue("@comerc", Convert.ToInt32(tipoProduto.Comercializado));

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void Alterar(TipoProduto tipoProduto)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "UPDATE TIPOPRODUTO SET DESCRICAOTIPO = @descr , COMERCIALIZADO = @comerc WHERE IDTIPO = @id  ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.AddWithValue("@descr", tipoProduto.DescricaoTipo);
                command.Parameters.AddWithValue("@comerc", Convert.ToInt32(tipoProduto.Comercializado));
                command.Parameters.AddWithValue("@id", tipoProduto.IdTipo);

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void Excluir(int id)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "DELETE TIPOPRODUTO WHERE IDTIPO = @id  ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.AddWithValue("@id", id);

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
    }
}
