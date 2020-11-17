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
            Numbers.Text = String.Empty;
        }
        private void Button_Calculate(object sender, RoutedEventArgs e)
        {
            
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
            input += "0";
        }
        private void one_Click(object sender, RoutedEventArgs e)
        {
            input += "1";
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            input += "2";
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            input += "3";
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            input += "4";
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            input += "5";
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            input += "6";
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            input += "7";
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            input += "8";
        }

        private void nince_Click(object sender, RoutedEventArgs e)
        {
            input += "9";
        }
    }
}
