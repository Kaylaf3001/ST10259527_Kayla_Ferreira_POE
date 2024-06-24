using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPF_POE_Kayla_Ferreira
{
    public partial class Search : Window
    {
        private List<Window1.Recipe> _allRecipes;

        public Search()
        {
            InitializeComponent();
            _allRecipes = Window1.AllRecipes;
            UpdateRecipeList();
        }

        private void Search_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateRecipeList(); // Now called when the window is fully loaded
        }

        private void TextBox_Search(object sender, TextChangedEventArgs e)
        {
            UpdateRecipeList();
        }

        private void CheckBox_Fruits(object sender, RoutedEventArgs e)
        {
            UpdateRecipeList();
        }

        private void CheckBox_Vegetables(object sender, RoutedEventArgs e)
        {
            UpdateRecipeList();
        }

        private void CheckBox_Grains(object sender, RoutedEventArgs e)
        {
            UpdateRecipeList();
        }

        private void CheckBox_Protein(object sender, RoutedEventArgs e)
        {
            UpdateRecipeList();
        }

        private void CheckBox_Dairy(object sender, RoutedEventArgs e)
        {
            UpdateRecipeList();
        }

        private void CheckBox_FatsAndOils(object sender, RoutedEventArgs e)
        {
            UpdateRecipeList();
        }

        private void Slider_Calories(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateRecipeList();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                var selectedRecipeName = RecipeListBox.SelectedItem.ToString();
                var selectedRecipe = _allRecipes.FirstOrDefault(r => r.Name == selectedRecipeName);
                if (selectedRecipe != null)
                {
                    var viewRecipeWindow = new Window2(_allRecipes);
                    viewRecipeWindow.Show();
                }
            }
        }

        private List<string> GetFilteredRecipeNames()
        {
            var filteredRecipes = new List<string>();
            var searchQuery = SearchTextBox.Text.ToLower();
            var foodGroups = new List<string>();
            if (FruitsCheckBox.IsChecked == true) foodGroups.Add("Fruits");
            if (VegetablesCheckBox.IsChecked == true) foodGroups.Add("Vegetables");
            if (GrainsCheckBox.IsChecked == true) foodGroups.Add("Grains");
            if (ProteinCheckBox.IsChecked == true) foodGroups.Add("Protein");
            if (DairyCheckBox.IsChecked == true) foodGroups.Add("Dairy");
            if (FatsAndOilsCheckBox.IsChecked == true) foodGroups.Add("Fats and Oils");
            var maxCalories = (int)CaloriesSlider.Value;

            foreach (var recipe in _allRecipes)
            {
                if (recipe.Name.ToLower().Contains(searchQuery) &&
                    (foodGroups.Count == 0 || foodGroups.Any(fg => recipe.Ingredients.Any(ing => ing.FoodGroup == fg))) &&
                    recipe.Ingredients.Sum(i => i.Calories) <= maxCalories)
                {
                    filteredRecipes.Add(recipe.Name);
                }
            }

            return filteredRecipes;
        }

        private void UpdateRecipeList()
        {
            RecipeListBox.Items.Clear();
            var filteredRecipeNames = GetFilteredRecipeNames();
            foreach (var name in filteredRecipeNames)
            {
                RecipeListBox.Items.Add(name);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateRecipeList();
        }
    }
}
