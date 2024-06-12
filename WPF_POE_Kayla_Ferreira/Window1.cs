using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPF_POE_Kayla_Ferreira
{
    public partial class Window1 : Window
    {
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<string> recipeSteps = new List<string>();

        public Window1()
        {
            InitializeComponent();
        }

        private void AddIngredients_Click(object sender, RoutedEventArgs e)
        {
            int ingredientCount;
            if (int.TryParse(IngredientsNumberTextBox.Text, out ingredientCount))
            {
                for (int i = 0; i < ingredientCount; i++)
                {
                    AddIngredient(i + 1);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number of ingredients.");
            }
        }

        private void AddIngredient(int ingredientNumber)
        {
            var ingredientWindow = new IngredientWindow(ingredientNumber);
            if (ingredientWindow.ShowDialog() == true)
            {
                ingredients.Add(ingredientWindow.Ingredient);
                IngredientsList.ItemsSource = null;
                IngredientsList.ItemsSource = ingredients;

                // Display the complete recipe
                DisplayRecipe();
            }
        }

        private void DisplayRecipe()
        {
            // Clear previous recipe details
            RecipeDetailsTextBox.Clear();

            // Recipe name
            RecipeDetailsTextBox.AppendText($"Recipe Name: {RecipeNameTextBox.Text}\n\n");

            // Ingredients
            RecipeDetailsTextBox.AppendText("Ingredients:\n");
            foreach (var ingredient in ingredients)
            {
                RecipeDetailsTextBox.AppendText($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}, {ingredient.Calories} Calories, {ingredient.FoodGroup}\n");
            }

            // Recipe steps
            RecipeDetailsTextBox.AppendText("\nSteps:\n");
            foreach (var step in recipeSteps)
            {
                RecipeDetailsTextBox.AppendText(step + "\n");
            }
        }

        private void AddRecipeStep_Click(object sender, RoutedEventArgs e)
        {
            recipeSteps.Add(RecipeStepTextBox.Text);
            RecipeStepTextBox.Clear();

            // Display the complete recipe
            DisplayRecipe();
        }
    }

    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Calories { get; set; }
        public string FoodGroup { get; set; }
    }
}
