using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DatabaseConnection
    {
        private readonly string _connectionString;

        public DatabaseConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public int ExecuteNonQuery(string sql, SqlParameter[]? parameters = null) // GET devuelve un conjunto de resultados.
        {
            using var connection = GetConnection();
            using var command = new SqlCommand(sql, connection);

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            connection.Open();
            return command.ExecuteNonQuery(); 
        }

        public DataTable ExecuteQuery(string sql, SqlParameter[]? parameters = null) // para POST PUT y DELETE, No devuevle datos.
        {
            using var connection = GetConnection();
            using var command = new SqlCommand(sql, connection);

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            using var adapter = new SqlDataAdapter(command);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable;
        }
    }
}

