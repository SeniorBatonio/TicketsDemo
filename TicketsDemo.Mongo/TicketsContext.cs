using MongoDB.Driver;
using System.Configuration;
using TicketsDemo.Data.Entities;

namespace TicketsDemo.Mongo
{
    class TicketsContext
    {
        IMongoDatabase database; 

        public IMongoCollection<Reservation> Reservations { get; set; }

        public IMongoCollection<PlaceInRun> PlacesInRun { get; set; }
        public IMongoCollection<Run> Runs { get; set; }

        public IMongoCollection<PriceComponent> PriceComponents { get; set; }
        public IMongoCollection<Ticket> Tickets { get; set; }

        public IMongoCollection<Carriage> Carriages { get; set; }
        public IMongoCollection<Place> Places { get; set; }
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

            Reservations = database.GetCollection<Reservation>("Reservations");

            PlacesInRun = database.GetCollection<PlaceInRun>("PlacesInRun");
            Runs = database.GetCollection<Run>("Runs");

            PriceComponents = database.GetCollection<PriceComponent>("PriceComponents");
            Tickets = database.GetCollection<Ticket>("Tickets");

            Carriages = database.GetCollection<Carriage>("Carriages");
            Places = database.GetCollection<Place>("Places");
            Trains = database.GetCollection<Train>("Trains");
        }
    }
}
