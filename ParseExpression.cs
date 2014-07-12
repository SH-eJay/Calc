using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public sealed class ParseExpression
    {
        /// <summary>
        /// Исходная строка
        /// </summary>
        private string _expression;

        /// <summary>
        /// 
        /// </summary>
        private Stack<string> _exprassionStack;

        /// <summary>
        /// Выходная строка с обратной польской нотацией
        /// </summary>
        public List<string> Opn;

        private string _operand;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="expression"></param>
        public ParseExpression(string expression)
        {
            _expression = expression;
            _exprassionStack = new Stack<string>();
            Opn = new List<string>();
            ClearExpression();
        }

        /// <summary>
        /// Очищаем от лишних пробелов
        /// </summary>
        private void ClearExpression()
        {
            _expression = _expression.Trim().Replace(" ", string.Empty); ;
        }

        /// <summary>
        /// Меняет местами операнды из стека и выходной строки
        /// </summary>
        /// <param name="element"></param>
        private void Swap(string element)
        {
            Opn.Add(Convert.ToString(_exprassionStack.Pop()));
            _exprassionStack.Push(element);
        }

        /// <summary>
        /// Определяет была ли открывающаяся скобка
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private bool isOpenClose( string element)
        {
            if (_exprassionStack.Count <= 0) return false;
            var operand = _exprassionStack.Peek();
            if (operand == "(")
            {
                _exprassionStack.Push(element);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Анализ входной строки
        /// </summary>
        public void AnalysisExpression()
        {
            for (var index = 0; index < _expression.Count(); index++)
            {
                var e = _expression[index];
                if (char.IsDigit((e)))
                {
                    if (((index + 1) != _expression.Length))
                    {
                        if (_expression[index + 1] == '.')
                        {
                            var number = "";
                            int l;
                            for (l = index; char.IsDigit(_expression[l]) || _expression[l] == '.'; l++)
                            {
                                number += _expression[l];
                            }
                            index = l - 1;
                            Opn.Add(number);
                            continue;
                        }
                    }
                    Opn.Add(Convert.ToString(e));
                    continue;
                }
                switch (e)
                {
                    case '*':
                        if (isOpenClose(Convert.ToString(e)))
                            break;
                        if(_exprassionStack.Count>0)
                            _operand = _exprassionStack.Peek();
                        if (_operand == "/")
                        {
                            Swap(Convert.ToString(e));
                        }
                        else
                        {
                            _exprassionStack.Push(Convert.ToString(e));
                        }
                        break;
                    case '/':
                        if (isOpenClose(Convert.ToString(e)))
                            break;
                        if (_exprassionStack.Count > 0)
                            _operand = _exprassionStack.Peek();
                        if (_operand == "*")
                        {
                            Swap(Convert.ToString(e));
                        }
                        else
                        {
                            _exprassionStack.Push(Convert.ToString(e));
                        }
                        break;

                    case '+':
                    case '-':
                        if (isOpenClose(Convert.ToString(e)))
                            break;
                        if (_exprassionStack.Count > 0)
                            _operand = _exprassionStack.Peek();
                        if (_operand == "*")
                        {
                            Swap(Convert.ToString(e));
                        }
                        else
                        {
                            _exprassionStack.Push(Convert.ToString(e));
                        }
                        break;
                    case '(':
                        _exprassionStack.Push(Convert.ToString(e));
                        break;
                    case ')':
                        var s = " ";
                        while ("(" != s)
                        {
                            s = _exprassionStack.Pop();
                            if ("(" != s)
                                Opn.Add(s);
                        }

                        break;
                }
            }
            while(_exprassionStack.Count>0)
                Opn.Add(_exprassionStack.Pop());
        }
    }
}
