using System;
using System.Diagnostics;
using System.Threading;

namespace VeeamTask
{
    internal class ProcessMonitor
    {
        string name;
        int maxLifespan;
        int frequency;

        public ProcessMonitor(string name, int maxLifespan, int frequency)
        {
            this.name = name;
            this.maxLifespan = maxLifespan;
            this.frequency = frequency;
        }

        public void MonitorProcess()
        {
            Console.WriteLine("Monitoring " + this.name + " every " + this.frequency + " minutes.");

            while (true)
            {
                Console.WriteLine("Press 'q' to stop monitoring. Any other key to continue: ");
                string input = Console.ReadLine();
                if (input.Equals("q"))
                {
                    Console.WriteLine("Monitoring has been stopped.");
                    break;
                }

                CheckProcess();

                //from miliseconds to minutes
                Thread.Sleep(frequency * 60000);
            }
        }

        public void CheckProcess()
        {
            Process[] processes = Process.GetProcessesByName(this.name);

            foreach (Process process in processes)
            {
                TimeSpan lifeTime = DateTime.Now - process.StartTime;
                if (lifeTime.TotalMinutes > this.maxLifespan)
                {
                    KillProcess(process);
                }
            }
        }

        static public void KillProcess(Process process)
        {
            Console.WriteLine("Killing process: " + process.ProcessName);
            process.Kill();
        }
    }
}
