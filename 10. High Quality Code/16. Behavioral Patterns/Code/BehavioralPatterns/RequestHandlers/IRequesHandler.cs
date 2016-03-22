namespace BehavioralPatternsApp.RequestHandlers
{
    using Requests;

    public interface IRequesHandler
    {
        IRequesHandler NextHandler { get; set; }

        bool HandleRequest(IRequest request);
    }
}