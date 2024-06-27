using ST10259527_Kayla_Ferreira_POE.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPF_POE_Kayla_Ferreira
{
    /// <summary>
    /// Kayla Ferreira - ST10259527
    /// References: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/get-started/create-app-visual-studio?view=netdesktop-8.0
    /// https://www.youtube.com/watch?v=gSfMNjWNoX0
    /// https://www.tutorialspoint.com/wpf/index.htm
    /// PROG6221 - Assignment 3
    /// </summary>
   //-----------------------------------------------------------------------------------------------
    public partial class Window1 : Window
    {
        
        // List to store the ingredients and recipe steps
        private List<Ingredients> ingredients = new List<Ingredients>();
        private List<string> recipeSteps = new List<string>();
        public static List<Recipes> AllRecipes { get; private set; } = new List<Recipes>();
        private bool hasShownCalorieWarning = false; // Flag to track if the warning has been shown

        //-----------------------------------------------------------------------------------------------
        // Constructor
        //-----------------------------------------------------------------------------------------------
        public Window1()
        {
            //call dummy data from Recipe class
            List<Recipes> dummyRecipes = Recipes.getDummyRecipes();
            foreach (var recipe in dummyRecipes)
            {
                AllRecipes.Add(recipe);
            }
            InitializeComponent();

            
        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Event handlers
        //-----------------------------------------------------------------------------------------------
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
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Method to add an ingredient to the recipe
        //-----------------------------------------------------------------------------------------------
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
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Method to display the complete recipe
        //-----------------------------------------------------------------------------------------------
        private void DisplayRecipe()
        {
            // Create a new recipe instance
            Recipes currentRecipe = new Recipes
            {
                receipeName = RecipeNameTextBox.Text,
                Ingredients = ingredients,
                stepDescriptions = recipeSteps
            };

            // Clear previous recipe details
            RecipeDetailsTextBox.Clear();

            // Recipe name
            RecipeDetailsTextBox.AppendText($"Recipe Name: {currentRecipe.receipeName}\n\n");

            // Ingredients
            RecipeDetailsTextBox.AppendText("Ingredients:\n");
            foreach (var ingredient in currentRecipe.Ingredients)
            {
                RecipeDetailsTextBox.AppendText($"{ingredient.ingredientName}: {ingredient.ingredientQuantity} {ingredient.unitOfMeasurement}, {ingredient.calories} Calories, {ingredient.foodGroup}\n");
            }

            // Display total calories
            double totalCalories = currentRecipe.totalCalories();
            RecipeDetailsTextBox.AppendText($"\nTotal Calories: {totalCalories}\n");

            // Check if total calories exceed 300 and show a warning if not already shown
            if (totalCalories > 300 && !hasShownCalorieWarning)
            {
                MessageBox.Show("Warning: The recipe has exceeded 300 calories!");
                hasShownCalorieWarning = true; // Set the flag to true to indicate the warning has been shown
            }

            // Recipe steps
            RecipeDetailsTextBox.AppendText("\nSteps:\n");
            int stepNumber = 1;
            foreach (var step in currentRecipe.stepDescriptions)
            {
                RecipeDetailsTextBox.AppendText($"{stepNumber}. {step}\n");
                stepNumber++;
            }
        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Event handler for the Save Recipe button
        //-----------------------------------------------------------------------------------------------
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Validate recipe name
            if (string.IsNullOrWhiteSpace(RecipeNameTextBox.Text))
            {
                MessageBox.Show("Please enter a recipe name.");
                return; // Stop further execution if validation fails
            }

            // Validate ingredients list
            if (ingredients.Count == 0)
            {
                MessageBox.Show("Please add ingredients to the recipe.");
                return; // Stop further execution if validation fails
            }

            // Validate recipe steps
            if (recipeSteps.Count == 0)
            {
                MessageBox.Show("Please add recipe steps.");
                return; // Stop further execution if validation fails
            }

            // Create a new Recipe instance
            Recipes newRecipe = new Recipes
            {
                receipeName = RecipeNameTextBox.Text,
                Ingredients = ingredients,
                stepDescriptions = recipeSteps
            };

            // Add the new recipe to AllRecipes
            AllRecipes.Add(newRecipe);

            // Show a message box indicating that the recipe has been saved
            MessageBox.Show("Recipe has been saved!");

            // Close the current window
            this.Close();

            // Open a new MainWindow if one isn't already open
            MainWindow existingMainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (existingMainWindow == null)
            {
                MainWindow newMainWindow = new MainWindow();
                newMainWindow.Show();
            }
        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Event handler for the RecipeNameTextBox TextChanged event
        //-----------------------------------------------------------------------------------------------
        private void RecipeNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Example implementation
            Console.WriteLine("Recipe name text changed.");
        }
        //-----------------------------------------------------------------------------------------------

        //-----------------------------------------------------------------------------------------------
        // Event handler for the AddRecipeStep button
        //-----------------------------------------------------------------------------------------------
        private void AddRecipeStep_Click(object sender, RoutedEventArgs e)
        {
            recipeSteps.Add(RecipeStepTextBox.Text);
            RecipeStepTextBox.Clear();

            // Display the complete recipe
            DisplayRecipe();
        }
        //-----------------------------------------------------------------------------------------------
    }
    //-----------------------------------------------------------------------------------------------
}
//---------------------------------------End-of-File--------------------------------------------------------
