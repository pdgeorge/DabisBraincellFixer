using System.Collections.Generic;
using System.Data;
using DabisBraincellFixer.Data;
using DabisBraincellFixer.Models;

namespace DabisBraincellFixer.Services
{
    public class CommService
    {
        private readonly DabisBraincellFixerDbContext? _dbContext;

        public CommService()
        {
            _dbContext = new DabisBraincellFixerDbContext();
        }

        // Get
        public Comm? GetCommById(int id)
        {
            if (_dbContext == null) return null;
            using var connection = _dbContext.GetConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "Select * From pdgeorge WHERE id = @id";
            command.Parameters.AddWithValue("@id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Comm
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Message = reader.GetString(2),
                    Response = reader.GetString(3)
                };
            }
            return null;
        }

        public void UpdateRecord(Comm comm)
        {
            Console.WriteLine("UpdateRecord?");
            Console.WriteLine(comm.Username);
            if (_dbContext == null) return;
            using var connection = _dbContext.GetConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                UPDATE pdgeorge
                SET username = @username, message = @message, response = @response
                WHERE id = @id";
            command.Parameters.AddWithValue("@id", comm.Id);
            command.Parameters.AddWithValue("@username", comm.Username);
            command.Parameters.AddWithValue("@message", comm.Message);
            command.Parameters.AddWithValue("@response", comm.Response);

            command.ExecuteNonQuery();
        }

        public void DeleteRecord(int id)
        {
            if (_dbContext == null) return;
            Console.WriteLine("DeleteRecord?");
            Console.WriteLine(id);
            using var connection = _dbContext.GetConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM pdgeorge WHERE id = @id";
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
            Console.WriteLine("DeleteRecord complete?");
        }
        public List<Comm> GetAllComms()
        {
            if ( _dbContext == null) return new List<Comm>();
            using var connection = _dbContext.GetConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "Select * FROM pdgeorge";

            var comms = new List<Comm>();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                comms.Add(new Comm()
                {
                    Id = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Message = reader.GetString(2),
                    Response = reader.GetString(3)
                });
            }

            return comms;
        }
    }
}
