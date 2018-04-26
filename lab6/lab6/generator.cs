using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class generator
    {
        public int[,] field;

        public void init(int n)
        {
            field = new int[n, n];
        }

        public void plantMines(int y)
        {
            Random rand = new Random();
            for (int i = 0; i < y; i++)
            {
                field[rand.Next(0, field.GetLength(0)), rand.Next(0, field.GetLength(1))] = 1;
            }
        }

        public void calculate()
        {

        }
        
    }
}
