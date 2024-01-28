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


    }
}
