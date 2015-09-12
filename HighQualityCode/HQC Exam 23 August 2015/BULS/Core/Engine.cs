namespace BangaloreUniversityLearningSystem.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.UserInterface;

    public class Engine : IEngine
    {
        public Engine(IBangaloreUniversityDatabase database, IUserInterface userInterface)
        {
            this.UserInterface = userInterface;
            this.Database = database;
            this.User = null;
        }

        public Engine()
            : this(new BangaloreUniversityDatabase(), new ConsoleUserInterface())
        {
        }

        private IBangaloreUniversityDatabase Database { get; set; }

        private IUserInterface UserInterface { get; set; }

        private User User { get; set; }

        public void Run()
        {
            while (true)
            {
                string input = this.UserInterface.ReadLine();
                if (input == null)
                {
                    break;
                }

                var route = new Route(input);
                var controllerType =
                    Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(type => type.Name == route.ControllerName);
                var controller = Activator.CreateInstance(controllerType, this.Database, this.User) as Controller;
                var action = controllerType.GetMethod(route.ActionName);
                object[] @params = MapParameters(route, action);
                try
                {
                    var view = action.Invoke(controller, @params) as IView;
                    this.UserInterface.WriteLine(view.Display());
                    this.User = controller.CurrentUser;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static object[] MapParameters(Route route, MethodInfo action)
        {
            return action.GetParameters().Select<ParameterInfo, object>(
                p =>
                {
                    if (p.ParameterType == typeof(int))
                    {
                        return int.Parse(route.Parameters[p.Name]);
                    }

                    return route.Parameters[p.Name];
                }).ToArray();
        }
    }
}