using Contracts;
using Domain.Repositories;
using Service.abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUfeService _ufeService;
        private readonly ICardService _cardService;
        private readonly IBalanceRepository _balanceRepository;

        public PaymentService(IBalanceRepository balanceRepository, IUfeService ufeService, ICardService cardService)
        {
            _balanceRepository = balanceRepository;
            _ufeService = ufeService;
            _cardService = cardService;
        }

        public async Task Pay(PaymentDto data)
        {
            var card = await _cardService.Find(data.CardNumber);
            if (card == null)
            {
                throw new ApplicationException("Card does not exist.");
            }
            _cardService.Validate(card.Number);

            var totalAmount = data.Amount + _ufeService.CalculateFee();

            await _balanceRepository.Insert(totalAmount, data.CardNumber);
        }

        public async Task<BalanceDto> GetBalance(string cardNumber)
        {
            var card = await _cardService.Find(cardNumber);
            if (card == null) throw new ApplicationException("Card does not exists");

            _cardService.Validate(card.Number);

            var balances = await _balanceRepository.GetBalancesWithCardNumber(card.Number);

            var payments = balances.Select(c => new PaymentDto
            {
                Amount = c.Amount,
                CardNumber = c.CardNumber
            }).ToList();

            var total = payments.Sum(p => p.Amount);

            var result = new BalanceDto
            {
                Total = total,
                Payments = payments
            };

            return result;
        }
    }
}
