namespace BehavioralPatternsApp.RequestHandlers
{
    using System;

    using Requests;

    public class ThirdHandler : IRequesHandler
    {
        public IRequesHandler NextHandler { get; set; }

        public bool HandleRequest(IRequest request)
        {
            if (request.Amount < 1000)
            {
                Console.WriteLine("{0} handled by third", request.Amount);
                return true;
            }

            if (this.NextHandler != null)
            {
                return this.NextHandler.HandleRequest(request);
            }

            Console.WriteLine("{0} Unhandled", request.Amount);
            return false;
        }
    }
}