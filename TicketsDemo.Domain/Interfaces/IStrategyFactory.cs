using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsDemo.Data.Entities;
using TicketsDemo.Data.Repositories;

namespace TicketsDemo.Domain.Interfaces
{
    public interface IStrategyFactory
    {
        IPriceCalculationStrategy GetStrategy(IRunRepository runRepository, ITrainRepository trainRepository, DTO dto = null);
    }
}
