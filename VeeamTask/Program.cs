using System;

namespace VeeamTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 3)
            {
                Console.WriteLine("Invalid number of arguments! Please specify a process name, maximum lifespan (in minutes)" +
                    "and a monitoring frequency (in minutes)");
                return;
            }
            ProcessMonitor monitor = new ProcessMonitor(args[0], int.Parse(args[1]), int.Parse(args[2]));
            monitor.MonitorProcess();
        }

        
    }
}
