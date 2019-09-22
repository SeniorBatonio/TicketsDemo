using System;
using System.Collections.Generic;
using TicketsDemo.Data.Entities;
using TicketsDemo.Data.Repositories;
using System.Linq;
using MongoDB.Driver;

namespace TicketsDemo.Mongo.Repositories
{
    class TrainRepository : ITrainRepository
    {
        TicketsContext db = new TicketsContext();

        public void CreateTrain(Train train)
        {
            db.Trains.InsertOne(train);
        }

        public void DeleteTrain(Train train)
        {
            db.Trains.FindOneAndDelete(t => t.Id == train.Id);
        }

        public List<Train> GetAllTrains()
        {
            return db.Trains.Find(_ => true).ToList();
        }

        public Train GetTrainDetails(int trainId)
        {
            return db.Trains.Find(t => t.Id == trainId).FirstOrDefault();
        }

        public void UpdateTrain(Train train)
        {
            db.Trains.ReplaceOne(t => t.Id == train.Id, train);
        }
    }
}
