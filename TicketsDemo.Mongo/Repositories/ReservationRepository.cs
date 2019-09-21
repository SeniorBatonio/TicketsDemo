using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketsDemo.Data.Entities;
using TicketsDemo.Data.Repositories;

namespace TicketsDemo.Mongo.Repositories
{
    class ReservationRepository : IReservationRepository
    {
        private TicketsContext db = new TicketsContext();

        public void Create(Reservation reservation)
        {
            db.Reservations.InsertOne(reservation);
        }

        public Reservation Get(int id)
        {
            return db.Reservations.Find(x => x.PlaceInRunId == id).FirstOrDefault();
        }

        public List<Reservation> GetAllForPlaceInRun(int placeInRunId)
        {
            return db.Reservations.Find(x => x.PlaceInRunId == placeInRunId).ToList();
        }

        public List<Reservation> GetAllForRun(int runId)
        {
            var run = db.Runs.Find(r => r.Id == runId).FirstOrDefault();
            var placesInRunIds = run.Places.Select(p=> p.Id);
            return db.Reservations.Find(x => placesInRunIds.Contains(x.Id)).ToList();
        }

        public void Update(Reservation reservation)
        {
            db.Reservations.ReplaceOneAsync(r=>r.Id == reservation.Id, reservation);
        }
    }
}
