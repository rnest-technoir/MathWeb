using System;
using System.Collections.Generic;
using System.Text;

namespace MathService.Fibonacci
{
    public class LoopStrategy : IFibonacciStrategy
    {
        public Queue<long> Generate(int rounds)
        {
            var queue = new Queue<long>();

            queue.Enqueue(0);
            queue.Enqueue(1);
            queue.Enqueue(1);

            long res = 0;
            long first = 1;
            long sec = 1;

            for (int i = 2; i <= rounds - 2; i++)
            {
                res = first + sec;
                queue.Enqueue(res);
                first = sec;
                sec = res;
            }

            return queue;
        }
    }
}
