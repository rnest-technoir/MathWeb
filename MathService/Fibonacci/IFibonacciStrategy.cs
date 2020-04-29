using System.Collections.Generic;

namespace MathService.Fibonacci
{
    public interface IFibonacciStrategy
    {
        Queue<long> Generate(int rounds);
    }
}