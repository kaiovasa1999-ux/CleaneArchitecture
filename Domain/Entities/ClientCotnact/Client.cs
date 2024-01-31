using Domain.Primitives;

namespace Domain.Entities.ClientCotnact
{
    internal class Client : Entity
    {
        private readonly List<CreditCard> _creditCards = new();
        public Client(Guid id, string name, int age, DateTime cdate)
            : base(id)
        {
            Name = name;
            Age = age;
            CDate = cdate;
        }

        public string Name { get; set; }

        public IReadOnlyCollection<CreditCard> CreditCards => _creditCards;

        public int Age { get; set; }

        public DateTime CDate { get; set; }


        public void AddNewCard(CreditCard newCard, Money money)
        {
            if (money.Amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(money));
            }

            if(newCard.CardStatus != CreditCardStatus.Acite)
            {
                throw new ArgumentException(nameof(newCard.CardStatus));
            }
            CreditCard creditCard = CreditCard.Create(this.Id,money);
            _creditCards.Add(creditCard);
        }
    }
}
