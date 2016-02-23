using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens.Classes
{
    class Util
    {
        //Muta un bit de una solucion, si se cumple Pm
        public static String Mutate(String solution, float Pm)
        {
            //Comprobar que la probabilidad sea menor que Pm
            if (false)
            {
                return solution;
            }
            Random random = new Random();
            int i = random.Next(0, 24);
            
            StringBuilder mutatedSolution = new StringBuilder(solution);
            if (mutatedSolution[i] == '0')
            {
                mutatedSolution[i] = '1';
            }
            else
            {
                mutatedSolution[i] = '0';
            }

            solution = mutatedSolution.ToString();
            return solution;
        }

        
    }
}
