
namespace Calc.Calculate
{
    internal sealed class CalculatorSubtraction: IOperationCalculator
    {
        public double Calculate(params double[] parameters)
        {
            return parameters[0] - parameters[1];
        }
    }
}
