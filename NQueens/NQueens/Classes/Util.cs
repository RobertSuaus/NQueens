using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens.Classes
{
    class Util
    {
        //Crea la poblacion inicial
        public static String[] initPopulation(int size = 20)
        {
            Random rnd = new Random();
            int randomNumber;
            String queen = "";
            String[] population = new String[size];

            for (int i = 0; i < size; i++)
            {
                while (queen.Length < 24)
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

        //Traduce un string binario a un arreglo de enteros
        public static int[] translate(String solution)
        {
            int[] translation = new int[8];
            int k = 0;
            for (int i = 0; i < 24; i += 3)
            {
                String chunk = solution.Substring(i, 3);
                translation[k] = Convert.ToInt32(chunk, 2);
                k++;
            }
            return translation;
        }
        //Muta un bit de una solucion, si se cumple Pm
        public static String mutate(String solution, float Pm)
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

        //Recibe la poblacion actual y realiza el torneo
        public static String[] tournamentSelection(String[] currentGen, int frameSize=2)
        {
            String[] newGen = new String[currentGen.Length];
            int i = 0;
            do
            {
                string[] slice = new List<string>(currentGen)
                                .GetRange(i, i+frameSize).ToArray();
                newGen[i] = highestFit(slice);
                i++;
            } while (newGen.Length < currentGen.Length);
        }

        //Regresa la solucion con el fitness mas alto
        public static String highestFit(String[] slice)
        {
            return slice[0];
        }
        
         //Realiza el crossover de toda la poblacion, falta la probabilidad
        public static String[] crossover(String[] population) {

            String subject1 = "";
            String subject2 = "";
            String subjectC1 = "";
            String subjectC2 = "";
            String[] populationC = new String[2];
            Random random = new Random();
            int index = random.Next(1,8);
           
            for (int i=0;i<= population.Length;i++) {
                subject1 = population[index];
                subject2 = population[index+1];

                subjectC1 = subject1.Substring(0, index) + subject2.Substring(index);
                subjectC2 = subject2.Substring(0, index) + subject1.Substring(index);

                populationC[i] = subjectC1;
                populationC[i + 1] = subjectC2;

                subject1 = "";
                subject2 = "";
                subjectC1 = "";
                subjectC2 = "";
            }

            return populationC;
        }

        //regresa el fitness de una solucion
        public static int fitness(String solution)
        {
            //Las colisiones actuales
            int collisions = 0;
            int[] Solution = translate(solution);

            return 0;
        }
        //regresa el fitness de una poblacion
        public static int fitness(String[] population)
        {
            return 0;
        }
    }
}
