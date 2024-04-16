using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ST10259527_Kayla_Ferreira_POE.Class
{
    internal class Receipes
    {
        // Member variables to store recipe details
        Receipes receipes; 
        public string receipeName = "";
        public int ingreNo = 0;
        public List<Ingredients> Ingredients { get; set; }
        public string[] stepDescriptions = { };
        public int repSteps = 0;
        public double scaleNumber = 0;

        public Receipes()
        {
            Ingredients = new List<Ingredients>();
        }

        // Method to take user input for recipe details
        public void userInput()
        {
            receipes = new Receipes();
            bool validInput = false;

            while (!validInput)
            {
                try
                {
                    // Prompt user for recipe details
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("********** Recipe Book **********");
                    Console.ResetColor();
                    

                    Console.WriteLine("Would you like to change the scale of your recipe? (1 - Yes, 0 - No)");
                    int response2 = Convert.ToInt32(Console.ReadLine());

                    if (response2 == 1)
                    {
                        Console.WriteLine("What would you like to scale down to?");
                        string scaleInput = Console.ReadLine();
                        scaleNumber = double.Parse(scaleInput, System.Globalization.CultureInfo.InvariantCulture);
                        scale(); // Method to scale the recipe up or down
                    }

                    Console.WriteLine("Would you like to revert back to the original quantities? (1 - Yes, 0 - No)");
                    int response3 = Convert.ToInt32(Console.ReadLine());

                    if (response3 == 1)
                    {
                        resetQuantities(); // Method to reset quantities to the original amount input by the user
                    }

                    Console.WriteLine("Would you like to clear the data for a new recipe?(1 - Yes, 0 - No)");
                    int response4 = Convert.ToInt32(Console.ReadLine());

                    if (response4 == 1)
                    {
                        clearData(); // Method to clear data for a new recipe
                    }
                    else
                    {
                        userInput(); // Recursive call to continue with another recipe
                    }

                    validInput = true; // If no exception occurs, set validInput to true to exit the loop
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input format. Please enter a valid number.");
                    Console.ResetColor();
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input is too large to be converted to an integer.");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }

        // Method to input ingredient names, quantities, and units
        public void nameQuanUnit()
        {
            for (int i = 0; i < ingreNo; i++)
            {
                Console.WriteLine($"Ingredient {i + 1}:");

                Console.Write("Name: ");
                string ingredientNames = Console.ReadLine();

                Console.Write("Quantity: ");
                double ingredQuantity = Convert.ToInt32(Console.ReadLine());

                double originalQuantities = ingredQuantity; // Store original quantity

                Console.WriteLine("Is there a unit of measurement? (1 - Yes and 0 - No)");
                int resp = Convert.ToInt32(Console.ReadLine());

                Ingredients newIngredient;
                if (resp == 1)
                {
                    Console.WriteLine("What is the unit of measurement?");
                    string unitOfMeasurement = Console.ReadLine();
                    newIngredient = new Ingredients(ingredientNames, ingredQuantity, originalQuantities, unitOfMeasurement);
                }
                else
                {
                    newIngredient = new Ingredients(ingredientNames, ingredQuantity, originalQuantities);
                }
                receipes.Ingredients.Add(newIngredient);
                Console.WriteLine();
            }
        }

        // Method to input instructions on how to make the dish
        public void steps()
        {
            stepDescriptions = new string[repSteps];
            Console.WriteLine("________________________________________________________________________");
            for (int i = 0; i < repSteps; i++)
            {
                Console.WriteLine($"Step {i + 1}: ");
                stepDescriptions[i] = Console.ReadLine();
            }
            Console.WriteLine("________________________________________________________________________\n");
        }

        // Method to display recipe
        public void displayReceipe()
        {
            Console.WriteLine("\n________________________________________________________________________");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("******* " + receipeName + " *******");
            Console.ResetColor();
            Console.WriteLine("Ingredients: ");
            for (int i = 0; i < receipes.Ingredients.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {receipes.Ingredients[i].ingredientName}: {receipes.Ingredients[i].ingredientQuantity} {receipes.Ingredients[i].unitOfMeasurement}");
            }
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < stepDescriptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {stepDescriptions[i]} ");
            }
            Console.WriteLine("________________________________________________________________________\n");
        }

        // Method to scale the recipe up or down
        public void scale()
        {
            Console.WriteLine("\n________________________________________________________________________");
            for (int i = 0; i < receipes.Ingredients.Count; i++)
            {
                double newQuantity = receipes.Ingredients[i].originalQuantity * scaleNumber;
                Console.WriteLine("Old: " + receipes.Ingredients[i].ingredientQuantity + " New: " + newQuantity);
                receipes.Ingredients[i].ingredientQuantity = newQuantity;
            }
            Console.WriteLine("________________________________________________________________________\n");
            displayReceipe();
        }

        // Method to reset quantities to the original amount input by the user
        public void resetQuantities()
        {
            // Iterate through ingredQuantity and reset each quantity to its original value
            for (int i = 0; i < receipes.Ingredients.Count; i++)
            {
                receipes.Ingredients[i].ingredientQuantity = receipes.Ingredients[i].originalQuantity;
            }
            Console.WriteLine("\nQuantities reverted to original values.");
            displayReceipe();
        }

        // Method to clear data for a new recipe
        public void clearData()
        {
            Console.WriteLine("Are you sure you want to clear all data? (1 - Yes and 0 - No)");
            int confirmation = Convert.ToInt32(Console.ReadLine());

            if (confirmation == 1)
            {
                // Clear data
                receipeName = "";
                receipes = null;
                
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Data cleared successfully.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Data not cleared.");
                Console.ResetColor();

            }

            // Restart userInput() to allow user to enter a new recipe
            userInput();
        }
    }
}