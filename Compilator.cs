using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calc.Calculate;

namespace Calc
{
    class Compilator
    {
        
        /// <summary>
        /// Конструктор
        /// </summary>
        public Compilator()
        {
            
        }

        /// <summary>
        /// Удаляет элементы из коллекции IList
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <param name="operand"></param>
        /// <param name="opn"></param>
        /// <param name="res"></param>
        private void DeleteElement(int e1, int e2, string operand, IList<string> opn, double res )
        {
            opn[e2] = res.ToString(CultureInfo.InvariantCulture);
            var index = opn.IndexOf(opn.First(p => p == operand.ToString(CultureInfo.InvariantCulture)));
            opn.RemoveAt(index);
            opn.RemoveAt(e1);
        }

        /// <summary>
        /// Компиляция
        /// </summary>
        /// <param name="opn">Лист с обратной польской нотацией</param>
        /// <returns></returns>
        public double Compilation(List<string> opn )
        {
            var result = 0.0;
            var number = GetNumberFirstOperand(opn);
            if (number == int.MaxValue || opn.Count() == 1) return Convert.ToDouble(opn[0]);

            IOperationCalculator calculate;
            for (var i = number; i < opn.Count; i++)
            {
                switch (opn[i])
                {
                    case "+":
                        calculate = new CalculatorAddition();
                        result = calculate.Calculate(Convert.ToDouble(opn[i - 2]), Convert.ToDouble(opn[i - 1]));
                        DeleteElement(i - 1, i - 2, "+", opn, result);
                        if (opn.Count > 1)
                            result = Compilation(opn);
                        break;
                    case "-":
                        calculate = new CalculatorSubtraction();
                        result = calculate.Calculate(Convert.ToDouble(opn[i - 2]), Convert.ToDouble(opn[i - 1]));
                        DeleteElement(i - 1, i - 2, "-", opn, result);
                        if (opn.Count > 1)
                            result = Compilation(opn);
                        break;
                    case "*":
                        calculate = new CalculatorMultiplication();
                        result = calculate.Calculate(Convert.ToDouble(opn[i - 2]), Convert.ToDouble(opn[i - 1]));
                        DeleteElement(i - 1, i - 2, "*", opn, result);
                        if (opn.Count > 1)
                            result = Compilation(opn);
                        
                        break;
                    case "/": 
                        calculate = new CalculatorDivision();
                        result = calculate.Calculate(Convert.ToDouble(opn[i - 2]), Convert.ToDouble(opn[i - 1]));
                        DeleteElement(i - 1, i - 2, "/", opn, result);
                        if (opn.Count > 1)
                            result = Compilation(opn);
                       break;

                    case "sin":
                        calculate = new CalculatorSinus();
                        result = calculate.Calculate(Convert.ToDouble(opn[i - 1]));
                        //DeleteElement(i,i-1,"sin",opn,result);
                        break;

                    case "cos":
                        calculate = new CalculatorCosinus();
                        result = calculate.Calculate(Convert.ToDouble(opn[i - 1]));
                        break;
                }
            }
            return result;
        }

        /// <summary>
        /// Получает номер первого операнда
        /// </summary>
        /// <param name="opn"></param>
        /// <returns></returns>
        private int GetNumberFirstOperand(List<string> opn)
        {
            var number = opn.FindIndex(p => (!char.IsDigit(p[0])));
            if (number == null)
                return int.MaxValue;
            return number;
        }
    }
}
