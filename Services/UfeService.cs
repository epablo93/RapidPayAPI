using Service.abstractions;
using System;
using System.Globalization;

namespace Services
{
    public class UfeService : IUfeService
    {
        private decimal lastFee = 1;
        public decimal CalculateFee()
        {
            var random = new Random();
            var first = random.Next(0, 2);
            var floating = first == 2 ? 0 : random.Next(0, 99);
            var randomValue = Convert.ToDecimal($"{first}{CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator}{floating}");
            var fee = randomValue * lastFee;
            lastFee = randomValue;
            return fee;

        }
    }
}
