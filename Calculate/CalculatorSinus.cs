using System;

namespace Calc.Calculate
{
    internal sealed class CalculatorSinus:IOperationCalculator
    {
        public double Calculate(params double[] parameters)
        {
            return Math.Sin(parameters[0]);
        }
    }
}