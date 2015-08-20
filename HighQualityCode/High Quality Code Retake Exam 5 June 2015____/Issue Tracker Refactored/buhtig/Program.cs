using System.Globalization;
using System.Threading;

using IssueManager;
using IssueManager.Data;
using IssueManager.Execution;

public class Program
{
    private static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        var database = new IssueTrackerDatabase();
        var issueTracker = new IssueTracker(database);
        var dispatcher = new Dispatcher(issueTracker);
        var engine = new Engine(dispatcher);
        engine.Run();
    }
}