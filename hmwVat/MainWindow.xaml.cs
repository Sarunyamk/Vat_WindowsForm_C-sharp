using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using static System.Net.Mime.MediaTypeNames;

namespace hmwVat
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

        private void btnCal_Click(object sender, RoutedEventArgs e)
        {
            if(RdOut.IsChecked == false && RdIn.IsChecked == false) 
            {
                MessageBox.Show("กรุณาเลือกVat");
                return;
            }
            if(txtPrice.Text.Trim().Length == 0 ) 
            {
                MessageBox.Show("กรุณากรอกรายละเอียด");
                return;
            }
             if (RdOut.IsChecked == true) 
            {
                if (MessageBox.Show("ต้องการคำนวณหรือไม่","ยืนยัน",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                { 
                    Summaryout();                   
                }
                else 
                {
                    Clear();
                }
            }

            else
            {
                if (MessageBox.Show("ต้องการคำนวณหรือไม่", "ยืนยัน", MessageBoxButton.YesNo) == MessageBoxResult.Yes) 
                {
                    Summaryin();
                    
                }
                else
                {
                    Clear();
                }
            }


        }
        private double Summaryout () 
        {
            Double P = double.Parse(txtPrice.Text);
            txtService.Text = P.ToString("N");
            Double V = P * 7 / 100;
            txtVat.Text = V.ToString("N");
            Double S = P + V;
            txtSum.Text = S.ToString("N");
            return S;
                          
        }
        private double Summaryin ()
        {
            Double P = double.Parse(txtPrice.Text);
            Double V = P * 7 / 107;
            txtVat.Text = V.ToString("N");
            Double E = P - V;
            txtService.Text = E.ToString("N");
            Double S = V+E;
            txtSum.Text = S.ToString("N");
            return S;


        }
        private void Clear()
        {
            txtPrice.Text = "";
            txtService.Text = "";
            txtVat.Text = "";
            txtSum.Text = "";
        }




        private void txtPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
