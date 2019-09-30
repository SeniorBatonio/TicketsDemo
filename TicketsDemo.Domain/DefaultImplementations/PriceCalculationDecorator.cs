using System.Collections.Generic;
using TicketsDemo.Data.Entities;
using TicketsDemo.Data.Repositories;
using TicketsDemo.Domain.Interfaces;

namespace TicketsDemo.Domain.DefaultImplementations
{
    class PriceCalculationDecorator : IPriceCalculationStrategy
    {
        IPriceCalculationStrategy _strategy;

        int _teaCount;
        int _coffeeCount;
        int _cookiesCount;

        public PriceCalculationDecorator(IPriceCalculationStrategy strategy, int teaCount, int coffeeCount, int cookiesCount)
        {
            _strategy = strategy;
            _teaCount = teaCount;
            _coffeeCount = coffeeCount;
            _cookiesCount = cookiesCount;
        }

        public List<PriceComponent> CalculatePrice(PlaceInRun placeInRun)
        {
            var priceComponents = new List<PriceComponent>();
            priceComponents.AddRange(_strategy.CalculatePrice(placeInRun));
            var teaComponent = new PriceComponent { Name = "Tea price", Value = PriceList.TEA * _teaCount };
            priceComponents.Add(teaComponent);
            var coffeeComponent = new PriceComponent { Name = "Coffee price", Value = PriceList.COFFEE * _coffeeCount };
            priceComponents.Add(coffeeComponent);
            var cookiesComponent = new PriceComponent { Name = "Cookies price", Value = PriceList.COOKIES * _cookiesCount };
            priceComponents.Add(cookiesComponent);
            return priceComponents;
        }
    }
}
