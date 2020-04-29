﻿namespace MathService.Function
{
    public interface IPoint<T> where T : struct
    {
        T X { get; }
        T Y { get; }
    }
}