using Contracts;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using Service.abstractions;
using System.Threading.Tasks;

namespace Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task Create(CardDto cardDto)
        {
            Card card = cardDto.Adapt<Card>();

            await _cardRepository.Create(card);
        }

        public async Task<CardDto> Find(string cardNumber)
        {
            var card = await _cardRepository.Find(cardNumber);

            return card.Adapt<CardDto>();
        }

        public void Validate(string cardNumber)
        {
            _cardRepository.Validate(cardNumber);
        }
    }
}
