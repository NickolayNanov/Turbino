namespace Turbino.Domain.Entities
{
    using Turbino.Domain.Entities.Common;

    public class CreditCard : BaseModel
    {
        public CreditCard(string cardNumber, string cvc, string cardOwner)
        {
            this.CardNumber = cardNumber;
            this.Cvc = cvc;
            this.CardOwner = cardOwner;
        }

        public string CardNumber { get; set; }

        public string Cvc { get; set; }

        public string CardOwner { get; set; }

        public string UserId { get; set; }

        public TurbinoUser User { get; set; }
    }
}
