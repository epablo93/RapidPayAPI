using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly MainDbContext _context;
        public CardRepository(MainDbContext context)
        {
            _context = context;
        }

        public async Task Create(Card card)
        {
            Validate(card.Number);

            var existingCard = await Find(card.Number);
            if (existingCard != null)
            {
                throw new ApplicationException("Card already exists.");
            }

            _context.Cards.Add(new Card
            {
                Number = card.Number
            });

            await _context.SaveChangesAsync();
        }

        public async Task<Card> Find(string cardNumber)
        {
            return await _context.Cards.FirstOrDefaultAsync(c => c.Number == cardNumber);
        }

        public void Validate(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length != 15)
            {
                throw new ApplicationException("Invalid card number.");
            }
        }
    }
}
