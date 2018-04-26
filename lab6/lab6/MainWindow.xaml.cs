using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        BitmapImage mine = new BitmapImage(new Uri(@"pack://application:,,,/img/bomb.png", UriKind.Absolute));

        generator gen = new generator();

        public MainWindow()
        {
            InitializeComponent();


        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            //получение значения лежащего в Tag
            int n = (int)((Button)sender).Tag; 

            //установка фона нажатой кнопки, цвета и размера шрифта
            ((Button)sender).Background = Brushes.MistyRose;

            int num = gen.getCell(n % 5, n / 5);

            if (num >= 0)
            {
                ((Button)sender).Foreground = Brushes.MidnightBlue;
                ((Button)sender).FontSize = 23;
                //запись в нажатую кнопку её номера
                ((Button)sender).Content = num;
            }
            if (num == -1)
            {
                StackPanel minePnl;
                //создание и инициализация переменной для хранения изображения мины
                Image img = new Image();
                //загрузка изображения mine.jpg из папки imgs
                img.Source = mine;

                //инициализация и установка ориентации, можно вызвать в методе инициализации формы
                minePnl = new StackPanel();
                minePnl.Orientation = Orientation.Horizontal;
                //установка толщины границы объекта
                minePnl.Margin = new Thickness(1);
                //добавление в объект изображения
                minePnl.Children.Add(img);

                ((Button)sender).Content = minePnl;
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sp.Children.Clear();
           //генерация поля
            gen.init(5);
            gen.plantMines(7, 10);
            gen.calculate();

            //количество ячеек в сетке
            sp.Rows = 5;
            sp.Columns = 5;
            //вычисление размеров сетки число_ячеек * (размер ячейки + толщина границы)
            sp.Width = 5 * (50 + 4);
            sp.Height = 5 * (50 + 4);
            sp.Margin = new Thickness(5, 5, 5, 5);
            //размеры окна
            this.Width = 5 * 70;
            this.Height = 6 * 70;
            //добавление кнопок в сетку
            for (int i = 0; i < 5 * 5; i++)
            {
                //создание кнопки
                Button btn = new Button();
                //запись номера кнопки
                btn.Tag = i;
                //установка размеров кнопки
                btn.Width = 50;
                btn.Height = 50;
                //текст на кнопке
                btn.Content = " ";
                //толщина границ кнопки
                btn.Margin = new Thickness(2);
                //при нажатии кнопки, будет вызываться метод Btn_Click
                btn.Click += Btn_Click; ;
                //добавление кнопки в сетку
                sp.Children.Add(btn);
            }
           
           
      
        }
    }
}
