using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBalanceRepository
    {
        Task Insert(decimal totalAmount, string cardNumber);

        Task<IEnumerable<Balance>> GetBalancesWithCardNumber(string cardNumber);
    }
}
