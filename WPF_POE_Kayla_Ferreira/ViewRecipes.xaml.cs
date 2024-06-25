﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using static WPF_POE_Kayla_Ferreira.Window1;

namespace WPF_POE_Kayla_Ferreira
{
    public partial class Window2 : Window
    {
        private List<Recipe> _allRecipes;

        public Window2(List<Recipe> allRecipes)
        {
            InitializeComponent();

            _allRecipes = allRecipes ?? CreateTestRecipes();

            // Populate the ListBox with recipe names
            foreach (var recipe in _allRecipes)
            {
                RecipeListBox.Items.Add(recipe.Name);
            }
        }

        private List<Recipe> CreateTestRecipes()
        {
            // Create test data if no recipes are provided
            return new List<Recipe>
            {
                new Recipe
                {
                    Name = "Test Recipe 1",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Name = "Ingredient 1", Quantity = 2, Unit = "cups", Calories = 100, FoodGroup = "Grains" },
                        new Ingredient { Name = "Ingredient 2", Quantity = 1, Unit = "tbsp", Calories = 50, FoodGroup = "Fats and oils" }
                    },
                    Steps = new List<string> { "Step 1: Do something.", "Step 2: Do the next thing." }
                },
                new Recipe
                {
                    Name = "Test Recipe 2",
                    Ingredients = new List<Ingredient>
                    {
                        new Ingredient { Name = "Ingredient A", Quantity = 3, Unit = "lbs", Calories = 300, FoodGroup = "Protein" },
                        new Ingredient { Name = "Ingredient B", Quantity = 0.5, Unit = "cup", Calories = 150, FoodGroup = "Dairy" }
                    },
                    Steps = new List<string> { "Step 1: Prepare something.", "Step 2: Cook it." }
                }
            };
        }

        private void RecipeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                var selectedRecipe = _allRecipes.FirstOrDefault(r => r.Name == RecipeListBox.SelectedItem.ToString());
                if (selectedRecipe != null)
                {
                    DisplayRecipe(selectedRecipe.Name, selectedRecipe.Ingredients, selectedRecipe.Steps);
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Simply close this window to go back to the MainWindow.
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear the selection and steps.
            RecipeListBox.SelectedItem = null;
            RecipeDetailsTextBox.Document.Blocks.Clear();
            RecipeStepsListView.Items.Clear();
            RecipeStepsListView.Visibility = Visibility.Collapsed;
        }
        //=======================================================================================================
        // Display the selected recipe details in the RecipeDetailsTextBox and RecipeStepsListView
        private void DisplayRecipe(string recipeName, List<Ingredient> ingredients, List<string> recipeSteps)
        {
            RecipeDetailsTextBox.Document.Blocks.Clear(); // Clear previous content
            RecipeStepsListView.Items.Clear();
            RecipeStepsListView.Visibility = Visibility.Visible;

            // Recipe name
            var recipeNameParagraph = new Paragraph(new Run($"Recipe Name: {recipeName}"));
            RecipeDetailsTextBox.Document.Blocks.Add(recipeNameParagraph);

            // Ingredients
            var ingredientsParagraph = new Paragraph(new Run("Ingredients:\n"));
            foreach (var ingredient in ingredients)
            {
                ingredientsParagraph.Inlines.Add(new Run($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}, {ingredient.Calories} Calories, {ingredient.FoodGroup}\n"));
            }
            RecipeDetailsTextBox.Document.Blocks.Add(ingredientsParagraph);

            // Adding a separator line between ingredients and steps for better readability
            RecipeDetailsTextBox.Document.Blocks.Add(new Paragraph(new Run("\nSteps:\n")));

            foreach (var step in recipeSteps)
            {
                RecipeStepsListView.Items.Add(new CheckBox { Content = step, Margin = new Thickness(0, 2, 0, 2) });
            }
        }
        //=======================================================================================================

        //=======================================================================================================
        // The following methods are not used in this class, but are kept here for future reference if needed.
        //=======================================================================================================
        private void RecipeDetailsTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Handle text changed event if needed
        }
    }
}
