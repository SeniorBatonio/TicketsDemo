using MongoDB.Driver;
using System;
using TicketsDemo.Data.Entities;
using TicketsDemo.Data.Repositories;

namespace TicketsDemo.Mongo.Repositories
{
    class TicketRepository : ITicketRepository
    {
        TicketsContext db = new TicketsContext();

        public void Create(Ticket ticket)
        {
            db.Tickets.InsertOne(ticket);
        }

        public Ticket Get(int id)
        {
            return db.Tickets.Find(t => t.Id == id).FirstOrDefault();
        }

        public void Update(Ticket ticket)
        {
            db.Tickets.ReplaceOne(t => t.Id == ticket.Id, ticket);
        }
    }
}
