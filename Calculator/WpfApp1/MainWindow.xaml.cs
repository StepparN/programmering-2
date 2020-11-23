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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string input = string.Empty;
        string tal1 = string.Empty;
        string tal2 = string.Empty;
        char operation;
        double result = 0.0;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            this.Numbers.Text = "";
            this.input = string.Empty;
            this.tal1 = string.Empty;
            this.tal2 = string.Empty;
        }
        private void Button_Calculate(object sender, RoutedEventArgs e)
        {
            tal2 = input;
            double num1, num2;
            double.TryParse(tal1, out num1);
            double.TryParse(tal2, out num2);

            if (operation == '+')
            {
                result = num1 + num2;
                Numbers.Text = result.ToString();
            }
            else if (operation == '-')
            {
                result = num1 - num2;
                Numbers.Text = result.ToString();
            }
            else if (operation == 'x')
            {
                result = num1 * num2;
                Numbers.Text = result.ToString();
            }
            else if (operation == '/')
            {
                if (num2 != 0)
                {
                    result = num1 / num2;
                    Numbers.Text = result.ToString();
                }
                else
                {
                    Numbers.Text = "DIV/Zero";
                }
            }
        }
        private void Button_Addition(object sender, RoutedEventArgs e)
        {
            tal1 = input;
            operation = '+';
            input = string.Empty;
        }
        private void Button_Subtraction(object sender, RoutedEventArgs e)   
        {
            tal1 = input;
            operation = '-';
            input = string.Empty;
        }
        private void Button_Division(object sender, RoutedEventArgs e)
        {
            tal1 = input;
            operation = '/';
            input = string.Empty;
        }
        private void Button_Multiplication(object sender, RoutedEventArgs e)
        {
            tal1 = input;
            operation = 'x';
            input = string.Empty;
        }
        private void zero_Click(object sender, RoutedEventArgs e)
        {
            this.Numbers.Text = "";
            input += "0";
            this.Numbers.Text += input;
        }
        private void one_Click(object sender, RoutedEventArgs e)
        {
            this.Numbers.Text = "";
            input += "1";
            this.Numbers.Text += input;
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            this.Numbers.Text = "";
            input += "2";
            this.Numbers.Text += input;
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            this.Numbers.Text = "";
            input += "3";
            this.Numbers.Text += input;
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            this.Numbers.Text = "";
            input += "4";
            this.Numbers.Text += input;
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            this.Numbers.Text = "";
            input += "5";
            this.Numbers.Text += input;
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            this.Numbers.Text = "";
            input += "6";
            this.Numbers.Text += input;
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            this.Numbers.Text = "";
            input += "7";
            this.Numbers.Text += input;
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            this.Numbers.Text = "";
            input += "8";
            this.Numbers.Text += input;
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            this.Numbers.Text = "";
            input += "9";
            this.Numbers.Text += input;
        }
    }
}
