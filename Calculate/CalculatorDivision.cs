using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Calculate
{
    internal sealed class CalculatorDivision : IOperationCalculator
    {
        public double Calculate(params double[] parameters)
        {
            return parameters[0]/parameters[1];
        }
    }
}
