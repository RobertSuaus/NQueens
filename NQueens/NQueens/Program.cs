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
            if(args.Length<4)
			{
				Console.WriteLine("Uso: Nqueens.exe NumPoblacion Generaciones Pc Pm");
				return ;
			}
            int n = Int32.Parse(args[0]);
            float Pm = float.Parse(args[3]);
            float Pc = float.Parse(args[2]);
            int gen = Int32.Parse(args[1]);
            Chromosome[] currentGen= new Chromosome[n];
			currentGen= Util.initPopulation(n);
			foreach (Chromosome chr in currentGen)
			{
				chr.Fitness= Util.findFitness(chr);
			}
            

            var generations = new Dictionary<int, Chromosome[]>();
			generations[0]= currentGen;
            bool exit = false;
            //Repetir por args[1] generaciones
			for(int i=1; i<=gen && !exit; i++)
			{
				//Seleccionamos los candidatos para el crossover
				currentGen= Util.tournamentSelection(currentGen);
                Util.shuffle(currentGen);
                Chromosome[] newGen = new Chromosome[n];
				
				//Crossover
				for(int j=0; j<n; j+=2)
				{
					Chromosome[] offsprings= new Chromosome[2];
					offsprings= Util.crossover(currentGen[j], currentGen[j+1], Pc);
                    newGen[j] = offsprings[0];
                    newGen[j + 1] = offsprings[1];
				}
				
				//Mutacion
				for(int k=0; k< n; k++)
                {
                    newGen[k] = Util.mutate(newGen[k], Pm);
                    newGen[k].Fitness = Util.findFitness(newGen[k]);
                }
                
				generations[i]= newGen;
				currentGen= newGen;
                if (i > 2 && Util.findFitness(generations[i])<n)
                {
                    if (Util.findFitness(generations[i]) >= Util.findFitness(generations[i - 1]))
                        if (Util.findFitness(generations[i-1]) >= Util.findFitness(generations[i - 2]))
                                    exit = true;
                }
            }
			//Todas las generaciones
			Chromosome[] bestGeneration= new Chromosome[n];
			int bestFit=48*n;
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
            Console.WriteLine("**MEJOR GENERACION:**");
            foreach (Chromosome chr in bestGeneration)
            {
                Console.WriteLine("Reinas: " + chr.Solution + " Fitness: " + chr.Fitness);
            }
            Chromosome bestChr = Util.highestFit(bestGeneration);
            if (bestChr.Fitness != 0)
            {
                Console.WriteLine("No se encontró solución en "+gen+" generaciones...");
            }
            else
            {
                int[] sol = Util.translate(bestChr);
                Console.Write("Solucion: ");
                foreach(int num in sol)
                {
                    Console.Write(num+" ");
                }
                
            }
                
            Console.Read();
        }
    }
}
