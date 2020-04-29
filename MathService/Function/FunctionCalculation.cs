using System;
using System.Collections.Generic;
using System.Text;

namespace MathService.Function
{
    public class FunctionCalculation : IFunctionCalculation<double> 
    {
        public Queue<IPoint<double>> GetRange(Queue<double> domain)
        {
            var values = new Queue<IPoint<double>>();

            foreach (double x in domain)
            {
                double denominator = Math.Pow(x, 4) + (3 * Math.Pow(x, 2)) - 4;
                double numerator = (16 - Math.Pow(x, 2));
                double calculation = denominator / numerator;
                values.Enqueue(new Point<double>(x, calculation));

            }
            return values;
        }
    }
}
