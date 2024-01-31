using Domain.Entities.ClientCotnact;
using Domain.Primitives;

namespace Domain.Entities;

internal class CreditCard : Entity
{
    public CreditCard(Guid id, CreditCardStatus cardStatus, Guid clientId, Money cardLimit, DateTime cdate)
        : base(id)
    {
        CardStatus = CreditCardStatus.None;
        ClientId = clientId;
        CardLimit = cardLimit ?? throw new ArgumentNullException(nameof(cardLimit));
        CDate = cdate;
    }

    public CreditCardStatus CardStatus { get; private set; }

    public Guid ClientId { get; private set; }
    
    public Money CardLimit { get; private set; }

    public DateTime CDate { get; private set; }

    internal static CreditCard Create(Guid clientId, Money money)
    {
        return new CreditCard(new Guid(), CreditCardStatus.Acite, clientId, money, DateTime.Now);
    }

    public void IncreaseLimit(Money cardLimit)
    {
        if(cardLimit.Amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(cardLimit),"Card limit cannot be less or equal to 0!");
        }

        CardLimit = new Money(cardLimit.Amount, cardLimit.Currency);
    }
    public void ChangeCardStatus(CreditCardStatus newStatus)
    {
        CardStatus = newStatus;
    }
}
