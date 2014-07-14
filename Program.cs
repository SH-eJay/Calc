using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {

            var s = Convert.ToDouble("33,3");

            while (true)
            {
                var str1 = Console.ReadLine();
                ParseExpression pars = new ParseExpression(str1);
                pars.AnalysisExpression();
                Compilator compiller = new Compilator();
                var rs = compiller.Compilation(pars.Opn);
                Console.WriteLine(rs);
            }
            string str = "1+3*2/(1+2)";
            
        }
    }
}
