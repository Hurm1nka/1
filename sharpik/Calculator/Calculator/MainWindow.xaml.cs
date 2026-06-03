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

namespace Calculator
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

        bool wait = false;
        double num1 = 0.0;
        double num2 = 0.0;
        double main, ram;

        string operand = "0";

        private void Calculate(object sender, RoutedEventArgs e)
        {
        
            string btn = ((Button)sender).Content.ToString();

            if("1234567890".Contains(btn))
            {
                if (wait == false)
                {
                    tbMain.Text += btn;
                }
                else
                {
                    tbMain.Text = btn;
                    wait = false;
                }
            }

            switch (btn)
            {
                case ",":
                    
                    if(!tbMain.Text.Contains(","))
                    {
                        tbMain.Text += ",";
                    }
                    break;

                case "+/-":

                    double val = Convert.ToDouble(tbMain.Text);
                    val = val * -1;
                    tbMain.Text = val.ToString();
                    ; break;

                case "<":
                    tbMain.Text = tbMain.Text.Remove(tbMain.Text.Length - 1);
                    break;

                case "C": tbMain.Text = ""; break;

                case "/":
                    num1 = Convert.ToDouble(tbMain.Text);  
                    wait = true;
                    operand = "/0";
                    break;

                case "*":
                    num1 = Convert.ToDouble(tbMain.Text);
                    wait = true;
                    tbMain.Text = "";
                    operand = "*0"; break;
                case "-":
                    if (tbMain.Text == "")
                    {
                        tbMain.Text = "-";
                    }
                    else
                    {
                        num1 = Convert.ToDouble(tbMain.Text);
                        wait = true;
                        tbMain.Text = "";
                        operand = "-0";
                    }
                    break;
                case "+":
                    num1 = Convert.ToDouble(tbMain.Text);
                    wait = true;
                    tbMain.Text = "";
                    operand = "+0"; break;

                case "=": switch (operand)
                    {
                        case "/0":
                            {
                                num2 = Convert.ToDouble(tbMain.Text);
                                if(num2 != 0)
                                {
                                    tbMain.Text = (num1 / num2).ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Ошибка. Деление на 0", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                wait = false;
                            }
                            break;
                        case "*0":
                            {
                                num2 = Convert.ToDouble(tbMain.Text);
                                tbMain.Text = (num1 * num2).ToString();
                                wait = false;
                            }
                            break;
                        case "-0":
                            {   
                                num2 = Convert.ToDouble(tbMain.Text);
                                tbMain.Text = (num1 - num2).ToString();
                                wait = false;
                            }
                            break;
                        case "+0":
                            {
                                num2 = Convert.ToDouble(tbMain.Text);
                                tbMain.Text = (num1 + num2).ToString();
                                wait = false;
                            }
                            break;
                        case "x^y0":
                            {
                                num2 = Convert.ToDouble(tbMain.Text);
                                tbMain.Text = Math.Pow(main, num2).ToString();
                                wait = false;
                            }
                            break;
                    }
                    break;

                case "M+":
                    main = Convert.ToDouble(tbMain.Text);
                    ram = Convert.ToDouble(tbRam.Text);
                    tbRam.Text = (ram + main).ToString();
                    break;
                case "M-":
                    main = Convert.ToDouble(tbMain.Text);
                    ram = Convert.ToDouble(tbRam.Text);
                    tbRam.Text = (ram - main).ToString();
                    break;
                case "MC":
                    ram = 0;
                    tbRam.Text = ram.ToString();
                    break;
                case "MR":
                    tbMain.Text = tbRam.Text;
                    break;

                case "Pi":
                    tbMain.Text = Math.PI.ToString();
                    break;
                case "x^2":
                    main = Convert.ToDouble(tbMain.Text);
                    tbMain.Text = Math.Pow(main, 2).ToString();
                    break;
                case "x^3":
                    main = Convert.ToDouble(tbMain.Text);
                    tbMain.Text = Math.Pow(main, 3).ToString();
                    break;
                case "x^y":
                    main = Convert.ToDouble(tbMain.Text);
                    operand = "x^y0"; 
                    wait = true;
                    tbMain.Text = "";
                    break;
                case "cos":
                    main = Convert.ToDouble(tbMain.Text);
                    tbMain.Text = Math.Cos(main).ToString();
                    break;
                case "ln":
                    main = Convert.ToDouble(tbMain.Text);
                    tbMain.Text = Math.Log(main).ToString();
                    break;
                case "n!":
                    main = Convert.ToDouble(tbMain.Text);
                    int fact = 1;
                    for (int i = 1; i <= (int)main; i++)
                    {
                        fact *= i;
                    }
                    tbMain.Text = fact.ToString();
                    break;
                case "exp":
                    main = Convert.ToDouble(tbMain.Text);
                    tbMain.Text = Math.Exp(main).ToString();
                    break;
                case "1/x":
                    main = Convert.ToDouble(tbMain.Text);
                    tbMain.Text = (1/main).ToString();
                    break;
                case "tg":
                    main = Convert.ToDouble(tbMain.Text);
                    tbMain.Text = Math.Tan(main).ToString();
                    break;
                case "sqrt":
                    main = Convert.ToDouble(tbMain.Text);
                    tbMain.Text = Math.Sqrt(main).ToString();
                    break;

            }

        }
    }
}
