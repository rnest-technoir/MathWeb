using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathService.PrimeNumbers
{
    public class ParallelForEachConcurrentQueuePrimeNumberCalculationStrategy : SimplePrimeNumberCalculationStrategy
    {
        public override IEnumerable<int> Calculate(int min, int max)
        {
            var queue = new ConcurrentQueue<int>();
            Parallel.ForEach(Enumerable.Range(min, max), (num) => 
            {
                if (IsPrime(num))
                    queue.Enqueue(num);
            });
            return queue;
        }
    }
}
