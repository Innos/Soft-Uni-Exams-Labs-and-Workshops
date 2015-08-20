using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheatreManager.Exceptions
{
    public class TimeDurationOverlapException : Exception
    {
        public TimeDurationOverlapException(string msg)
            : base(msg)
        {
        }
    }
}
