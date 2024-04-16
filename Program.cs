using ST10259527_Kayla_Ferreira_POE.Class;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ST10259527_Kayla_Ferreira_POE
{
    internal class Program
    {
        Receipes receipe;
        static void Main(string[] args)
        {
            Program worker = new Program();
            worker.Run();
        }
        private void Run()
        {
            bool exit = false;
            while (!exit)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Welcome to the Recipe Application!!");
                    Console.ResetColor();
                    Console.WriteLine("Please select an option");
                    Console.WriteLine("1. Add a Recipe");
                    Console.WriteLine("2. View Recipe");
                    Console.WriteLine("3. Exit");
                    Console.Write("Please enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            UserGetsReceipe(); // Method to input ingredient names, quantities, and units
                            break;

                        case 2:
                            receipe.displayReceipe(); // Method to display recipe
                            break;

                        case 3:
                            Console.WriteLine("Exiting the Recipe Application...");
                            exit = true; // Set exit flag to true to exit the loop
                            break;

                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"An error occurred. Please re-enter");
                    Console.ResetColor();
                }
            }
        }
        //=======================================================================================================================================================================
        // Method to create and get a recipe.
        //=======================================================================================================================================================================
        private Receipes UserGetsReceipe()
        {
            try
            {
                receipe = new Receipes();

                Console.WriteLine("What is the name of the recipe?");
                receipe.receipeName = Console.ReadLine();

                receipe.ingreNo = (int)NumberInput("\nHow many Ingredients does your recipe have?");

                Console.WriteLine("\nName and Quantity of your ingredients:");

                for (int i = 0; i < receipe.ingreNo; i++)
                {
                    Ingredients newIngredient = UserGetsIngredient(i);
                    receipe.Ingredients.Add(newIngredient);
                }

                receipe.repSteps = (int)NumberInput("\nHow many steps are there?");
                Console.WriteLine("Please enter a description for each step: ");

                Console.WriteLine("________________________________________________________________________");
                for (int i = 0; i < receipe.repSteps; i++)
                {
                    Console.WriteLine($"Step {i + 1}: ");
                    receipe.stepDescriptions.Add(Console.ReadLine());
                }
                Console.WriteLine("________________________________________________________________________\n");

                int response = (int)NumberInput("Would you like to view you receipe? (1 - Yes, 0 - No)");
                if (response == 1)
                {
                    receipe.displayReceipe();
                }

                int response2 = (int)NumberInput("Would you like to change the scale of your recipe? (1 - Yes, 0 - No)");

                if (response2 == 1)
                {
                    double scaleNumber = NumberInput("What would you like to scale it to?");
                    receipe.scale(scaleNumber); // Method to scale the recipe up or down
                }

                int response3 = (int)NumberInput("Would you like to revert back to the original quantities? (1 - Yes, 0 - No)");

                if (response3 == 1)
                {
                    receipe.resetQuantities(); // Method to reset quantities to the original amount input by the user
                }

                int response4 = (int)NumberInput("Would you like to clear the data for a new recipe?(1 - Yes, 0 - No)");

                if (response4 == 1)
                {
                    clearData(); // Method to clear data for a new recipe
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            return receipe;
        }
        //=======================================================================================================================================================================
        // Method gets and prints the ingredients.
        //=======================================================================================================================================================================
        private Ingredients UserGetsIngredient(int i)
        {

            Console.WriteLine($"Ingredient {i + 1}:");

            Console.Write("Name: ");
            string ingredientNames = Console.ReadLine();


            double ingredQuantity = NumberInput("Quantity: ");
            double originalQuantities = ingredQuantity; // Store original
            int resp = 1;

            resp = (int)NumberInput("Is there a unit of measurement? (1 - Yes and 0 - No)");

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
            return newIngredient;
        }
        //=======================================================================================================================================================================
        // Method to clear data for a new recipe
        //=======================================================================================================================================================================
        public void clearData()
        {
            int confirmation = (int)NumberInput("Are you sure you want to clear all data? (1 - Yes and 0 - No)");

            if (confirmation == 1)
            {
                // Clear data
                receipe.receipeName = "";
                receipe = null;

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
        }
        private double NumberInput(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(prompt);
                    double response = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                    return response;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.ResetColor();
                }
            }
        }
    }
}
