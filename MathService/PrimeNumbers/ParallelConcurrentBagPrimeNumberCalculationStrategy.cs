using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathService.PrimeNumbers
{
    public class ParallelConcurrentBagPrimeNumberCalculationStrategy : SimplePrimeNumberCalculationStrategy
    {
        public override IEnumerable<int> Calculate(int min, int max)
        {
            var bag = new ConcurrentBag<int>();
            Enumerable.Range(min, max)
                .AsParallel()
                .AsOrdered()
                .ForAll(num => 
                {
                    if (IsPrime(num))
                        bag.Add(num);
                });

                return bag;
        }
    }
}
