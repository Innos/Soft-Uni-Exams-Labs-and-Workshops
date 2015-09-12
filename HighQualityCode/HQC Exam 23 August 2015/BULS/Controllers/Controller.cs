namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Enums;
    using BangaloreUniversityLearningSystem.Exceptions;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Utilities;

    public abstract class Controller
    {
        protected Controller(IBangaloreUniversityDatabase database, User user)
        {
            this.Database = database;
            this.CurrentUser = user;
        }

        protected Controller()
            : this(new BangaloreUniversityDatabase(), null)
        {
        }

        public User CurrentUser { get; set; }

        protected IBangaloreUniversityDatabase Database { get; set; }

        protected IView CreateView(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(".", StringComparison.InvariantCulture);
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            string controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            string fullPath = baseNamespace + ".Views." + controllerName + "." + actionName;
            var viewType = Assembly.GetExecutingAssembly().GetType(fullPath);
            return Activator.CreateInstance(viewType, model) as IView;
        }

        protected void EnsureUserIsLoggedIn()
        {
            if (this.CurrentUser == null)
            {
                throw new ArgumentException(Constants.NoLoggedInUserMessage);
            }
        }
    }
}