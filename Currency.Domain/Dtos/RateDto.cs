using System;

namespace Currency.Domain.Dtos
{
    public class RateDto
    {
        public string Range { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
    }
}
