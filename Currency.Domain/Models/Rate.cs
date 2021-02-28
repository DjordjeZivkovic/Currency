using System;

namespace Currency.Domain.Models
{
    public class Rate
    {
        public string Range { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}
