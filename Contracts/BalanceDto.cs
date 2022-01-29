using System.Collections.Generic;

namespace Contracts
{
    public class BalanceDto
    {
        public BalanceDto()
        {
            this.Payments = new List<PaymentDto>();
        }

        public decimal Total { get; set; }
        public IList<PaymentDto> Payments { get; set; }
    }
}
