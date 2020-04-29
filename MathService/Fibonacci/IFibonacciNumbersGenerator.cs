using System.Collections.Generic;

namespace MathService.Fibonacci
{
    public interface IFibonacciNumbersGenerator
    {
        Queue<long> Generate(int rounds);
        Queue<long> Generate(int rounds, IFibonacciStrategy strategy);
    }
}