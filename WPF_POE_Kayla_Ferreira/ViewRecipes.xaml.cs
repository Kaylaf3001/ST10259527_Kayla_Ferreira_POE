using ST10259527_Kayla_Ferreira_POE.Class;
using System;
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
        private List<Recipes> _allRecipes;

        public Window2(List<Recipes> allRecipes)
        {
            InitializeComponent();

            _allRecipes = allRecipes;

            // Populate the ListBox with recipe names
            foreach (var recipe in _allRecipes)
            {
                RecipeListBox.Items.Add(recipe.receipeName);
            }
        }

        private void RecipeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecipeListBox.SelectedItem != null)
            {
                var selectedRecipe = _allRecipes.FirstOrDefault(r => r.receipeName == RecipeListBox.SelectedItem.ToString());
                if (selectedRecipe != null)
                {
                    DisplayRecipe(selectedRecipe.receipeName, selectedRecipe.Ingredients, selectedRecipe.stepDescriptions, selectedRecipe.totalCalories());
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
        private void DisplayRecipe(string recipeName, List<Ingredients> ingredients, List<string> recipeSteps, double totalCalories)
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
                ingredientsParagraph.Inlines.Add(new Run($"{ingredient.ingredientName}: {ingredient.ingredientQuantity} {ingredient.unitOfMeasurement}, {ingredient.calories} Calories, {ingredient.foodGroup}\n"));
            }
            RecipeDetailsTextBox.Document.Blocks.Add(ingredientsParagraph);

            // Display total calories
            var totalCaloriesParagraph = new Paragraph(new Run($"\nTotal Calories: {totalCalories}\n"));
            RecipeDetailsTextBox.Document.Blocks.Add(totalCaloriesParagraph);

            // Recipe steps
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

        private void AddRecipeButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
