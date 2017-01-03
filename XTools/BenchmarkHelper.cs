using System;
using System.Threading.Tasks;

namespace XTools
{
    public class Benchmark
    {
        /// <summary>
        /// Measures execution time of a method
        /// </summary>
        /// <param name="action"></param>
        /// <returns>execution time in milliseconds</returns>
        public static int MeasureTime(Action action)
        {
            int time = Environment.TickCount;
            action();
            return Environment.TickCount - time;
        }

        public static async Task<int> MeasureTimeAsync(Func<Task> action)
        {
            int time = Environment.TickCount;
            await action();
            return Environment.TickCount - time;
        }
    }
}
