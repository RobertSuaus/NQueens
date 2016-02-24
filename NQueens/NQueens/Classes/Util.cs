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
        public static Chromosome[] initPopulation(int size = 20)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int randomNumber;
            String queen = "";
            Chromosome[] population = new Chromosome[size];

            for (int i = 0; i < size; i++)
            {
                while (queen.Length < 24)
                {
                    randomNumber = rnd.Next(0, 8);
                    queen = queen + Convert.ToString(randomNumber, 2)
                            .PadLeft(3, '0');
                }
                population[i] = new Chromosome();
                population[i].Solution = queen;
                queen = "";
            }
            return population;
        }

        //Traduce un string binario del cromosoma a un arreglo de enteros
        public static int[] translate(Chromosome chr)
        {
            int[] translation = new int[8];
            int k = 0;
            for (int i = 0; i < 24; i += 3)
            {
                String chunk = chr.Solution.Substring(i, 3);
                translation[k] = Convert.ToInt32(chunk, 2);
                k++;
            }
            return translation;
        }
        //Muta un bit de un cromosoma, si se cumple Pm
        public static Chromosome mutate(Chromosome chr, float Pm=1f)
        {
            //Comprobar que la probabilidad sea menor que Pm
            if (false)
            {
                return chr;
            }
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int i = random.Next(0, 24);
            
            StringBuilder mutatedSolution = new StringBuilder(chr.Solution);
            if (mutatedSolution[i] == '0')
            {
                mutatedSolution[i] = '1';
            }
            else
            {
                mutatedSolution[i] = '0';
            }

            chr.Solution = mutatedSolution.ToString();
            return chr;
        }

        public static Chromosome[] crossover(Chromosome parent1, Chromosome parent2, float Pc=65f)
        {
            //Si no hay cruzamiento se regresan los padres
            if (false)
            {
               Chromosome[] parents = new Chromosome[] { parent1, parent2 };
               return parents;
            }

            String subject1 = "";
            String subject2 = "";
            String subjectC1 = "";
            String subjectC2 = "";
            Chromosome[] offsprings = new Chromosome[2];
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int index = random.Next(1, 8);
            subject1 = parent1.Solution;
            subject2 = parent2.Solution;
            subjectC1 = subject1.Substring(0, index) + subject2.Substring(index);
            subjectC2 = subject2.Substring(0, index) + subject1.Substring(index);
            offsprings[0].Solution = subjectC1;
            offsprings[1].Solution = subjectC2;
            return offsprings;
        }

        //Recibe la poblacion actual y realiza el torneo
        public static Chromosome[] tournamentSelection(Chromosome[] currentGen, int frameSize=2)
        {
            Chromosome[] newGen = new Chromosome[currentGen.Length];
            int i = 0;
            int k = 0;
            do
            {
                Chromosome[] slice = new List<Chromosome>(currentGen)
                                .GetRange(i, frameSize).ToArray();
                newGen[k] = new Chromosome();
                newGen[k] =  highestFit(slice);
                i++;
                k++;
                if (i+frameSize > currentGen.Length) i = 0;
            } while (newGen[19]==null);
            return newGen;
        }

        //Regresa el cromosoma con el fitness mas alto
        public static Chromosome highestFit(Chromosome[] slice)
        {
            //LIFO por si tienen mismo fitness
            Chromosome top= new Chromosome();
            top.Fitness = 100;
            foreach (Chromosome chr in slice)
            {
                if (chr.Fitness <= top.Fitness)
                    top = chr;
            }
            return top;
        }

        //regresa el fitness de un cromosoma
        public static int findFitness(Chromosome chr)
        {
            int collisions = 0;
            int[] solution = translate(chr);

            //Colisiones verticales
            var ocurrences = new Dictionary<int, int>();

            foreach (int value in solution)
            {
                if (ocurrences.ContainsKey(value))
                    ocurrences[value]++;
                else
                    ocurrences[value] = 0;
            }
            foreach (var pair in ocurrences)
                collisions+= pair.Value*pair.Value;

            //Colisiones diagonales
            int delta_row, delta_col;
            for (int i=0; i<8; i++)
            {
                for (int j=0; j<8; j++)
                {
                    if (j != i)
                    {
                        delta_row = i - j;
                        delta_col = solution[i] - solution[j];

                        if (delta_row == delta_col)
                        {
                            collisions++;
                            //Console.WriteLine("["+i+"]["+solution[i]+"] y "+ "[" + j + "][" + solution[j] + "]");
                        }

                        if (delta_row == -delta_col)
                        {
                            collisions++;
                            //Console.WriteLine("[" + i + "][" + solution[i] + "] y " + "[" + j + "][" + solution[j] + "]");
                        }
                    }
                    
                }
            }
            return collisions;
        }
        //regresa el fitness de una poblacion de cromosomas
        public static int findFitness(Chromosome[] population)
        {
            int totalFit=0;
            foreach (Chromosome chr in population)
            {
                totalFit += chr.Fitness;
            }
            return totalFit;
        }
    }
}
