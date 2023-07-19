using NUnit.Framework;
using System.Threading;

namespace VeeamTask
{
    [TestFixture]
    internal class ProcessMonitorTests
    {
        private ProcessMonitor monitor;
        private string testProcess;
        private int maxLifespan;
        private int frequency;

        [SetUp]
        public void Setup()
        {
            testProcess = "test";
            maxLifespan = 1;
            frequency = 1;
        }

        [Test]
        public void StartMonitoring()
        {
            monitor = new ProcessMonitor(testProcess, maxLifespan, frequency);
            Thread monitoringThread = new Thread(() => monitor.MonitorProcess());
            monitoringThread.Start();
            Thread.Sleep(3000); // wait for monitoring

            Assert.Pass("Monitoring was succesful");
            monitoringThread.Interrupt();

        }
    }
}
