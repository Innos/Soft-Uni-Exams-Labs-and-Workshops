/*//////////////////////////////////////
///                                  ///
///   Author: Huy Phuong Nguyen,     ///
///   Qui Nhơn, Bình Định, Vietnam   ///
///   Email: huy_p_n@yahoo.vn        ///
///                                  ///
//////////////////////////////////////*/

namespace TheatreManager
{
    using System;

    public class PerformanceDatabaseTest
    {
        public static void Main()
        {
            var consoleAppender = new ConsoleAppender();
            var database = new PerformanceDatabase();
            var commandManager = new CommandManager(database, consoleAppender);
            commandManager.Run();
        }
    }
}
