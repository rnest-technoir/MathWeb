using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathService.PrimeNumbers
{
    public class ParallelStackPrimeNumberCalculationStrategy : SimplePrimeNumberCalculationStrategy
    {
        public override IEnumerable<int> Calculate(int min, int max)
        {
            var stack = new ConcurrentStack<int>();
            Enumerable.Range(min, max)
                .AsParallel()
                .AsOrdered()
                .ForAll(num => 
                {
                    if (IsPrime(num))
                        stack.Push(num);
                });

                return stack;
        }
    }
}
