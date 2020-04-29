using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathService.PrimeNumbers
{
    public class SimplePrimeNumberCalculationStrategy : IPrimeNumberCalculationStrategy
    {
        public virtual bool IsPrime(int n)
        {
            if (n < 2)
                return false;
            if (n > 2)
                for (int i = 2; i * i <= n; i++)
                    if (n % i == 0)
                        return false;
            return true;
        }

        public virtual IEnumerable<int> Calculate(int min, int max)
        {
            return new HashSet<int>(Enumerable.Range(min, max).Where(num => IsPrime(num)).ToList());
        }
    }
}
