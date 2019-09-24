using MongoDB.Driver;
using System.Configuration;
using TicketsDemo.Data.Entities;

namespace TicketsDemo.Mongo
{
    class TicketsContext
    {
        IMongoDatabase database; 

        public IMongoCollection<Train> Trains { get; set; }

        public TicketsContext()
        {
            // строка подключения
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;
            var connection = new MongoUrlBuilder(connectionString);
            // получаем клиента для взаимодействия с базой данных
            MongoClient client = new MongoClient(connectionString);
            // получаем доступ к самой базе данных
            database = client.GetDatabase(connection.DatabaseName);

            Trains = database.GetCollection<Train>("Trains");
        }
    }
}
