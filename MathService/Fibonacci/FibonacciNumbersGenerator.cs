using System;
using System.Collections.Generic;
using System.Text;

namespace MathService.Fibonacci
{
    public class FibonacciNumbersGenerator : IFibonacciNumbersGenerator
    {
        protected IFibonacciStrategy _strategy;

        public FibonacciNumbersGenerator(IFibonacciStrategy strategy)
        {
            _strategy = strategy;
        }

        public FibonacciNumbersGenerator() { }

        public Queue<long> Generate(int rounds)
        {
            return _strategy.Generate(rounds);
        }

        public Queue<long> Generate(int rounds, IFibonacciStrategy strategy)
        {
            return strategy.Generate(rounds);
        }
    }
}
