using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using ST10259527_Kayla_Ferreira_POE.Class;

namespace WPF_POE_Kayla_Ferreira
{
    /// <summary>
    /// Kayla Ferreira - ST10259527
    /// References: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/get-started/create-app-visual-studio?view=netdesktop-8.0
    /// https://www.youtube.com/watch?v=gSfMNjWNoX0
    /// https://www.tutorialspoint.com/wpf/index.htm
    /// https://wpf-tutorial.com/listview-control/listview-filtering/
    /// https://www.youtube.com/watch?v=Es8pn5UvqK0
    /// PROG6221 - Assignment 3
    /// </summary>
    public partial class Search : Window
    {
        private List<Recipes> _allRecipes;

        //-----------------------------------------------------------------------------------------------
        // Constructor
        //-----------------------------------------------------------------------------------------------
        public Search()
        {
            InitializeComponent();
            this.Loaded += Search_Loaded;
        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Event handlers and sorts alphabetically
        //-----------------------------------------------------------------------------------------------
        private void Search_Loaded(object sender, RoutedEventArgs e)
        {
            _allRecipes = Window1.AllRecipes ?? new List<Recipes>();
            _allRecipes.Sort((x, y) => string.Compare(x.receipeName, y.receipeName));
        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Event handlers
        //-----------------------------------------------------------------------------------------------
        private void TextBox_Search(object sender, TextChangedEventArgs e)
        {
            UpdateRecipeList();
        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Event handlers
        //-----------------------------------------------------------------------------------------------
        private void CheckBox_Fruits(object sender, RoutedEventArgs e)
        {
            UpdateRecipeList();
        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Event handlers
        //-----------------------------------------------------------------------------------------------
        private void CheckBox_Vegetables(object sender, RoutedEventArgs e)
        {
            UpdateRecipeList();
        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Event handlers
        //-----------------------------------------------------------------------------------------------
        private void CheckBox_Grains(object sender, RoutedEventArgs e)
        {
            UpdateRecipeList();
        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Event handlers
        //-----------------------------------------------------------------------------------------------
        private void CheckBox_Protein(object sender, RoutedEventArgs e)
        {
            UpdateRecipeList();
        }
        //-----------------------------------------------------------------------------------------------


        //-----------------------------------------------------------------------------------------------
        // Event handlers
        //-----------------------------------------------------------------------------------------------
        private void CheckBox_Dairy(object sender, RoutedEventArgs e)
        {
            UpdateRecipeList();
        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Event handlers
        //-----------------------------------------------------------------------------------------------
        private void CheckBox_FatsAndOils(object sender, RoutedEventArgs e)
        {
            UpdateRecipeList();
        }

        //-----------------------------------------------------------------------------------------------
        // Event handlers
        //-----------------------------------------------------------------------------------------------
        private void Slider_Calories(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateRecipeList();
        }
        //-----------------------------------------------------------------------------------------------

        
        //-----------------------------------------------------------------------------------------------
        // keep track of the selected recipe
        //-----------------------------------------------------------------------------------------------
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
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Get the filtered recipe names based on the search query, food groups, and max calories
        //-----------------------------------------------------------------------------------------------
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
                // Check if the recipe name matches the search query
                var matchesSearchQuery = string.IsNullOrWhiteSpace(searchQuery) || recipe.receipeName.ToLower().Contains(searchQuery);

                // Check if any ingredient matches the search query
                var matchesIngredients = recipe.Ingredients.Any(ing =>
                    ing.ingredientName.ToLower().Contains(searchQuery) ||
                    ing.foodGroup.ToLower().Contains(searchQuery));

                // Check if the recipe matches selected food groups
                var matchesFoodGroups = selectedFoodGroups.Count == 0 || recipe.Ingredients.Any(ing => selectedFoodGroups.Contains(ing.foodGroup));

                // Check if the recipe is within max calories limit
                var withinCalories = maxCalories == 0 || recipe.Ingredients.Sum(ing => ing.calories) <= maxCalories;

                // Add recipe to filtered list if it meets all criteria
                if ((matchesSearchQuery || matchesIngredients) && matchesFoodGroups && withinCalories)
                {
                    filteredRecipes.Add(recipe.receipeName);
                }
            }

            return filteredRecipes;
        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Update the recipe list based on the search query, food groups, and max calories
        //-----------------------------------------------------------------------------------------------
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
        //-----------------------------------------------------------------------------------------------
        
        //-----------------------------------------------------------------------------------------------
        // Display the selected recipe details
        //-----------------------------------------------------------------------------------------------
        private void DisplayRecipe(string recipeName, List<Ingredients> ingredients, List<string> steps, double totalCalories)
        {
            if (RecipeDetailsTextBox == null) return;
            else
            {
                RecipeDetailsTextBox.Document.Blocks.Clear();
                RecipeDetailsTextBox.FontFamily = new FontFamily("Century Gothic");

                // Recipe Name
                AppendTextWithFormatting(RecipeDetailsTextBox, $"{recipeName}\n", FontWeights.Bold, 16, Brushes.DarkSalmon);

                // Ingredients
                AppendTextWithFormatting(RecipeDetailsTextBox, "Ingredients:", FontWeights.Bold, 14, Brushes.DarkSalmon);
                foreach (var ingredient in ingredients)
                {
                    AppendTextWithFormatting(RecipeDetailsTextBox, $"{ingredient.ingredientName}: {ingredient.ingredientQuantity} {ingredient.unitOfMeasurement}, {ingredient.calories} Calories, {ingredient.foodGroup}", FontWeights.Normal, 12, Brushes.Black);
                }
                AppendTextWithFormatting(RecipeDetailsTextBox, $"\nTotal Calories: {totalCalories}\n", FontWeights.Bold, 14, Brushes.DarkSalmon);

                // Steps
                AppendTextWithFormatting(RecipeDetailsTextBox, "\nSteps:", FontWeights.Bold, 14, Brushes.DarkSalmon);
                foreach (var step in steps)
                {
                    AppendTextWithFormatting(RecipeDetailsTextBox, $"{step}", FontWeights.Normal, 12, Brushes.Black);
                }
            }
        }
        //-----------------------------------------------------------------------------------------------
       
        //-----------------------------------------------------------------------------------------------
        // Append text with formatting to the RichTextBox
        //-----------------------------------------------------------------------------------------------
        private void AppendTextWithFormatting(RichTextBox richTextBox, string text, FontWeight fontWeight, double fontSize, SolidColorBrush foregroundBrush)
        {
            var run = new Run(text)
            {
                FontWeight = fontWeight,
                FontSize = fontSize,
                Foreground = foregroundBrush
            };
            var paragraph = new Paragraph(run);
            richTextBox.Document.Blocks.Add(paragraph);
        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Clear the recipe details
        //-----------------------------------------------------------------------------------------------
        private void ClearRecipeDetails()
        {
            if (RecipeDetailsTextBox == null) return;

            RecipeDetailsTextBox.Document.Blocks.Clear();
        }
        //-----------------------------------------------------------------------------------------------
    }
    //-----------------------------------------------------------------------------------------------
}
//--------------------------------------End-of-File-------------------------------------------------------
