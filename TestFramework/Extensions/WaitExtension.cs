using System;
using System.Threading.Tasks;

namespace TestFramework.Extensions
{
    public static class WaitExtension
    {
        /// <summary>
        /// Time delay for specified number of seconds (avoid using this method without a need)
        /// </summary>
        public static void Delay(int seconds)
        {
            using (var task = Task.Delay(TimeSpan.FromSeconds(seconds)))
            {
                task.Wait();
                task.Dispose();
            }
        }
    }
}
