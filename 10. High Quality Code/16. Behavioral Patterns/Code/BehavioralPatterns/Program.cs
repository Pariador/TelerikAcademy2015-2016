namespace BehavioralPatternsApp
{
    using Requests;
    using RequestHandlers;

    public static class Program
    {
        public static void Main()
        {
            IRequesHandler first = new FirstHandler();
            IRequesHandler second = new SecondHandler();
            IRequesHandler third = new ThirdHandler();

            first.NextHandler = second;
            second.NextHandler = third;

            first.HandleRequest(new Request(7));
            first.HandleRequest(new Request(50));
            first.HandleRequest(new Request(500));
            first.HandleRequest(new Request(699));
            first.HandleRequest(new Request(5000));
        }
    }
}