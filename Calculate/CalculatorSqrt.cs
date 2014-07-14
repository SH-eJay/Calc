using System;

namespace Calc.Calculate
{
    internal sealed class CalculatorSqrt : IOperationCalculator
    {
        public double Calculate(params double[] parameters)
        {
            return Math.Sqrt(parameters[0]);
        }
    }
}
