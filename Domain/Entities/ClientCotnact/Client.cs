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


        public CreditCard AddNewCard(CreditCard newCard, Money money)
        {
            if (money.Amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(money));
            }

            if(newCard.CardStatus != CreditCardStatus.Acite)
            {
                throw new ArgumentException(nameof(newCard.CardStatus));
            }

            CreditCard card = new CreditCard(new Guid(), newCard.CardStatus, this.Id, money, DateTime.Now);
            _creditCards.Add(card);

            return card;

        }
    }
}
