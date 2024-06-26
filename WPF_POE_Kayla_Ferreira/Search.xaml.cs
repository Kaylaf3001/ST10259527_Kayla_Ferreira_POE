﻿using System;
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
            _allRecipes.Sort((x, y) => string.Compare(x.receipeName, y.receipeName));
        }

        //=======================================================================================
        // Event Handlers
        //=======================================================================================

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
            Debug.WriteLine("Vegetables checkbox clicked."); // Debug statement
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

        //=======================================================================================
        // ListBox Selection Changed
        //=======================================================================================

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

        //=======================================================================================
        // Filtering Logic
        //=======================================================================================

        // Get the filtered recipe names based on the search query, food groups, and max calories
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

        //=======================================================================================
        // Updating Recipe List
        //=======================================================================================

        // Update the recipe list based on the search query, food groups, and max calories
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

        //=======================================================================================
        // Displaying Recipe Details
        //=======================================================================================

        // Display the details of the selected recipe
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

        // Helper method to append text with specific formatting
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

        //=======================================================================================
        // Clearing Recipe Details
        //=======================================================================================

        // Clear the recipe details
        private void ClearRecipeDetails()
        {
            if (RecipeDetailsTextBox == null) return;

            RecipeDetailsTextBox.Document.Blocks.Clear();
        }
    }
}
