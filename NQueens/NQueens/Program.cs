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
            //Almacenar numeros en binario en un string
            String solucion="";
            int[] n = { 5 , 4, 2, 6, 5, 2, 1, 2};
            foreach (int number in n)
            {
                solucion += Convert.ToString(number, 2);
            }
            Console.WriteLine( solucion);
            int output = Convert.ToInt32(solucion, 2);
            Console.WriteLine(output);
        }
    }
}
