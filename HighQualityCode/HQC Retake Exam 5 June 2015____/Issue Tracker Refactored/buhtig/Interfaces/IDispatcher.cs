namespace IssueManager.Interfaces
{
    public interface IDispatcher
    {
        IIssueTracker Tracker { get; set; }

        string DispatchAction(IEndpoint endpoint);
    }
}
