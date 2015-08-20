namespace IssueManager.Interfaces
{
    using IssueManager.Model;

    public interface IIssueTracker
    {
        /// <summary>
        /// The method registers a new user in the database.
        /// </summary>
        /// <param name="username">The username of the user to be registered.</param>
        /// <param name="password">The password of the user to be registered.</param>
        /// <param name="confirmPassword">The above password retyped, to confirm the password is the same.</param>
        /// <returns>The method returns a string message with the result of the log attempt, if there is already a logged in user, the passwords don't match or the the given username is already in the database returns an error message.</returns>
        string RegisterUser(string username, string password, string confirmPassword);

        /// <summary>
        /// The method sets the Current User property in the database to the user with given username and password, if no such user exists, the password is incorrect or there is already a logged in user throws an appropriate message.
        /// </summary>
        /// <param name="username">The username of the user, who tries to log in.</param>
        /// <param name="password">The password of the user, who tries to log in.</param>
        /// <returns>The method returns a string message with the result of the log in attempt.</returns>
        string LoginUser(string username, string password);

        /// <summary>
        /// The method logs out the currently logged in user, if there is no user logged in throws an appropriate message.
        /// </summary>
        /// <returns>The method returns a string message with the result of the log out attempt.</returns>
        string LogoutUser(); 

        /// <summary>
        /// The method creates a new instance of the Issue class and calls the database's Add Issue method to add the issue to the database.
        /// </summary>
        /// <param name="title">The title of the issue to be created.</param>
        /// <param name="description">The description of the issue to be created.</param>
        /// <param name="priority">The priority of the issue to be created.</param>
        /// <param name="tags">The tags that the issue can be found by.</param>
        /// <returns>The method returns a string message with the result of the Create Issue attempt.</returns>
        string CreateIssue(string title, string description, IssuePriority priority, string[] tags);

        /// <summary>
        /// The method calls the database's remove issue method, if there is no logged in user, the given issue ID is wrong or it doesn't belong to the current user gives an appropriate message.
        /// </summary>
        /// <param name="issueId">The ID of the issue to be removed.</param>
        /// <returns>The method returns a string message with the result of the Remove issue attempt.</returns>
        string RemoveIssue(int issueId);

        /// <summary>
        /// The method adds a comment from the currently logged in user to the issue with the given Id.
        /// </summary>
        /// <param name="issueId">The id of the issue where the comment should be added.</param>
        /// <param name="text">The text of the comment.</param>
        /// <returns>The method returns a string message with the result of the Add Comment attempt.</returns>
        string AddComment(int issueId, string text); 

        /// <summary>
        /// The method attempts to return all the issues of the current user as a string representation.
        /// </summary>
        /// <returns>The method returns a string representation of all the issues of the currently logged in user, or an appropriate message if there is no logged in user or the current user has no issues.</returns>
        string GetMyIssues(); 

        /// <summary>
        /// The method attempts to return all the comments of the currently logged in user.
        /// </summary>
        /// <returns>The method returns a string with all the comments of the current user, if there is no currently logged in user or the user has no comments returns an appropriate message.</returns>
        string GetMyComments(); 

        /// <summary>
        /// The method attemts to return all issues with atleast one of the searched for tags.
        /// </summary>
        /// <param name="tags">A string array with the tags that are searched for.</param>
        /// <returns>The method returns a string message with the result of the search, if no tags are provided or there are no issues which meets the searched requirments returns an appropriate message.</returns>
        string SearchForIssues(string[] tags);
    }
}