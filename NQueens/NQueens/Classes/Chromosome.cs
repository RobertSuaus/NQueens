using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens.Classes
{
    class Chromosome
    {
        private String solution;
        private int fitness;

        public String Solution
        {
            get
            {
                return solution;
            }
            set
            {
                solution = value;
            }
        }

        public int Fitness
        {
            get
            {
                return fitness;
            }
            set
            {
                fitness = value;
            }
        }
        
    }
}
