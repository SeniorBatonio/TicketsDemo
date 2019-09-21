using System;
using System.Collections.Generic;
using TicketsDemo.Data.Entities;
using TicketsDemo.Data.Repositories;

namespace TicketsDemo.Mongo.Repositories
{
    class RunRepository : IRunRepository
    {
        public void CreateRun(Run run)
        {
            throw new NotImplementedException();
        }

        public void DeleteRun(int runId)
        {
            throw new NotImplementedException();
        }

        public PlaceInRun GetPlaceInRun(int placeInRunId)
        {
            throw new NotImplementedException();
        }

        public Run GetRunDetails(int runId)
        {
            throw new NotImplementedException();
        }

        public List<Run> GetRuns(DateTime start, DateTime end, int? trainId = default(int?))
        {
            throw new NotImplementedException();
        }
    }
}
