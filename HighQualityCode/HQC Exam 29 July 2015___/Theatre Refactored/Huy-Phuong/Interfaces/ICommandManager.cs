using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreManager.Interfaces
{
    public interface ICommandManager
    {
        IPerformanceDatabase Database { get; }

        IAppender Appender { get; }

        void Run();
    }
}
