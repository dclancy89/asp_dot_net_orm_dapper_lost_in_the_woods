using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LostInTheWoods.Models;
 
namespace LostInTheWoods.Factory
{
    public class TrailFactory : IFactory<Trail>
    {
        private string connectionString;
        public TrailFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=LostInTheWoods;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(Trail trail)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO Trails (TrailName, Description, TrailLength, ElevationGain, Longitude, Lattitude, CreatedAt, UpdatedAt) VALUES (@TrailName, @Description, @TrailLength, @ElevationGain, @Longitude, @Lattitude, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, trail);
            }
        }

        public IEnumerable<Trail> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM Trails");
            }
        }

        public Trail FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM Trails WHERE Id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}