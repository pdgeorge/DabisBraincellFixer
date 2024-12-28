using Microsoft.Data.Sqlite;

namespace DabisBraincellFixer.Data
{
    public class DabisBraincellFixerDbContext
    {
        private const string ConnectionString = "Data Source=dabibraincell.db";
        public SqliteConnection GetConnection()
        {
            return new SqliteConnection(ConnectionString);
        }
    }
}
