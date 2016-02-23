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

        public static String[] initPopulation(int size=20)
        {
            Random rnd = new Random();
            int randomNumber;
            String queen="";
            String[] population = new String[size];

            for (int i = 0; i < size; i++)
            {
                while (queen.Length<24)
                {
                    randomNumber = rnd.Next(0, 8);
                    queen = queen + Convert.ToString(randomNumber, 2)
                            .PadLeft(3, '0');
                }
                population[i] = queen;
                queen = "";
            }
            return population;
        }
    }
}
