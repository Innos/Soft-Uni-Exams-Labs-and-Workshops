namespace IssueManager.Execution
{
    using System.Collections.Generic;

    using System.Linq;

    using System.Net;

    using IssueManager.Interfaces;

    public class Endpoint : IEndpoint
    {
        public Endpoint(string action)
        {
            int questionMark = action.IndexOf('?');
            if (questionMark != -1)
            {
                this.Action = action.Substring(0, questionMark);
                var pairs =
                    action.Substring(questionMark + 1)
                        .Split('&')
                        .Select(x => x.Split('=').Select(WebUtility.UrlDecode).ToArray());
                var parameters = pairs.ToDictionary(pair => pair[0], pair => pair[1]);

                this.Parameters = parameters;
            }
            else
            {
                this.Action = action;
            }
        }

        public string Action { get; set; }

        public IDictionary<string, string> Parameters { get; set; }
    }
}
