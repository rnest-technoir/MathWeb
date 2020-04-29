using System.Collections.Generic;
using System.Threading.Tasks;

namespace MathService.PrimeNumbers
{
    public interface IPrimeNumbersGenerator
    {
        IEnumerable<int> Calculate(int min = 0, int max = int.MaxValue);
        Task<IEnumerable<int>> CalculateAsync(int min = 0, int max = int.MaxValue);
    }
}