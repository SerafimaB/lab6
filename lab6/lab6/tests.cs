using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace lab6
{
    [TestFixture]
    class tests
    {
        [TestCase]
        public void mine_check()
        {
            generator gen = new generator();

            gen.field = new int[,]
            {
                { -1, -1,  0,  0,  0},
                { -1, -1,  0,  0,  0},
                {  0,  0,  0,  0,  0},
                {  0,  0,  0,  0,  0},
                {  0,  0,  0,  0,  0}
            };

            Assert.AreEqual(false, gen.minesCheck());

            gen.field = new int[,]
            {
                {  0,  0,  0,  0,  0},
                {  0, -1, -1, -1,  0},
                {  0, -1, -1, -1,  0},
                {  0, -1, -1, -1,  0},
                {  0,  0,  0,  0,  0}
            };

            Assert.AreEqual(false, gen.minesCheck());

            gen.field = new int[,]
            {
                {  0,  0,  0,  0,  0},
                {  0, -1, -1, -1,  0},
                {  0, -1,  0, -1,  0},
                {  0, -1, -1, -1,  0},
                {  0,  0,  0,  0,  0}
            };

            Assert.AreEqual(true, gen.minesCheck());
        }

        [TestCase]
        public void plant_mines()
        {
            generator gen = new generator();
            gen.init(5);
            gen.plantMines(5, 5);

            int sum = 0;
            for (int i = 0; i < gen.field.GetLength(0); i++)
                for (int j = 0; j < gen.field.GetLength(1); j++)
                    if (gen.getCell(i, j) == -1)
                        sum++;

            Assert.AreEqual(5, sum);

            Assert.AreEqual(true, gen.minesCheck());

            //Assert.AreEqual(, gen.plantMines(250));



        }

        [TestCase]
        public void ostatok()
        {
            //создание объекта, содержащего функцию
            generator gen = new generator();

            //получение исключения
            var ex = Assert.Throws<ArgumentException>(() => gen.ostatok(2, 0));
            //сравнение полученного сообщения с ожидаемым
            Assert.That(ex.Message, Is.EqualTo("Делитель должен быть >= 0"));

            //проверка выполняется успешно, если исключение не было сгенерировано
            Assert.DoesNotThrow(() => gen.ostatok(2, 1));
        }

        [TestCase]
        public void Chet()
        {
            //создание объекта, содержащего функцию
            generator gen = new generator();
            //проверка возвращаемого значения, в первом случае оно должно быть истинно
            //во втором ложно
            Assert.IsTrue(gen.chet(4));
            Assert.IsFalse(gen.chet(5));
        }

        [TestCase]
        public void opennuli()
        {
            generator gen = new generator();

            gen.field = new int[,]
           {
                {  2,  3,  2,  1,  0},
                { -1, -1, -1,  1,  0},
                {  3,  4,  3,  1,  0},
                {  1, -1,  1,  0,  0},
                {  1,  1,  1,  0,  0}
           };

           // gen.calculate();

            gen.opennuli(4, 4);
            Assert.AreEqual(10, gen.field[0, 4]);
            Assert.AreEqual(10, gen.field[3, 3]);
            Assert.AreEqual(10, gen.field[3, 3]);
            Assert.AreEqual(1, gen.field[2, 3]);
            Assert.AreEqual(3, gen.field[2, 2]);
        }
    

        [TestCase]
        public void calculate()
        {
            generator gen = new generator();

            gen.field = new int[,]
            {
                    {  0, -1, -1, -1,  0},
                    {  0, -1,  0, -1,  0},
                    {  0, -1, -1, -1,  0},
                    {  0,  0,  0,  0,  0},
                    {  0,  0,  0,  0,  0}
            };

            gen.calculate();

            Assert.AreEqual(8, gen.field[1, 2]);
            Assert.AreEqual(2, gen.field[0, 0]);
            Assert.AreEqual(3, gen.field[1, 0]);
            Assert.AreEqual(1, gen.field[3, 0]);
            Assert.AreEqual(0, gen.field[4, 0]);

            gen.field = new int[,]
            {
                    {  0, -1, -1, -1,  0},
                    {  0, -1,  0, -1,  0},
                    {  0,  0,  0, -1,  0},
                    {  0,  0,  0, -1, -1},
                    {  0,  0,  0,  0,  0}
            };
            gen.calculate();

            Assert.AreEqual(6, gen.field[1, 2]);
            Assert.AreEqual(4, gen.field[2, 4]);

            gen.field = new int[,]
                  {
                    {  0,  0, -1, -1,  0},
                    {  0, -1,  0, -1,  0},
                    {  0, -1, -1, -1,  0},
                    {  0,  0,  0,  0,  0},
                    {  0, -1,  0, -1,  0}
                  };
            gen.calculate();

            Assert.AreEqual(7, gen.field[1, 2]);
            Assert.AreEqual(5, gen.field[3, 2]);


        }
    }

}

