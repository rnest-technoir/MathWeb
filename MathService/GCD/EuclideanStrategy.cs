using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathService.GCD
{
    public class EuclideanStrategy : IGCDStrategy
    {
        public long Run(long x, long y)
        {
            if (y == 0)
                return 0;
            long rest = -1;

            while (rest != 0)
            {
                rest = x % y;
                if (0 == rest) return y;
                x = y;
                y = rest;
            }

            return y;
        }
    }
}
