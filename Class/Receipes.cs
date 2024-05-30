using System;
using System.Collections.Generic;

namespace ST10259527_Kayla_Ferreira_POE.Class
{
    // Delegate definition that returns void and takes no parameters
    public delegate bool TotalCaloriesCheckDelegate();

    //--------------------------------------------------------------------------------------------------------
    // Class to represent a recipe
    //--------------------------------------------------------------------------------------------------------
    public class Receipes
    {
        // Member variables to store recipe details
        public string receipeName = ""; // Name of the recipe
        public int ingreNo = 0; // Number of ingredients in the recipe
        public List<Ingredients> Ingredients { get; set; } // List of ingredients in the recipe
        public List<string> stepDescriptions { get; set; } // List of step descriptions in the recipe
        public int repSteps = 0; // Number of steps in the recipe
        public double scaleNumber = 0; // Scale number for the recipe

        // Instance of the delegate
        public TotalCaloriesCheckDelegate totalCaloriesCheckDelegate;

        //--------------------------------------------------------------------------------------------------------
        // Constructor for the Receipes class
        //--------------------------------------------------------------------------------------------------------
        public Receipes()
        {
            // Initialize the list of ingredients and step descriptions
            Ingredients = new List<Ingredients>();
            stepDescriptions = new List<string>();
            // Assign the totalCalorieCheck method to the delegate
            totalCaloriesCheckDelegate = totalCalorieCheck;
        }

        //--------------------------------------------------------------------------------------------------------
        // Method to display recipe
        //--------------------------------------------------------------------------------------------------------
        public void displayReceipe()
        {
            // Print recipe details
            Console.WriteLine("\n________________________________________________________________________");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"******* {receipeName} *******");
            Console.ResetColor();

            Console.WriteLine("\nIngredients:");
            for (int i = 0; i < Ingredients.Count; i++)
            {
                // Print each ingredient
                Console.WriteLine($"{i + 1}. {Ingredients[i].ingredientName}");
                Console.WriteLine($"   Quantity: {Ingredients[i].ingredientQuantity} {Ingredients[i].unitOfMeasurement}");
                Console.WriteLine($"   Calories: {Ingredients[i].calories}");
                Console.WriteLine($"   Food Group: {Ingredients[i].foodGroup}\n");
            }

            // Call totalCalories() and capture the returned value
            double totalCal = totalCalories();
            Console.WriteLine($"Total Calories: {totalCal}\n");

            Console.WriteLine("Steps:");
            for (int i = 0; i < stepDescriptions.Count; i++)
            {
                // Print each step
                Console.WriteLine($"{i + 1}. {stepDescriptions[i]}\n");
            }

            // Call totalCalorieMeaning() and display the result
            totalCalorieMeaning();

            Console.WriteLine("________________________________________________________________________\n");
        }

        //--------------------------------------------------------------------------------------------------------
        // Method to scale the recipe up or down
        //--------------------------------------------------------------------------------------------------------
        public void scale(double scaleNumber)
        {
            UnitConverterMeasure converter = new UnitConverterMeasure();

            // Print separator
            Console.WriteLine("\n________________________________________________________________________");
            for (int i = 0; i < Ingredients.Count; i++)
            {
                // Calculate new quantity and print old and new quantities
                double newQuantity = Ingredients[i].ingredientQuantity * scaleNumber;
                Console.WriteLine("Old: " + Ingredients[i].ingredientQuantity + " New: " + newQuantity);
                Ingredients[i].ingredientQuantity = newQuantity;

                // Convert the unit of measurement
                (double convertedQuantity, string newUnitOfMeasurement) = converter.convertUnitOfMeasurement(newQuantity, Ingredients[i].unitOfMeasurement);
                Console.WriteLine("Converted: " + convertedQuantity);

                //Scale the calories
                Ingredients[i].calories = Ingredients[i].calories * scaleNumber;
                Console.WriteLine("Calories: " + Ingredients[i].calories);

                // Update the ingredient quantity and unit of measurement
                Ingredients[i].ingredientQuantity = convertedQuantity;
                Ingredients[i].unitOfMeasurement = newUnitOfMeasurement;
            }
            // Print separator
            Console.WriteLine("________________________________________________________________________\n");
            // Display the updated recipe
            displayReceipe();
        }

        //--------------------------------------------------------------------------------------------------------
        // Method to reset quantities to the original amount input by the user
        //--------------------------------------------------------------------------------------------------------
        public void resetQuantities()
        {
            // Iterate through ingredQuantity and reset each quantity to its original value
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Ingredients[i].ingredientQuantity = Ingredients[i].originalQuantity;
            }
            // Print message that quantities have been reset
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nQuantities reverted to original values.");
            Console.ResetColor();
            // Display the updated recipe
            displayReceipe();
        }

        //--------------------------------------------------------------------------------------------------------
        // Calculate the total calories in the recipe
        //--------------------------------------------------------------------------------------------------------
        public double totalCalories()
        {
            double totalCalories = 0;
            for (int i = 0; i < Ingredients.Count; i++)
            {
                totalCalories += Ingredients[i].calories;
            }
            return totalCalories;
        }
        //--------------------------------------------------------------------------------------------------------
        // Method to check the total calories and determine if the recipe is healthy
        //--------------------------------------------------------------------------------------------------------
        public bool totalCalorieMeaning()
        {
            if (totalCalories() > 500)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This recipe has a high calorie count, which is not suitable for those on a low-calorie diet.");
                Console.ResetColor();
                return false;
            }
            else if (totalCalories() >= 300 && totalCalories() <= 500)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("This meal has a moderate calorie content and is healthy.");
                Console.ResetColor();
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You might want to consider adding some more calories to this meal.");
                Console.ResetColor();
                return true;
            }
        }
        //--------------------------------------------------------------------------------------------------------
        // Allows the user to input a food group
        //--------------------------------------------------------------------------------------------------------
        public void foodGroup()
        {
            Console.WriteLine("Food Group: ");
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Ingredients[i].foodGroup}");
            }
        }

        //--------------------------------------------------------------------------------------------------------
        // Method to check the total calories and determine if the recipe is healthy
        //--------------------------------------------------------------------------------------------------------
        public bool totalCalorieCheck()
        {
            double totalCal = totalCalories();

            if (totalCal > 300)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Note: The receipe has exceeded 300 calories");
                Console.ResetColor();
                return false;
            }
            else
            {
                return true;
            }
        }
        //--------------------------------------------------------------------------------------------------------
    }
}