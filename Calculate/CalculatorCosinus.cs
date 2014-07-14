using System;

namespace Calc.Calculate
{
    internal sealed class CalculatorCosinus : IOperationCalculator
    {
        public double Calculate(params double[] parameters)
        {
            return Math.Cos(parameters[0]);
        }
    }
}