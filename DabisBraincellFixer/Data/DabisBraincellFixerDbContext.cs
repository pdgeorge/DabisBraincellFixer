using Microsoft.Data.Sqlite;

namespace DabisBraincellFixer.Data
{
    public class DabisBraincellFixerDbContext
    {
        private string? _databasePath = null;
        private string ConnectionString;

        public DabisBraincellFixerDbContext()
        {
            _databasePath = Environment.GetEnvironmentVariable("DATABASE_PATH") ?? "./dabibraincell.db";
            ConnectionString = $"Data Source={_databasePath}";
        }
        public SqliteConnection GetConnection()
        {
            return new SqliteConnection(ConnectionString);
        }
    }
}
