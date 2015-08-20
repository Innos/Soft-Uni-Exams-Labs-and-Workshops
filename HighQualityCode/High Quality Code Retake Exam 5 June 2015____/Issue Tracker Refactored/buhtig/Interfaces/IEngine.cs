namespace IssueManager.Interfaces
{
    public interface IEngine
    {
        IDispatcher Dispatcher { get; }

        void Run();
    }
}
