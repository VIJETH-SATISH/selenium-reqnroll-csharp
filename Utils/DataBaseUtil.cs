using Microsoft.Extensions.Logging;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Utils
{
    public class DataBaseUtil
    {
        private readonly string _connectionString;
        private readonly ILogger<DataBaseUtil> _logger;
        public DataBaseUtil(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataBaseUtil(
             string connectionString,
             ILogger<DataBaseUtil> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }


        public async Task<DataTable> ExecuteQueryAsync(string query)
            {
                using MySqlConnection connection = new MySqlConnection(_connectionString);
                using MySqlCommand command = new MySqlCommand(query, connection);
                using MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                await connection.OpenAsync();
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }

        public async Task<DataTable> ExecuteQueryAsync(
            string query,
            params MySqlParameter[] parameters)
        {
            _logger.LogInformation("Executing query: {Query}", query);

            using var conn = new MySqlConnection(_connectionString);
            using var cmd = new MySqlCommand(query, conn);

            if (parameters?.Length > 0)
                cmd.Parameters.AddRange(parameters);

            using var adapter = new MySqlDataAdapter(cmd);

            var table = new DataTable();
            await conn.OpenAsync();
            adapter.Fill(table);

            _logger.LogInformation("Rows retrieved: {RowCount}", table.Rows.Count);

            return table;
        }

    }


}
