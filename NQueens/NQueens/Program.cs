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
            String[] cosa = Util.initPopulation();
            Console.WriteLine(cosa[1]);
            Console.WriteLine(Util.Mutate(cosa[1], 100));
            Console.Read();
        }
    }
}
