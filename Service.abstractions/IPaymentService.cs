using Contracts;
using System.Threading.Tasks;

namespace Service.abstractions
{
    public interface IPaymentService
    {
        Task<BalanceDto> GetBalance(string cardNumber);
        Task Pay(PaymentDto data);
    }
}
