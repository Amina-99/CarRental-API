using DiplomskiRad.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiRad.Interfaces
{
    public interface IAnalyticsService
    {
        Task<IEnumerable<MonthIncomeDTO>> GetMonthIncomeAsync();

    }
}
