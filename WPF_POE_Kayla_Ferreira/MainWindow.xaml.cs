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

namespace WPF_POE_Kayla_Ferreira
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

        private void New_Recipe_Copy_Click(object sender, RoutedEventArgs e)
        {
            Window1 newWindow1 = new Window1();
            newWindow1.Show();
        }

        private void New_Recipe_Copy1_Click(object sender, RoutedEventArgs e)
        {
            if (Window1.AllRecipes.Count > 0)
            {
                Window2 window2 = new Window2(Window1.AllRecipes);
                window2.Show();
            }
            else
            {
                MessageBox.Show("No recipes have been created yet!");
            }
    }

        private void New_Recipe_Copy2_Click(object sender, RoutedEventArgs e)
        {
            Window1 newWindow2 = new Window1();
        }
    }
}
