using System;
using System.Collections.Generic;

namespace Currency.Domain.Models
{
    public class Exchange
    {
        public IDictionary<DateTime, IDictionary<string, double>> Rates { get; set; }
    }
}
