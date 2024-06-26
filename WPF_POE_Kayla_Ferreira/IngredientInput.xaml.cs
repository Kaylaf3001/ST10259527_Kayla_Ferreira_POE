using ST10259527_Kayla_Ferreira_POE.Class;
using System.Windows;
using System.Windows.Controls;

namespace WPF_POE_Kayla_Ferreira
{
    //-----------------------------------------------------------------------------------------------
    public partial class IngredientWindow : Window
    {

        public Ingredients Ingredient { get; private set; }

        //-----------------------------------------------------------------------------------------------
        // Constructor
        //-----------------------------------------------------------------------------------------------
        public IngredientWindow(int ingredientNumber)
        {
            InitializeComponent();
            Title = $"Add Ingredient {ingredientNumber}";
        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Event handlers
        //-----------------------------------------------------------------------------------------------
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            double quantity, calories;
            if (double.TryParse(QuantityTextBox.Text, out quantity) && double.TryParse(CaloriesTextBox.Text, out calories))
            {
                Ingredient = new Ingredients
                {
                    ingredientName = IngredientNameTextBox.Text,
                    ingredientQuantity = quantity,
                    originalQuantity = quantity,
                    unitOfMeasurement = ((ComboBoxItem)UnitComboBox.SelectedItem)?.Content.ToString(),
                    calories = calories,
                    foodGroup = ((ComboBoxItem)FoodGroupComboBox.SelectedItem)?.Content.ToString()
                };
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please enter valid values for quantity and calories.");
            }
        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Event handlers
        //-----------------------------------------------------------------------------------------------
        private void FoodGroupComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected ComboBoxItem
            ComboBoxItem selectedComboBoxItem = (ComboBoxItem)FoodGroupComboBox.SelectedItem;

            // Check if an item is selected
            if (selectedComboBoxItem != null)
            {
                // Get the content of the selected item (e.g., the food group)
                string selectedFoodGroup = selectedComboBoxItem.Content.ToString();

                // Perform actions based on the selected food group
                switch (selectedFoodGroup)
                {
                    case "Fruits":
                        // Handle selection of "Fruits"
                        break;
                    case "Vegetables":
                        // Handle selection of "Vegetables"
                        break;
                    case "Grains":
                        // Handle selection of "Grains"
                        break;
                    case "Protein":
                        //Handle selection "Protein"
                        break;
                    case "Dairy":
                        // Handle selection of "Dairy"
                        break;
                    case "Fats and Oils":
                        // Handle selection of "Fats and Oils"
                        break; 

                    // Add cases for other food groups as needed
                    default:
                        // Handle default case
                        break;
                }
            }
        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Event handlers
        //-----------------------------------------------------------------------------------------------
        private void UnitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Event handlers
        //-----------------------------------------------------------------------------------------------
        private void CaloriesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        //-----------------------------------------------------------------------------------------------
    }
    //-----------------------------------------------------------------------------------------------
}
//--------------------------------------End-of-File-------------------------------------------------------

