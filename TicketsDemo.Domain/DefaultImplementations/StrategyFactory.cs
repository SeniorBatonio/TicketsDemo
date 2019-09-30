using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsDemo.Data.Entities;
using TicketsDemo.Data.Repositories;
using TicketsDemo.Domain.DefaultImplementations.PriceCalculationStrategy;
using TicketsDemo.Domain.Interfaces;

namespace TicketsDemo.Domain.DefaultImplementations
{
    public class StrategyFactory : IStrategyFactory
    {

        public IPriceCalculationStrategy GetStrategy(IRunRepository runRepository, ITrainRepository trainRepository, DTO dto = null)
        {
            var defStrategy = new DefaultPriceCalculationStrategy(runRepository, trainRepository);
            if (dto == null
                 && dto.TeaCount == 0
                 && dto.CoffeeCount == 0
                 && dto.CookiesCount == 0)
            {
                return defStrategy;
            }
            else
            {
                return new PriceCalculationDecorator(defStrategy, dto.TeaCount, dto.CoffeeCount, dto.CookiesCount);
            }
        }
    }
}
