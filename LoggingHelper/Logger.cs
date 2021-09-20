using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace UtilHelperLib.LoggingHelper
{
    //https://michaelscodingspot.com/logging-in-dotnet/
    //https://raygun.com/blog/c-sharp-logging-best-practices/
    //https://stanford.edu/~cpiech/cs221/fall12/exams/midterm_practice_solution.pdf
    public class Logger
    {
        public void Instance()
        {
//            Log.Logger = new LoggerConfiguration()
//.MinimumLevel.Debug()
//.WriteTo.Console()
//.WriteTo.File("logs\\my_log.log", rollingInterval: RollingInterval.Day)
//.CreateLogger();
        }
    }
}
