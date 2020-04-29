using System.Collections.Generic;

namespace MathService.Function
{
    public interface IFunctionCalculation<T> where T : struct
    {
        Queue<IPoint<T>> GetRange(Queue<T> domain);
    }
}