using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MathService.Function
{
    public interface IFunctionService<T> where T : struct
    {
        Queue<IPoint<T>> Calculate(Func<T, IPoint<T>> single);
        Queue<IPoint<T>> Calculate(IFunctionCalculation<T> calculation);
        Task<Queue<IPoint<T>>> CalculateAsync(Func<T, IPoint<T>> single);
        Task<Queue<IPoint<T>>> CalculateAsync(IFunctionCalculation<T> calculation);
        void CreateDomain(Queue<T> domain);
    }
}