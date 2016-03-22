namespace BehavioralPatternsApp.Requests
{
    public class Request : IRequest
    {
        public Request(decimal amount)
        {
            this.Amount = amount;
        }

        public decimal Amount { get; private set; }
    }
}