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

        public void AddCliente(string Nome, string Email, int Telefone)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Cliente novoCliente = new Cliente {
                    Nome = Nome,
                    Email = Email,
                    TelefoneString = Telefone.ToString()
                };

                var sql = "INSERT INTO Clientes(nome, email, telefone) VALUES (@Nome, @Email, @TelefoneString)";
                connection.Execute(sql, novoCliente);

            }
        }

        public async Task UpdateClienteAsync(Cliente cliente, Cliente novoCliente)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                Cliente clienteEdit = new Cliente
                {
                    Nome = novoCliente.Nome,
                    Email = novoCliente.Email,
                    TelefoneString = novoCliente.Telefone.ToString()
                };

                await connection.OpenAsync();

                var sql = "UPDATE Clientes " +
                          "SET Nome=@Nome, Email=@Email, Telefone=@TelefoneString " +
                          "WHERE ClienteID=@ClienteID";
                connection.Execute(sql, new
                {
                    clienteEdit.Nome,
                    clienteEdit.Email,
                    clienteEdit.TelefoneString,
                    cliente.ClienteID
                });

            }
        }

        public async Task RemoveClienteAsync(Cliente cliente)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var sql = "DELETE FROM Clientes WHERE ClienteID=@ClienteID";
                connection.Execute(sql, cliente);

            }
        }
    }
}
