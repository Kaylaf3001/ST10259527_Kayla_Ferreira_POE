using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ST10259527_Kayla_Ferreira_POE.Class;

namespace WPF_POE_Kayla_Ferreira
{
    public partial class Search : Window
    {
        private List<Recipes> _allRecipes;

        public Search()
        {
            InitializeComponent();
            this.Loaded += Search_Loaded;
        }

        private void Search_Loaded(object sender, RoutedEventArgs e)
        {
            _allRecipes = Window1.AllRecipes ?? new List<Recipes>();
        }

        //=======================================================================================================
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
        //=======================================================================================================

        //=======================================================================================================
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecipeListBox != null && RecipeListBox.SelectedItem != null)
            {
                var selectedRecipeName = RecipeListBox.SelectedItem.ToString();
                var selectedRecipe = _allRecipes.FirstOrDefault(r => r.receipeName == selectedRecipeName);

                if (selectedRecipe != null)
                {
                    DisplayRecipe(selectedRecipe.receipeName, selectedRecipe.Ingredients, selectedRecipe.stepDescriptions, selectedRecipe.totalCalories());
                }
            }
        }
        //=======================================================================================================

        //=======================================================================================================
        // Get the filtered recipe names based on the search query, food groups, and max calories
        //=======================================================================================================
        private List<string> GetFilteredRecipeNames()
        {
            var filteredRecipes = new List<string>();
            var searchQuery = SearchTextBox.Text.Trim().ToLower();

            // Determine selected food groups
            var selectedFoodGroups = new List<string>();
            foreach (var child in FoodGroupsPanel.Children)
            {
                if (child is CheckBox checkbox && checkbox.IsChecked == true)
                {
                    selectedFoodGroups.Add(checkbox.Content.ToString());
                }
            }

            var maxCalories = (int)CaloriesSlider.Value;

            foreach (var recipe in _allRecipes)
            {
                var matchesSearchQuery = string.IsNullOrWhiteSpace(searchQuery) || recipe.receipeName.ToLower().Contains(searchQuery);
                var matchesFoodGroups = selectedFoodGroups.Count == 0 || recipe.Ingredients.Any(ing => selectedFoodGroups.Contains(ing.foodGroup));
                var withinCalories = maxCalories == 0 || recipe.Ingredients.Sum(ing => ing.calories) <= maxCalories;

                if (matchesSearchQuery && matchesFoodGroups && withinCalories)
                {
                    filteredRecipes.Add(recipe.receipeName);
                }
            }

            return filteredRecipes;
        }

        //=======================================================================================================

        //=======================================================================================================
        // Update the recipe list based on the search query, food groups, and max calories
        //=======================================================================================================
        private void UpdateRecipeList()
        {
            if (RecipeListBox == null) return;

            RecipeListBox.Items.Clear();
            var filteredRecipeNames = GetFilteredRecipeNames();
            foreach (var name in filteredRecipeNames)
            {
                RecipeListBox.Items.Add(name);
            }
        }
        //=======================================================================================================

        //=======================================================================================================
        // Display the details of the selected recipe
        //=======================================================================================================
        private void DisplayRecipe(string recipeName, List<Ingredients> ingredients, List<string> steps, double totalCalories)
        {
            if (RecipeDetailsTextBox == null) return;
            else
            {
                RecipeDetailsTextBox.Document.Blocks.Clear();
                RecipeDetailsTextBox.AppendText($"Recipe Name: {recipeName}\n\n");

                // Display Ingredients
                RecipeDetailsTextBox.AppendText("Ingredients:\n");
                foreach (var ingredient in ingredients)
                {
                    RecipeDetailsTextBox.AppendText($"{ingredient.ingredientName}: {ingredient.ingredientQuantity} {ingredient.unitOfMeasurement}, {ingredient.calories} Calories, {ingredient.foodGroup}\n");
                }
                RecipeDetailsTextBox.AppendText($"\nTotal Calories: {totalCalories}\n");


                // Display Steps
                RecipeDetailsTextBox.AppendText("\nSteps:\n");
                foreach (var step in steps)
                {
                    RecipeDetailsTextBox.AppendText($"{step}\n");
                }
            }
        }
        //=======================================================================================================

        //=======================================================================================================
        // Clear the recipe details
        //=======================================================================================================
        private void ClearRecipeDetails()
        {
            if (RecipeDetailsTextBox == null) return;

            RecipeDetailsTextBox.Document.Blocks.Clear();
        }
        //=======================================================================================================
    }
}
//===============================================End-of-page========================================================