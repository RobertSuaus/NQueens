using NQueens.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            //int output = Convert.ToInt32(solucion, 2);
            Chromosome[] currentGen = Util.initPopulation();
            foreach (Chromosome chr in currentGen)
            {
                chr.Fitness = Util.findFitness(chr);
                Console.WriteLine(chr.Solution +" "+ chr.Fitness);
            }
            Console.Write("\n\nMarco de torneo de 4\n\n\n\n");
            Chromosome[] nextGen= Util.tournamentSelection(currentGen, 4);
            foreach (Chromosome chr in nextGen)
            {
                Console.WriteLine(chr.Solution+" "+ chr.Fitness);
            }
            Console.WriteLine("El mas alto (bajo) es:"+ Util.highestFit(nextGen).Fitness);

            Console.Read();
        }
    }
}
