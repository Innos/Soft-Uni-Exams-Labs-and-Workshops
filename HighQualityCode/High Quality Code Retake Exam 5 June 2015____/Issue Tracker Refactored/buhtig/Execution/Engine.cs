namespace IssueManager.Execution
{
    using System;

    using IssueManager.Interfaces;

    public class Engine : IEngine
    {
        public Engine(IDispatcher dispatcher, IUserInterface userInterface)
        {
            this.Dispatcher = dispatcher;
            this.UserInterface = userInterface;
        }

        // DI Introduced an IUserInterface and a concrete class ConsoleUserInterface and delegated the tasks for interfacing with the user to it. Introduced UserInterface property in Engine and changed the Engine constructor to accept IUserInterface or to set a default one if no parameters are passed to the constructor. Refactored the logic of the class to work with IUserInterface instead of being coupled to the console.
        public Engine()
            : this(new Dispatcher(), new ConsoleUserInterface())
        {
        }

        public IDispatcher Dispatcher { get; private set; }

        public IUserInterface UserInterface { get; private set; }

        public void Run()
        {
            while (true)
            {
                string url = this.UserInterface.ReadLine();
                if (url == null)
                {
                    break;
                }

                url = url.Trim();
                if (url != string.Empty)
                {
                    try
                    {
                        var ep = new Endpoint(url);
                        string viewResult = this.Dispatcher.DispatchAction(ep);
                        this.UserInterface.WriteLine(viewResult);
                    }
                    catch (Exception ex)
                    {
                        this.UserInterface.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
