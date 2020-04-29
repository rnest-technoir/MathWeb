using System.Collections.Generic;

namespace MathService.PrimeNumbers
{
    public interface IPrimeNumberCalculationStrategy
    {
        IEnumerable<int> Calculate(int min, int max);
        bool IsPrime(int n);
    }
}