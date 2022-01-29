using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICardRepository
    {
        Task Create(Card card);

        Task<Card> Find(string cardNumber);

        void Validate(string cardNumber);
    }
}
