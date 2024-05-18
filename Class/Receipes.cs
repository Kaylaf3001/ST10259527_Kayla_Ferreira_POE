using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ST10259527_Kayla_Ferreira_POE.Class
{
    //________________________________________________________________________________________________________
    // Class to represent a recipe
    //________________________________________________________________________________________________________
    internal class Receipes
    {
        // Member variables to store recipe details 
        public string receipeName = ""; // Name of the recipe
        public int ingreNo = 0; // Number of ingredients in the recipe
        public List<Ingredients> Ingredients { get; set; } // List of ingredients in the recipe
        public List<string> stepDescriptions { get; set; } // List of step descriptions in the recipe
        public int repSteps = 0; // Number of steps in the recipe
        public double scaleNumber = 0; // Scale number for the recipe

        //________________________________________________________________________________________________________
        // Constructor for the Receipes class
        //________________________________________________________________________________________________________
        public Receipes()
        {
            // Initialize the list of ingredients and step descriptions
            Ingredients = new List<Ingredients>();
            stepDescriptions = new List<string>();
        }
        //________________________________________________________________________________________________________
        // Method to display recipe
        //________________________________________________________________________________________________________
        public void displayReceipe()
        {
            // Print recipe details
            Console.WriteLine("\n________________________________________________________________________");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("******* " + receipeName + " *******");
            Console.ResetColor();
            Console.WriteLine("Ingredients: ");
            for (int i = 0; i < Ingredients.Count; i++)
            {
                // Print each ingredient
                Console.WriteLine($"{i + 1}. {Ingredients[i].ingredientName}: \n Quantity: {Ingredients[i].ingredientQuantity}" +
                    $"{Ingredients[i].unitOfMeasurement}\nCalories: {Ingredients[i].calories} \nFood Group: {Ingredients[i].foodGroup}");
            }
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < stepDescriptions.Count; i++)
            {
                // Print each step
                Console.WriteLine($"{i + 1}. {stepDescriptions[i]} ");
            }
            Console.Write("\nTotal Calories: ");
            Console.WriteLine("________________________________________________________________________\n");
        }

        //________________________________________________________________________________________________________
        // Method to scale the recipe up or down
        //________________________________________________________________________________________________________
        public void scale(double scaleNumber)
        {
            // Print separator
            Console.WriteLine("\n________________________________________________________________________");
            for (int i = 0; i < Ingredients.Count; i++)
            {
                // Calculate new quantity and print old and new quantities
                double newQuantity = Ingredients[i].originalQuantity * scaleNumber;
                Console.WriteLine("Old: " + Ingredients[i].ingredientQuantity + " New: " + newQuantity);
                Ingredients[i].ingredientQuantity = newQuantity;
            }
            // Print separator
            Console.WriteLine("________________________________________________________________________\n");
            // Display the updated recipe
            displayReceipe();
        }

        //________________________________________________________________________________________________________
        // Method to reset quantities to the original amount input by the user
        //________________________________________________________________________________________________________
        public void resetQuantities()
        {
            // Iterate through ingredQuantity and reset each quantity to its original value
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Ingredients[i].ingredientQuantity = Ingredients[i].originalQuantity;
            }
            // Print message that quantities have been reset
            Console.WriteLine("\nQuantities reverted to original values.");
            // Display the updated recipe
            displayReceipe();
        }
        //
        //Calculate the total calories in the recipe
        //________________________________________________________________________________________________________
        public void totalCalories()
        {
            double totalCalories = 0;
            for (int i = 0; i < Ingredients.Count; i++)
            {
                totalCalories += Ingredients[i].calories;
            }
            Console.WriteLine("Total Calories: " + totalCalories);
        }
        //________________________________________________________________________________________________________
        //Allows the user to input a food group
        //________________________________________________________________________________________________________
        public void foodGroup()
        {
            Console.WriteLine("Food Group: ");
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Ingredients[i].foodGroup}");
            }
        }
    }

    //________________________________________________________________________________________________________
}