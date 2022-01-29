using System;

namespace Domain.Entities
{
    public class Balance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string CardNumber { get; set; }
    }
}
