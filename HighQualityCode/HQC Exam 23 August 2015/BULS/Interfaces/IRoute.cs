namespace BangaloreUniversityLearningSystem.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// A class that carries all information needed about executing a command.
    /// </summary>
    public interface IRoute
    {
        /// <summary>
        /// The name of the controller that will process the action.
        /// </summary>
        string ControllerName { get; }

        /// <summary>
        /// The name of the method to be executed.
        /// </summary>
        string ActionName { get; }

        /// <summary>
        /// A IDictionary of the input parameters as strings.
        /// </summary>
        IDictionary<string, string> Parameters { get; }
    }
}
