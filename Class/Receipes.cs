using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10259527_Kayla_Ferreira_POE.Class
{
    internal class Receipes
    {
        // Member variables to store recipe details
        private string receipeName = "";
        private string[] ingredientNames = { };
        private string[] stepDescriptions = { };
        private double[] ingredQuantity = { };
        private double[] originalQuantities = { };
        private double scaleNumber = 0;
        private string[] unitOfMeasurement = { };
        private int repSteps = 0;
        private int ingreNo = 0;

        // Method to take user input for recipe details
        public void userInput()
        {
            bool validInput = false;

            while (!validInput)
            {
                try
                {
                    // Prompt user for recipe details
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("********** Recipe Book **********");
                    Console.ResetColor();
                    Console.WriteLine("What is the name of the recipe?");
                    receipeName = Console.ReadLine();

                    Console.WriteLine("\nHow many Ingredients does your recipe have?");
                    ingreNo = Convert.ToInt32(Console.ReadLine());

                    // Arrays to store the data
                    ingredientNames = new string[ingreNo];
                    ingredQuantity = new double[ingreNo];
                    originalQuantities = new double[ingreNo];
                    unitOfMeasurement = new string[ingreNo];

                    Console.WriteLine("\nName and Quantity of your ingredients:");
                    nameQuanUnit(); // Method to input ingredient names, quantities, and units

                    Console.WriteLine("\nHow many steps are there?");
                    repSteps = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter a description for each step: ");
                    steps(); // Method to input instructions on how to make the dish

                    // Prompt user for additional actions
                    Console.WriteLine("Would you like to view the recipe? (1 - Yes and 0 - No)");
                    int response = Convert.ToInt32(Console.ReadLine());

                    if (response == 1)
                    {
                        displayReceipe(); // Method to display recipe
                    }

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
                ingredientNames[i] = Console.ReadLine();
                Console.Write("Quantity: ");
                ingredQuantity[i] = Convert.ToInt32(Console.ReadLine());
                originalQuantities[i] = ingredQuantity[i]; // Store original quantity
                Console.WriteLine("Is there a unit of measurement? (1 - Yes and 0 - No)");
                int resp = Convert.ToInt32(Console.ReadLine());
                if (resp == 1)
                {
                    Console.WriteLine("What is the unit of measurement?");
                    unitOfMeasurement[i] = Console.ReadLine();
                }
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
            Console.WriteLine("________________________________________________________________________");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n******* " + receipeName + " *******");
            Console.ResetColor();
            Console.WriteLine("Ingredients: ");
            for (int i = 0; i < ingredientNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {ingredientNames[i]}: {ingredQuantity[i]} {unitOfMeasurement[i]}");
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
            for (int i = 0; i < ingredQuantity.Length; i++)
            {
                double newQuantity = originalQuantities[i] * scaleNumber;
                Console.WriteLine("Old: " + ingredQuantity[i] + " New: " + newQuantity);
                ingredQuantity[i] = newQuantity;
            }
            Console.WriteLine("________________________________________________________________________\n");
            displayReceipe();
        }

        // Method to reset quantities to the original amount input by the user
        public void resetQuantities()
        {
            // Iterate through ingredQuantity and reset each quantity to its original value
            for (int i = 0; i < ingredQuantity.Length; i++)
            {
                ingredQuantity[i] = originalQuantities[i];
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
                ingredientNames = new string[] { };
                stepDescriptions = new string[] { };
                ingredQuantity = new double[] { };
                originalQuantities = new double[] { };
                scaleNumber = 0;
                unitOfMeasurement = new string[] { };

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