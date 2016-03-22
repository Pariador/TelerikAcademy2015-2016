namespace BehavioralPatternsApp.RequestHandlers
{
    using System;

    using Requests;

    public class SecondHandler : IRequesHandler
    {
        public IRequesHandler NextHandler { get; set; }

        public bool HandleRequest(IRequest request)
        {
            if (request.Amount < 100)
            {
                Console.WriteLine("{0} handled by second", request.Amount);
                return true;
            }

            if (this.NextHandler != null)
            {
                return this.NextHandler.HandleRequest(request);
            }

            return false;
        }
    }
}