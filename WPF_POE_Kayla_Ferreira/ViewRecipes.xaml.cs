using ST10259527_Kayla_Ferreira_POE.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WPF_POE_Kayla_Ferreira
{
    public partial class Window2 : Window
    {
        private List<Recipes> _allRecipes;
        private Recipes selectedRecipe;

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
                selectedRecipe = _allRecipes.FirstOrDefault(r => r.receipeName == RecipeListBox.SelectedItem.ToString());
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

        private void DisplayRecipe(string recipeName, List<Ingredients> ingredients, List<string> recipeSteps, double totalCalories)
        {
            RecipeDetailsTextBox.Document.Blocks.Clear(); // Clear previous content
            RecipeStepsListView.Items.Clear();
            RecipeStepsListView.Visibility = Visibility.Visible;

            // Recipe name
            var recipeNameRun = new Run($"Recipe Name: {recipeName}")
            {
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.DarkBlue,
                FontFamily = new FontFamily("Century Gothic") // Set font to Century Gothic
            };
            var recipeNameParagraph = new Paragraph(recipeNameRun);
            RecipeDetailsTextBox.Document.Blocks.Add(recipeNameParagraph);

            // Ingredients
            var ingredientsParagraph = new Paragraph();
            var ingredientsTitleRun = new Run("Ingredients:\n")
            {
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.DarkGreen,
                FontFamily = new FontFamily("Century Gothic") // Set font to Century Gothic
            };
            ingredientsParagraph.Inlines.Add(ingredientsTitleRun);

            foreach (var ingredient in ingredients)
            {
                var ingredientRun = new Run($"{ingredient.ingredientName}: {ingredient.ingredientQuantity} {ingredient.unitOfMeasurement}, {ingredient.calories} Calories, {ingredient.foodGroup}\n")
                {
                    FontSize = 12,
                    Foreground = Brushes.Black,
                    FontFamily = new FontFamily("Century Gothic") // Set font to Century Gothic
                };
                ingredientsParagraph.Inlines.Add(ingredientRun);
            }
            RecipeDetailsTextBox.Document.Blocks.Add(ingredientsParagraph);

            // Display total calories
            var totalCaloriesRun = new Run($"Total Calories: {totalCalories}\n")
            {
                FontSize = 14,
                FontWeight = FontWeights.Bold,
                Foreground = Brushes.Red,
                FontFamily = new FontFamily("Century Gothic") // Set font to Century Gothic
            };
            var totalCaloriesParagraph = new Paragraph(totalCaloriesRun);
            RecipeDetailsTextBox.Document.Blocks.Add(totalCaloriesParagraph);

            // Recipe steps
            foreach (var step in recipeSteps)
            {
                RecipeStepsListView.Items.Add(new CheckBox { Content = step, Margin = new Thickness(0, 2, 0, 2) });
            }
        }

        private void ScaleButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecipe != null)
            {
                Button button = sender as Button;
                double scaleFactor = Convert.ToDouble(button.Tag);

                // Call the scale method with the appropriate factor
                selectedRecipe.scale(scaleFactor);

                // Refresh the displayed recipe details after scaling
                DisplayRecipe(selectedRecipe.receipeName, selectedRecipe.Ingredients, selectedRecipe.stepDescriptions, selectedRecipe.totalCalories());
            }
        }
    }
}
