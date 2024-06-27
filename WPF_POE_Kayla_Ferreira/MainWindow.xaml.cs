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
    /// Kayla Ferreira - ST10259527
    /// References: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/get-started/create-app-visual-studio?view=netdesktop-8.0
    /// https://www.youtube.com/watch?v=gSfMNjWNoX0
    /// https://www.tutorialspoint.com/wpf/index.htm
    /// PROG6221 - Assignment 3
    /// </summary>
    
    public partial class MainWindow : Window
    {
        //-----------------------------------------------------------------------------------------------
        // Constructor
        //-----------------------------------------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Event handlers
        //-----------------------------------------------------------------------------------------------
        private void New_Recipe_Copy_Click(object sender, RoutedEventArgs e)
        {
            Window1 newWindow1 = new Window1();
            newWindow1.Show();
        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Event handlers
        //-----------------------------------------------------------------------------------------------
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
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Event handlers
        //-----------------------------------------------------------------------------------------------
        private void New_Recipe_Copy2_Click(object sender, RoutedEventArgs e)
        {
            Search newSearch = new Search();
            newSearch.Show();
        }
        //-----------------------------------------------------------------------------------------------
    }
    //-----------------------------------------------------------------------------------------------
}
//--------------------------------------End-of-File-------------------------------------------------------
