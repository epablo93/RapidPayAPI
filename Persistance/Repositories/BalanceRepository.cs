using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly MainDbContext _mainDbContext;

        public BalanceRepository(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }

        public async Task Insert(decimal totalAmount, string cardNumber)
        {
            _mainDbContext.Balance.Add(new Balance
            {
                Date = DateTime.Today,
                Amount = totalAmount,
                CardNumber = cardNumber
            });

            await _mainDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Balance>> GetBalancesWithCardNumber(string cardNumber)
        {
            return await _mainDbContext.Balance.Where(x => x.CardNumber == cardNumber).ToListAsync();
        }
    }
}
