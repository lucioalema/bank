﻿using System.Collections.Generic;
using Bank.Domain.Rates;

namespace Bank.Infrastructure.DataAccess.EF.Init
{
    public class DemoRateFactory
    {
        internal static IList<Rate> SeedRates()
        {
            return new Rate[] {
                new Rate(5m),
                new Rate(6m)
            };
        }
    }
}
