using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace StorageDemo.Services
{
    public class StructuredDataService
    {
        private readonly string _connectionString = $"Data Source={Path.Combine(AppContext.BaseDirectory, "Components", "Data", "database.sqlite")}";

        public async Task<DataTable> GetDataAsync()
        {
            var dataTable = new DataTable();

            using var connection = new SQLiteConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SQLiteCommand("SELECT * FROM images", connection);
            using var reader = await command.ExecuteReaderAsync();

            dataTable.Load(reader);
            return dataTable;
        }

        public async Task<List<string>> GetTableNamesAsync()
        {
            var tableNames = new List<string>();

            using var connection = new SQLiteConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%';", connection);
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                tableNames.Add(reader.GetString(0));
            }

            return tableNames;
        }
    }
}