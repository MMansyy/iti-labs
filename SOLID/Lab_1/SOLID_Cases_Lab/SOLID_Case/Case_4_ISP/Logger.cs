using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case_Answer.Case_Answer_4_ISP
{
    public interface ILogMessage
    {
        void LogMessage(string message);
    }

    public interface ILogWarning
    {
        void LogWarning(string message);
    }

    public interface ILogError
    {
        void LogError(string message);
    }


    public class FileLogger : ILogMessage, ILogWarning
    {
        public void LogMessage(string message)
        {
            // Log message to file
        }

        public void LogWarning(string message)
        {
            // Log warning to file
        }
    }

    public class DatabaseLogger : ILogMessage, ILogWarning, ILogError
    {
        public void LogMessage(string message)
        {
            // Log message to database
        }

        public void LogWarning(string message)
        {
            // Log warning to database
        }

        public void LogError(string message)
        {
            // Log error to database
        }
    }

}
