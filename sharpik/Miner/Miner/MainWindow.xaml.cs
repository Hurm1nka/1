using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;


namespace Miner
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        int countMines;
        int time;
        int boomTime = 2;
        bool show;

        int corX = 0;
        int corY = 0;
        int Distance = 0;
        int totalMines = 0;

        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();

        BitmapImage mineImg = new BitmapImage(new Uri(System.IO.Path.GetFullPath("../../Resources/mina.png")));
        BitmapImage boomImg = new BitmapImage(new Uri(System.IO.Path.GetFullPath("../../Resources/boom.png")));

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {

            if ((tbxSetTime.Text == "" || tbxSetCountMine.Text == ""))
            {
                MessageBox.Show("Поля не заполнены", "Ошибка заполнения полей", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(tbxSetCountMine.Text, out countMines) || !int.TryParse(tbxSetTime.Text, out time))
            {
                MessageBox.Show("Количество мин или время не может буквами", "Ошибка заполнения полей", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (time > 0 || countMines > 0)
            {
                cnDisplay.Visibility = Visibility.Visible;
            }
            else { MessageBox.Show("Количество мин или время не может отрицательными или 0", "Ошибка заполнения полей", MessageBoxButton.OK, MessageBoxImage.Error); }
                

                


             time *= 60;
           
             timer.Stop();
             timer.Tick -= Timer_Tick;
             timer.Interval = TimeSpan.FromSeconds(1);    

             timer.Tick += Timer_Tick;
             timer.Start();

             Game();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time--;
            tbxTime.Text = $"{time / 60}:{time % 60:D2}";
            if (time <= 0)
            {
                timer.Stop();
                MessageBox.Show("Время вышло. Победил компьютер", "Время", MessageBoxButton.OK, MessageBoxImage.Information);
                tbxSetCountMine.Text = "";
                tbxSetTime.Text = "";

            }
        }

        private void Game()
        {   
            imgMine.Source = mineImg;
            imgMine.Visibility = Visibility.Hidden;
            Random rnd = new Random();
            Canvas.SetLeft(imgMine, rnd.Next(0, (int)cnDisplay.ActualWidth - (int)imgMine.ActualWidth));
            Canvas.SetTop(imgMine, rnd.Next(0, (int)cnDisplay.ActualHeight - (int)imgMine.ActualHeight));
            boomTime = 2;
            show = false;
        }

        private void cnDisplay_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(cnDisplay);

            tbxX.Text = mousePos.X.ToString();
            tbxY.Text = mousePos.Y.ToString();


            double centerX = Canvas.GetLeft(imgMine) + imgMine.ActualWidth / 2;
            double centerY = Canvas.GetTop(imgMine) + imgMine.ActualHeight / 2;

            double dist = Math.Sqrt(Math.Pow(mousePos.X - centerX, 2) + Math.Pow(mousePos.Y - centerY, 2));

            tbxDistance.Text = ((int)dist).ToString();

            
                if (dist < imgMine.ActualWidth / 2)
                {
                    imgMine.Visibility = Visibility.Visible;
                }
                else
                {
                    if (show == false)
                    {
                        imgMine.Visibility = Visibility.Hidden;
                    }
                }
            
        }

        private void imgMine_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            timer2.Stop();
            timer2.Tick -= Timer_Tick2;
            timer2.Interval = TimeSpan.FromSeconds(1);
            timer2.Tick += Timer_Tick2;
            timer2.Start();
            show = true;
            imgMine.Source = boomImg;
            imgMine.Visibility = Visibility.Visible;

        }


        private void Timer_Tick2(object sender, EventArgs e)
        {
            boomTime--;
            if (boomTime == 0)
            {
                countMines--;
                tbxCountMine.Text = countMines.ToString();
                Game();
                if (countMines <= 0)
                {
                    MessageBox.Show("Победил человек");
                    tbxSetCountMine.Text = "";
                    tbxSetTime.Text = "";
                    cnDisplay.Visibility = Visibility.Collapsed;
                    timer.Stop();
                }
                timer2.Stop();
            }
        }
    }
}
