using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathService.GCD
{
    public class GCDService
    {
        protected readonly IGCDStrategy _strategy;

        public GCDService(IGCDStrategy strategy)
        {
            _strategy = strategy;
        }
        public long Calculate(long x, long y) => _strategy.Run(x, y);
        
    }
}
