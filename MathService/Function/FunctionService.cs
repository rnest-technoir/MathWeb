using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MathService.Function
{
    public class FunctionService<T> : IFunctionService<T> where T: struct
    {
        protected Queue<T> _domain;
        protected Queue<IPoint<T>> _values;

        public FunctionService(Queue<T> domain)
        {
            _domain = domain;
            _values = new Queue<IPoint<T>>();
        }

        public FunctionService()
        {
            _domain = null;
            _values = new Queue<IPoint<T>>();
        }

        public void CreateDomain(Queue<T> domain)
        {
            _domain = domain;
        }

        public Queue<IPoint<T>> Calculate(Func<T, IPoint<T>> single)
        {
            foreach (var x in _domain)
            {
                _values.Enqueue(single(x));
            }
            return _values;
        }

        public Queue<IPoint<T>> Calculate(IFunctionCalculation<T> calculation) => calculation.GetRange(_domain);

        public async Task<Queue<IPoint<T>>> CalculateAsync(Func<T, IPoint<T>> single) => await Task.Run(() => Calculate(single));


        public async Task<Queue<IPoint<T>>> CalculateAsync(IFunctionCalculation<T> calculation) => await Task.Run(() => calculation.GetRange(_domain));


    }
}
