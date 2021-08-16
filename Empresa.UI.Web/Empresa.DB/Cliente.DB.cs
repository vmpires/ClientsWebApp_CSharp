using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Empresa.Models;

namespace Empresa.DB
{
    public class ClienteDB
    {
        public void Incluir(Cliente cliente)
        {
            var cn = new SqlConnection(DB.Conexao);
            string sql = "INSERT INTO Cliente (Id, Nome, Email, Telefone) VALUES (@Id, @Nome, @Email, @Telefone)";
            var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Id", cliente.Id);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@Email", cliente.Email);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public void Alterar(Cliente cliente)
        {
            var cn = new SqlConnection(DB.Conexao);
            string sql = @"UPDATE Cliente " +
                "SET Nome = @Nome, Email=@Email, Telefone=@Telefone " +
                "WHERE Id=@Id";
            var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Id", cliente.Id);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@Email", cliente.Email);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public void Excluir(int Id)
        {
            var cn = new SqlConnection(DB.Conexao);
            string sql = @"DELETE Cliente WHERE Id=@Id";
            var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Id", Id);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public List<Cliente> Pesquisar()
        {
            var cn = new SqlConnection(DB.Conexao);
            string sql = "SELECT Id, Nome, Email, Telefone FROM Cliente";
            var cmd = new SqlCommand(sql, cn);
            List<Cliente> lista = new List<Cliente>();

            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var cliente = new Cliente();
                cliente.Id = Convert.ToInt32(reader["Id"]);
                cliente.Nome = Convert.ToString(reader["Nome"]);
                cliente.Email = Convert.ToString(reader["Email"]);
                cliente.Telefone = Convert.ToString(reader["Telefone"]);
                lista.Add(cliente);

            }
            reader.Close();
            cn.Close();
            return lista;
        }

        public Cliente ObterPorID(int id)
        {
            var cn = new SqlConnection(DB.Conexao);
            string sql = @"SELECT Id, Nome, Email, Telefone FROM Cliente WHERE Id=@Id";
            var cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@Id", id);

            Cliente cliente = null;

            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                cliente = new Cliente();
                cliente.Id = Convert.ToInt32(reader["Id"]);
                cliente.Nome = Convert.ToString(reader["Nome"]);
                cliente.Email = Convert.ToString(reader["Email"]);
                cliente.Telefone = Convert.ToString(reader["Telefone"]);
            }
            reader.Close();
            cn.Close();
            return cliente;
        }
    }
}