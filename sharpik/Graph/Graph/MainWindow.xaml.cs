using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Graph
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

        double num1, num2, num3, num4;

        private void TryParseFunc()
        {
            if(!double.TryParse(tbxNum1.Text, out num1) 
                || !double.TryParse(tbxNum2.Text, out num2)
                || !double.TryParse(tbxNum3.Text, out num3)
                || !double.TryParse(tbxNum4.Text, out num4))
            {
                MessageBox.Show("Введите числа для функции", "Неккоректный ввод входных значений для функции", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }

        private void btnGraph_Click(object sender, RoutedEventArgs e)
        {



            double a, b, step;

            TryParseFunc();

            if (!double.TryParse(tbxA.Text.Replace(".",","), out a) 
                || !double.TryParse(tbxB.Text.Replace(".",","), out b) 
                || !double.TryParse(tbxH.Text.Replace(".",","), out step)) 
            {
                MessageBox.Show("Введите числа", "Неккоректный ввод входных значений", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (a > b)
            {
                MessageBox.Show("левая граница отрезка a должна быть меньше правой границы b", "Неккоректный ввод входных значений", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (step <= 0)
            {
                MessageBox.Show("Шаг аргумента должен быть положительным числом", "Неккоректный ввод входных значений", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Legends.Clear();

           

            //добавление области
            var area = new ChartArea();
            chart.ChartAreas.Add(area);

            var series0 = new Series("y=k1*sin(k2*x+k3)+k4");
            series0.ChartType = SeriesChartType.Line;
            series0.BorderWidth = 2;

            //добавлении серии
            var series1 = new Series("y1=sin(x)");
            
            //настройки серии
            series1.ChartType = SeriesChartType.Line;
            series1.BorderWidth = 2;

            var series2 = new Series("y2=cos(x)");
            series2.ChartType = SeriesChartType.Line;
            series2.BorderWidth = 2;

            var series3 = new Series("y3=sin(x)+cos(x)");
            series3.ChartType = SeriesChartType.Line;
            series3.BorderWidth = 2;

            var legend = new Legend();
            chart.Legends.Add(legend);

            var tableData = new List<TableRow>();

            for (double x = a; x <= b; x += step)
            {

                double y0 = num1 * Math.Sin(num2 * x + num3) + num4,
                       y1 = Math.Sin(x),
                       y2 = Math.Cos(x),
                       y3 = Math.Sin(x) + Math.Cos(x);

                series0.Points.AddXY(Math.Round(x, 2), Math.Round(y0, 4));
                series1.Points.AddXY(Math.Round(x, 2), Math.Round(y1, 4));
                series2.Points.AddXY(Math.Round(x, 2), Math.Round(y2, 4));
                series3.Points.AddXY(Math.Round(x, 2), Math.Round(y3, 4));


                tableData.Add(new TableRow
                {
                    X = Math.Round(x, 2).ToString(),
                    Y1 = Math.Round(y1, 4).ToString(),
                    Y2 =  Math.Round(y2, 4).ToString(),
                    Y3 = Math.Round(y3, 4).ToString()
                });
            }


            chart.Series.Add(series0);

            table.ItemsSource = tableData;

            if(cbxY1.IsChecked == true)
            {
                chart.Series.Add(series1);
            }
            else
            {
                chart.Series.Remove(series1);
            }

            if (cbxY2.IsChecked == true)
            {
                chart.Series.Add(series2);
            }
            else
            {
                chart.Series.Remove(series2);
            }

            if (cbxY3.IsChecked == true)
            {
                chart.Series.Add(series3);
            }
            else
            {
                chart.Series.Remove(series3);
            }
        }

     }
}

