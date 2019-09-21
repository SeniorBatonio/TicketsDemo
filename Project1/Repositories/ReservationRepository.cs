using System;
using System.Collections.Generic;
using TicketsDemo.Data.Entities;
using TicketsDemo.Data.Repositories;

namespace TicketsDemo.Mongo.Repositories
{
    class ReservationRepository : IReservationRepository
    {
        public void Create(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Reservation Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAllForPlaceInRun(int placeInRunId)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAllForRun(int runId)
        {
            throw new NotImplementedException();
        }

        public void Update(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
