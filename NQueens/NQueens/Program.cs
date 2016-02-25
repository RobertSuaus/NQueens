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
        static void Main(int[] args)
        {
            /*Chromosome[] currentGen = Util.initPopulation();
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
            Console.WriteLine("El fitness total es:" + Util.findFitness(nextGen));*/
			
			//Soluciona el problema de las N Reinas
			if(args.Lenght<4)
			{
				Console.WriteLine("Uso: Nqueens.exe NumPoblacion Generaciones Pc Pm");
				return 0;
			}
			
			Chromosome[] currentGen= new Chromosome[n];
			currentGen= Util.initPopulation(n);
			foreach (Chromosome chr in currentGen)
				{
					chr.Fitness= Util.findFitness(chr);
				}
			
			var generations = new Dictionary<int, Chromosome[]>();
			generations[0]= currentGen;
			
			//Repetir por args[1] generaciones
			for(int i=1; i<=gen; i++)
			{
				//Seleccionamos los candidatos para el crossover
				currentGen= Util.tournamentSelection(currentGen);
				var newGen;
				
				//Crossover
				for(int j=0; j<n; j+=2)
				{
					Chromosome[] offsprings= new Chromosome[2];
					offsprings= Util.crossover(currentGen[j], currentGen[j+1], Pc);
					newGen= newGen.Concat(offsprings).toArray();
				}
				
				//Mutacion
				foreach(Chromosome chr in newGen)
				{
					chr= Util.mutation(chr, Pm);
					chr= Util.findFitness(chr);
				}
				
				generations[i]= newGen;
				currentGen= newGen;
			}
			//Todas las generaciones
			Chromosome[] bestGeneration= new Chromosome[n];
			int bestFit=10000;
			foreach (var pair in generations)
			{
				Console.WriteLine("----Generacion "+pair.Key+" ----");
				foreach (Chromosome chr in pair.Value)
				{
					Console.WriteLine("Reinas: "+chr.Solution+" Fitness: "+chr.Fitness);
				}
				int genFitness= Util.findFitness(pair.Value);
				Console.Write("Fitness de la generacion: "+ genFitness+"\n\n");
				if (genFitness<=bestFit)
				{
					bestGeneration= pair.Value;
				}
			}
            Console.Read();
			
        }
    }
}
