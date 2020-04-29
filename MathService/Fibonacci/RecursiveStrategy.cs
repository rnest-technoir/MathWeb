using System;
using System.Collections.Generic;
using System.Text;

namespace MathService.Fibonacci
{
    public class RecursiveStrategy : IFibonacciStrategy
    {
        public Queue<long> Generate(int rounds)
        {
            long first = 1;
            long sec = 1;

            var queue = new Queue<long>();

            queue.Enqueue(0);
            queue.Enqueue(1);
            queue.Enqueue(1);

            Fibonacci(queue, first, sec, 2, rounds);

            return queue;
        }

        protected virtual void Fibonacci(Queue<long> queue, long first, long sec, int counter, int rounds)
        {
            counter = counter + 1;

            if (counter < rounds)
            {
                var res = first + sec;
                queue.Enqueue(res);
                Fibonacci(queue, sec, res, counter, rounds);

            }

        }
    }
}
