namespace IssueManager.Interfaces
{
    using System.Collections.Generic;

    public interface IEndpoint
    {
        string Action { get; }

        IDictionary<string, string> Parameters { get; }
    }
}
