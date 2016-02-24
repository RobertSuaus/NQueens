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
            Chromosome[] currentGen = Util.initPopulation();
            //Una solucion verdadera...
            currentGen[0].Solution = "011110010111001100000101";
            foreach (Chromosome chr in currentGen)
            {
                chr.Fitness = Util.findFitness(chr);
                Console.WriteLine(chr.Solution +" "+ chr.Fitness);
            }
            Console.Write("\n\nMarco de torneo de 2\n\n\n\n");
            Chromosome[] nextGen= Util.tournamentSelection(currentGen);
            foreach (Chromosome chr in nextGen)
            {
                Console.WriteLine(chr.Solution+" "+ chr.Fitness);
            }
            Console.WriteLine("El mejor fitness es:"+ Util.highestFit(nextGen).Fitness);
            Console.WriteLine("El fitness total es:" + Util.findFitness(nextGen));
            Console.Read();
        }
    }
}
