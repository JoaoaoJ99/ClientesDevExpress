using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace ClientesDevExpress.Models
{

    public class ClienteService
    {
        public readonly string connectionString = "Server=localhost;Database=ClientesTeste;User Id=user;Password=pass;";

        public async Task<List<Cliente>> GetClientesList()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var sql = "SELECT * FROM Clientes";
                var clientes = await connection.QueryAsync<Cliente>(sql);

                return clientes.AsList<Cliente>();
            }
        }

        public void AddCliente(string Nome, string Email, string Telefone)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Cliente novoCliente = new Cliente {
                    Nome = Nome,
                    Email = Email,
                    Telefone = Telefone
                };

                var sql = "INSERT INTO Clientes(nome, email, telefone) VALUES (@Nome, @Email, @Telefone)";
                connection.Execute(sql, novoCliente);

            }
        }
    }
}
