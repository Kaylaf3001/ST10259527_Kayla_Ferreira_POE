using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPF_POE_Kayla_Ferreira
{
    public partial class Window1 : Window
    {
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<string> recipeSteps = new List<string>();
        public static List<Recipe> AllRecipes { get; private set; } = new List<Recipe>();

        public Window1()
        {
            
            InitializeComponent();
        }
        public class Recipe
        {
            public string Name { get; set; }
            public List<Ingredient> Ingredients { get; set; }
            public List<string> Steps { get; set; }
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
            int stepNumber = 1;
            foreach (var step in recipeSteps)
            {
                RecipeDetailsTextBox.AppendText($"{stepNumber}. {step}\n");
                stepNumber++;
            }
        }

        private void AddRecipeStep_Click(object sender, RoutedEventArgs e)
        {
            recipeSteps.Add(RecipeStepTextBox.Text);
            RecipeStepTextBox.Clear();

            // Display the complete recipe
            DisplayRecipe();
        }

        // Create a new Recipe instance when the "Done" button is clicked
        private void Button_Click_1(object sender, RoutedEventArgs e)
        { 
            Recipe newRecipe = new Recipe
            {
                Name = RecipeNameTextBox.Text,
                Ingredients = ingredients,
                Steps = recipeSteps
            };

            // Add the new recipe to AllRecipes
            AllRecipes.Add(newRecipe);

            // Show a message box indicating that the recipe has been saved
            MessageBox.Show("Recipe has been saved!");

            // Close the current window
            this.Close();

            MainWindow existingMainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (existingMainWindow == null)
            {
                // If not, open a new MainWindow
                MainWindow newWindow1 = new MainWindow();
                newWindow1.Show();
            }
        }

        private void RecipeNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Example implementation
            Console.WriteLine("Recipe name text changed.");
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
