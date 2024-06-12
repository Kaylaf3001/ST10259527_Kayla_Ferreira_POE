using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static WPF_POE_Kayla_Ferreira.Window1;

namespace WPF_POE_Kayla_Ferreira
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2(List<Recipe> allRecipes)
        {
            InitializeComponent();
            foreach (var recipe in allRecipes)
            {
                DisplayRecipe(recipe.Name, recipe.Ingredients, recipe.Steps);
            }
        }

        private void DisplayRecipe(string recipeName, List<Ingredient> ingredients, List<string> recipeSteps)
        {
            // Recipe name
            RecipeDetailsTextBox.AppendText($"Recipe Name: {recipeName}\n\n");

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
    }
}
