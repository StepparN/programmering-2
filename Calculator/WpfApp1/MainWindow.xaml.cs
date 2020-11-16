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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_click(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                switch (button.Content)
                {
                    case "0":
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                        Numbers.Text += button.Content;
                        break;
                    default:
                        break;
                }
            }
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

        }
        private void Button_Subtraction(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Division(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Multiplication(object sender, RoutedEventArgs e)
        {

        }

    }
}
