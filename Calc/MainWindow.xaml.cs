using System;
using System.Data;
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

namespace Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement element in MainGlobal.Children)
            {
                if(element is Button)
                {
                    ((Button)element).Click += BurronClick;
                }
            }
        }

        private void BurronClick(object sender, RoutedEventArgs e)
        {
            string ButtonContent = (string)((Button)e.OriginalSource).Content;
            if (ButtonContent == "CE")
            {
                CalculatorLabel.Text = "";
            }
            else if(CalculatorLabel.Text == "" && ButtonContent =="0")
            {
                CalculatorLabel.Text = "";
            }
            else if (ButtonContent == "=")
            {
                string? result = new DataTable().Compute(CalculatorLabel.Text, null).ToString();
                CalculatorLabel.Text = result;
            }
            else
            { 
                CalculatorLabel.Text += ButtonContent;
            }
        }
    }
}
