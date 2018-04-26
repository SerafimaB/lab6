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

        //проверка что все мины имеют свободную клетку рядом
        bool minesCheck()
        {
            //считаем что все имеют
            bool res = true;


            //перебираем всё поле
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    //если нашли мину
                    if (field[i, j] == -1)
                    {
                        //определяем область 3х3 для проверки соседних клеток
                        int sx = i - 1;
                        int sy = j - 1;
                        int ex = i + 1;
                        int ey = j + 1;
                        //если вышли за пределы поля
                        if (sx < 0) sx = 0;
                        if (sy < 0) sy = 0;
                        if (ex >= field.GetLength(0)) ex = field.GetLength(0) - 1;
                        if (ey >= field.GetLength(1)) ey = field.GetLength(1) - 1;

                        //считаем что свободных клеток нет
                        bool reroll = true;
                        //проверяем область 3х3 вокруг мины
                        for (int i1 = sx; i1 <= ex; i1++)
                            for (int j1 = sy; j1 <= ey; j1++)
                            {
                                //если нашли свободную клетку
                                if (field[i1, j1] == 0)
                                    reroll = false;
                            }
                        //если не нашли свободных клеток
                        if (reroll == true)
                        {
                            //проверка не пройдена
                            res = false;
                            //прекращаем все циклы
                            break;
                        }
                    }
                }
                if (res == false) break;
            }

            return res;
        }

        //размещение мин
        public void plantMines(int min, int max)
        {
            Random rand = new Random();

            int value = rand.Next(min, max);

            for (int i = 0; i < value; i++)
            {
                int x = rand.Next(0, field.GetLength(0));
                int y = rand.Next(0, field.GetLength(1));

                //если в этой клетке уже была мина, перебрасываем координаты для мины
                if (field[x, y] == -1)
                {
                    i--;
                    continue;
                }
                else
                    field[x, y] = -1;



                //проверка что при добавлении новой мины, старые мины всё ещё имеют свободную клетку рядом
                bool success = minesCheck();


                //если не прошли проверку, перебрасываем координаты для мины
                if (success == false)
                {
                    field[x, y] = 0;
                    i--;
                }


            }



        }

        public void calculate()
        {
            //перебираем все клетки
            for (int i = 0; i < field.GetLength(0); i++)
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    //если клетка пуста
                    if (field[i, j] == 0)
                    {
                        //определяем окно вокруг пустой клетки 3х3
                        int sx = i - 1;
                        int sy = j - 1;
                        int ex = i + 1;
                        int ey = j + 1;
                        //если окно 3х3 вышло за поле
                        if (sx < 0) sx = 0;
                        if (sy < 0) sy = 0;
                        if (ex >= field.GetLength(0)) ex = field.GetLength(0) - 1;
                        if (ey >= field.GetLength(1)) ey = field.GetLength(1) - 1;

                        //сумма мин вокруг текущей клетки
                        int sum = 0;
                        //перебираем соседние клетки
                        for (int i1 = sx; i1 <= ex; i1++)
                            for (int j1 = sy; j1 <= ey; j1++)
                            {
                                //если нашли мину, увеличиваем сумму мин
                                if (field[i1, j1] == -1)
                                    sum++;
                            }
                        //записываем в ячейку количество мин в соседних клетках
                        field[i, j] = sum;
                    }

                }
        }
    }
}
