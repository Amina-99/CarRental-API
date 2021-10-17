using DiplomskiRad.Data;
using DiplomskiRad.DTOS;
using DiplomskiRad.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomskiRad.Services
{
    public class AnalyticsService: IAnalyticsService
    {
        private readonly DataContext _context;
        private readonly ILogger<AnalyticsService> _logger;

        public AnalyticsService(DataContext context, ILogger<AnalyticsService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<MonthIncomeDTO>> GetMonthIncomeAsync()
        {
            try
            {
                var result = await _context.Reservations
                    .AsNoTracking()
                    .GroupBy(r => r.EndDate.Month)
                    .Select(r => new MonthIncomeDTO
                    {
                        MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(r.Key),
                        Income = r.Sum(r => r.Total)
                    }).ToListAsync();
                return result;
            }
            catch(Exception e)
            {
                _logger.LogError(e, nameof(GetMonthIncomeAsync));
                throw;
            }
        }
    }
}
