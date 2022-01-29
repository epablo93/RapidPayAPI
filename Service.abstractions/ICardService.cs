using Contracts;
using System.Threading.Tasks;

namespace Service.abstractions
{
    public interface ICardService
    {
        Task Create(CardDto cardDto);
        Task<CardDto> Find(string cardNumber);
        void Validate(string cardNumber);
    }
}
