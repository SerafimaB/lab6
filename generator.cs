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

        public int getCell(int i, int j)
        {
            return field[i, j];
        }

        bool minesCheck()
        {
            bool res = true;

           

            for (int i = 0; i < field.GetLength(0); i++)
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == -1)
                    {
                        int sx = i - 1;
                        int sy = j - 1;
                        int ex = i + 1;
                        int ey = j + 1;

                        if (sx < 0) sx = 0;
                        if (sy < 0) sy = 0;
                        if (ex >= field.GetLength(0)) ex = field.GetLength(0) - 1;
                        if (ey >= field.GetLength(1)) ey = field.GetLength(1) - 1;

                        bool reroll = true;

                        for (int i1 = sx; i1 <= ex; i1++)
                            for (int j1 = sy; j1 <= ey; j1++)
                            {
                                if (field[i1, j1] == 0)
                                    reroll = false;
                            }

                        if (reroll == true)
                        {
                            res = false;
                            break;
                        }
                    }
                }

            return res;
        }

        public void plantMines(int min, int max)
        {
            Random rand = new Random();

            int value = rand.Next(min, max);

            for (int i = 0; i < value; i++)
            {
                int x = rand.Next(0, field.GetLength(0));
                int y = rand.Next(0, field.GetLength(1));

                if (field[x, y] == -1)
                {
                    i--;
                    continue;
                }
                else
                    field[x, y] = -1;




                bool success = minesCheck();



                if (success == false)
                {
                    field[x, y] = 0;
                    i--;
                }


            }



        }

        public void calculate()
        {
            for (int i = 0; i < field.GetLength(0); i++)
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 0)
                    {
                        int sx = i - 1;
                        int sy = j - 1;
                        int ex = i + 1;
                        int ey = j + 1;

                        if (sx < 0) sx = 0;
                        if (sy < 0) sy = 0;
                        if (ex >= field.GetLength(0)) ex = field.GetLength(0) - 1;
                        if (ey >= field.GetLength(1)) ey = field.GetLength(1) - 1;

                        int sum = 0;

                        for (int i1 = sx; i1 <= ex; i1++)
                            for (int j1 = sy; j1 <= ey; j1++)
                            {
                                if (field[i1, j1] == -1)
                                    sum++;
                            }
                        field[i, j] = sum;
                    }

                }
        }
    }
}
