using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathService.Function
{
    public class Point<T> : IPoint<T> where T: struct
    {
        public Point(T x, T y)
        {
            X = x;
            Y = y;
        }

        [JsonProperty(PropertyName = "px")]
        public T X { get; private set; }

        [JsonProperty(PropertyName = "py")]
        public T Y { get; private set; }
    }
}
