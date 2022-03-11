using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelSpeed.cs
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var collection = Enumerable.Range(1, 10);

            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var item in collection)
            {
                Calculate(item);
                
            }
            stopwatch.Stop();
            Console.WriteLine($"miliseconds sync: {stopwatch.ElapsedMilliseconds}");

            Stopwatch stopwatchP = Stopwatch.StartNew();
            Parallel.ForEach(collection, item =>
            {
                Calculate(item);
            });
            stopwatchP.Stop();
            Console.WriteLine($"miliseconds para: {stopwatchP.ElapsedMilliseconds}");
        }

        static void Calculate(int item)
        {
            var result = Math.Pow(item, 3);
            Console.WriteLine(item);
            Thread.Sleep(8);
        }
      
    }
}
