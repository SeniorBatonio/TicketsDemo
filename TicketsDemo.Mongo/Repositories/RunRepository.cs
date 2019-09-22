using System;
using System.Collections.Generic;
using TicketsDemo.Data.Entities;
using TicketsDemo.Data.Repositories;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TicketsDemo.Mongo.Repositories
{
    class RunRepository : IRunRepository
    {
        TicketsContext db = new TicketsContext();
        ITrainRepository _trainRepo;

        public RunRepository(ITrainRepository trainRepo)
        {
            _trainRepo = trainRepo;
        }

        #region IRunRepository Members
        public void CreateRun(Run run)
        {
            db.Runs.InsertOne(run);
        }

        public void DeleteRun(int runId)
        {
            var filter = Builders<Run>.Filter.Eq("_id", runId);
            db.Runs.FindOneAndDelete(filter);
        }

        public PlaceInRun GetPlaceInRun(int placeInRunId)
        {
           return db.PlacesInRun
                    .Find(x => x.Id == placeInRunId).FirstOrDefault();
        }

        public Run GetRunDetails(int runId)
        {
            return db.Runs.Find(r => r.Id == runId).Single();
        }

        public List<Run> GetRuns(DateTime start, DateTime end, int? trainId = default(int?))
        {
            return db.Runs.Find(r => r.Date > start && r.Date < end && (trainId == null || r.TrainId == trainId)).ToList();
        }
        #endregion
    }
}
