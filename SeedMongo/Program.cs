using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsDemo.Data.Entities;
using TicketsDemo.Mongo.Repositories;

namespace SeedMongo
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new TicketsDemo.Mongo.TicketsContext();
            Func<List<Place>> placeGenerator = () =>
            {
                var retIt = new List<Place>();
                Random random = new Random();


                for (int i = 0; i < 100; i++)
                {
                    decimal randomNumber = random.Next(80, 120);
                    var newPlace = new Place() { Number = i, PriceMultiplier = randomNumber / 100 };
                    retIt.Add(newPlace);
                }
                return retIt;
            };

            context.Trains.InsertMany(new List<Train> {
              new Train
              {
                  Id = 1,
                  Number = 90,
                  StartLocation = "Kiev",
                  EndLocation = "Odessa",
                  Carriages = new List<Carriage>() {
                      new Carriage() {
                          Places = placeGenerator(),
                          Type = CarriageType.SecondClassSleeping,
                          DefaultPrice = 100m,
                          Number = 1,
                      },new Carriage() {
                          Places = placeGenerator(),
                          Type = CarriageType.SecondClassSleeping,
                          DefaultPrice = 100m,
                          Number = 2,
                      },new Carriage() {
                          Places = placeGenerator(),
                          Type = CarriageType.FirstClassSleeping,
                          DefaultPrice = 120m,
                          Number = 3,
                      },new Carriage() {
                          Places = placeGenerator(),
                          Type = CarriageType.FirstClassSleeping,
                          DefaultPrice = 130m,
                          Number = 4,
                      }
                  }
              },
              new Train
              {
                  Id = 2,
                  Number = 720,
                  StartLocation = "Kiev",
                  EndLocation = "Vinnitsa",
                  Carriages = new List<Carriage>() {
                      new Carriage() {
                          Places = placeGenerator(),
                          Type = CarriageType.Sedentary,
                          DefaultPrice = 40m,
                          Number = 1,
                      },new Carriage() {
                          Places = placeGenerator(),
                          Type = CarriageType.Sedentary,
                          DefaultPrice = 40m,
                          Number = 2,
                      },new Carriage() {
                          Places = placeGenerator(),
                          Type = CarriageType.Sedentary,
                          DefaultPrice = 40m,
                          Number = 3,
                      }
                  }
              }
            });
              



        }
    }
}
