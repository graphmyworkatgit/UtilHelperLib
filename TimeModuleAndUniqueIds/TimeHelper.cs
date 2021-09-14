using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace UtilHelper.TimeModuleAndUniqueIds
{
    public static class TimeHelper
    {
        public static Stopwatch sp = new Stopwatch();
        public static void startStopWatch()
        {
            sp.Reset();
            sp.Start();
        }
        public static void stopStopWatch()
        {
            sp.Stop();
        }
        public static double GetElapsedTimeInSeconds(string ProgramName="Default")
        {
            var timer1 = sp.Elapsed;
            Console.WriteLine($"'{ProgramName}' :: Elapsed as is - '{timer1}'");
            return TimeSpan.FromMilliseconds(timer1.TotalMilliseconds).TotalSeconds;
        }
    }
}
