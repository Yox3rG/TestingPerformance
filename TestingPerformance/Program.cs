using System;

namespace TestingPerformance
{
    class Program
    {
        static Test test1;
        static Test test2;

        static void Main(string[] args)
        {
            Preparation();

            double firstTest = MeasureTimeOf(test1.Operation);

            double secondTest = MeasureTimeOf(test2.Operation);

            Console.WriteLine($"Time spent first: {firstTest}");
            Console.WriteLine($"Time spent second: {secondTest}");
        }

        static double MeasureTimeOf(Action action)
        {
            var stopWatch = System.Diagnostics.Stopwatch.StartNew();

            action?.Invoke();

            stopWatch.Stop();
            return stopWatch.Elapsed.TotalMilliseconds;
        }

        private static void Preparation()
        {
            test1 = new QueueTest();
            test1.Fill(100000);

            test2 = new StackTest();
            test2.Fill(100000);
        }
    }
}
