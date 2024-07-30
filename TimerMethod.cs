using System;
using System.Diagnostics;

namespace finalProject
{

    public class TimerMethod
    {
        private static Stopwatch stopwatch = new Stopwatch();

        public static void Start()
        {
            stopwatch.Reset();
            stopwatch.Start();
        }
        public static TimeSpan Stop()
        {
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            return elapsedTime;
        }
    }
}

