using ST10259527_Kayla_Ferreira_POE.Class;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ST10259527_Kayla_Ferreira_POE
{   //Kayla Ferreira
    //ST10259527 - Group 2

    //Reference List
    //https://www.w3schools.com/
    //https://www.youtube.com/@BroCodez

    //=============================================================================================================
    // The main class of the application
    //=============================================================================================================
    internal class Program
    {
        // Instance of the Receipes class
        Receipes receipe;
        // Instance of the Receipes class
        List<Receipes> allReceipes = new List<Receipes>();


        // The main entry point of the application
        static void Main(string[] args)
        {
            // Create an instance of the Program class and run the application
            Program worker = new Program();
            worker.Run();
        }
        //=============================================================================================================
        // The main loop of the application
        //=============================================================================================================
        private void Run()
        {
            // Flag to control the main loop
            bool exit = false;

            // Main loop
            while (true)
            {
                try
                {
                    // Set console color and print welcome message
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Welcome to the Recipe Application!!");
                    Console.WriteLine("________________________________________________________________________");
                    Console.ResetColor();

                    // Print menu options
                    Console.WriteLine("Please select an option");
                    Console.WriteLine("1. Add a Recipe");
                    Console.WriteLine("2. View All Receipes");
                    Console.WriteLine("3. Exit");
                    Console.Write("Please enter your choice: ");

                    // Get user choice
                    int choice = Convert.ToInt32(Console.ReadLine());

                    // Process user choice
                    switch (choice)
                    {
                        case 1:
                            // User chose to add a recipe
                            receipe = UserGetsReceipe();
                            break;

                        case 2:
                            // User chose to view all recipes in alphabetical order
                            alaphabeticalOrder();
                            int resp = (int)NumberInput("Would you like to view a recipe? (1 - Yes and 0 - No)\n");
                            if (resp == 1)
                            {
                                Console.WriteLine("Enter the name of the recipe you want to view:");
                                string recipeName = Console.ReadLine();
                                Receipes recipeToView = allReceipes.FirstOrDefault(r => r.receipeName == recipeName);
                                if (recipeToView != null)
                                {
                                    recipeToView.displayReceipe();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Recipe not found.");
                                    Console.ResetColor();
                                }
                            }
                            break;
                        case 3:
                            // User chose to exit the application
                            Console.WriteLine("Exiting the Recipe Application...");
                            Environment.Exit(0); // Terminate the program immediately
                            break;

                        default:
                            // User entered an invalid choice
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // An error occurred, print error message
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"An error occurred. Please re-enter");
                    Console.ResetColor();
                }
            }
        }
        //=============================================================================================================
        // Method to create and get a recipe from the user
        //=============================================================================================================
        private Receipes UserGetsReceipe()
        {

            // Create a new recipe
            Receipes tempReceipe = new Receipes();
            try
            {
                // Get recipe name from the user
                Console.WriteLine("What is the name of the recipe?");
                tempReceipe.receipeName = Console.ReadLine();

                // Get number of ingredients from the user
                tempReceipe.ingreNo = (int)NumberInput("\nHow many Ingredients does your recipe have?\n");

                // Get ingredients from the user
                Console.WriteLine("\nName, Quantity, Calories and Food Group:");
                for (int i = 0; i < tempReceipe.ingreNo; i++)
                {
                    Ingredients newIngredient = UserGetsIngredient(i);
                    tempReceipe.Ingredients.Add(newIngredient);

                    // Call the delegate to check total calories after each ingredient is added
                    tempReceipe.totalCaloriesCheckDelegate();
                }


                // Get number of steps from the user
                tempReceipe.repSteps = (int)NumberInput("\nHow many steps are there?\n");
                Console.WriteLine("Please enter a description for each step: ");

                // Get steps from the user
                Console.WriteLine("________________________________________________________________________");
                for (int i = 0; i < tempReceipe.repSteps; i++)
                {
                    Console.WriteLine($"Step {i + 1}: ");
                    tempReceipe.stepDescriptions.Add(Console.ReadLine());
                }
                Console.WriteLine("________________________________________________________________________\n");

                Console.Write("Total Calories: " + tempReceipe.totalCalories() + "\n");
                tempReceipe.totalCaloriesCheckDelegate();
                Console.WriteLine("________________________________________________________________________\n");
                allReceipes.Add(tempReceipe);


            }
            catch (Exception ex)
            {
                // An error occurred, print error message
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }

            // Return the created recipe
            return tempReceipe;
        }

        //=============================================================================================================
        // Method to get an ingredient from the user
        //=============================================================================================================
        private Ingredients UserGetsIngredient(int i)
        {
            // Get ingredient name from the user
            Console.WriteLine($"Ingredient {i + 1}:");
            Console.Write("Name: ");
            string ingredientNames = Console.ReadLine();

            //Input food group
            Console.Write("Food Group: ");
            string foodGroup = Console.ReadLine();

            // Get calories from the user
            Console.Write("Calories: ");
            double calories = Convert.ToDouble(Console.ReadLine());


            // Get ingredient quantity from the user
            double ingredQuantity = NumberInput("Quantity: ");
            double originalQuantities = ingredQuantity;

            // Ask user if there is a unit of measurement
            int resp = (int)NumberInput("Is there a unit of measurement? (1 - Yes and 0 - No)\n");

            // Create a new ingredient
            Ingredients newIngredient;
            if (resp == 1)
            {
                // Get unit of measurement from the user
                Console.WriteLine("What is the unit of measurement?");
                string unitOfMeasurement = Console.ReadLine();
                newIngredient = new Ingredients(ingredientNames, ingredQuantity, originalQuantities, unitOfMeasurement, calories, foodGroup);
            }
            else
            {
                newIngredient = new Ingredients(ingredientNames, ingredQuantity, originalQuantities,calories,foodGroup);
            }

            // Return the created ingredient
            return newIngredient;
        }

        ////=============================================================================================================
        // Method to clear data for a new recipe
        ////=============================================================================================================
        public void clearData()
        {
            // Ask user for confirmation
            int confirmation = (int)NumberInput("Are you sure you want to clear all data? (1 - Yes and 0 - No)\n");

            if (confirmation == 1)
            {
                // Clear data
                receipe.receipeName = "";
                receipe = null;

                // Print success message
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Data cleared successfully.");
                Console.ResetColor();
            }
            else
            {
                // Print message that data was not cleared
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Data not cleared.");
                Console.ResetColor();
            }
        }
        //=============================================================================================================
        // Method to get a number input from the user
        //=============================================================================================================
        private double NumberInput(string prompt)
        {
            while (true)
            {
                try
                {
                    // Print prompt and get input from the user
                    Console.Write(prompt);
                    double response = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
                    return response;
                }
                catch (FormatException)
                {
                    // Input was not a valid number, print error message
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.ResetColor();
                }
            }
        }
        //=============================================================================================================
        // Method to display the recipe and ask user if they want to scale the recipe
        //=============================================================================================================
        private void UserInputDisplay()
        {
            // Display the recipe
            if (receipe == null)
            {
                // No recipe has been added yet
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No recipe has been added yet.");
                Console.ResetColor();
                return;
            }else
            {
                receipe.displayReceipe();
            }
            
            // Ask user if they want to scale the recipe
            int response2 = (int)NumberInput("Would you like to change the scale of your recipe? (1 - Yes, 0 - No)\n");
            if (response2 == 1)
            {
                double scaleNumber = NumberInput("What would you like to scale it to?\n");
                receipe.scale(scaleNumber);
            }

            // Ask user if they want to reset the quantities
            int response3 = (int)NumberInput("Would you like to revert back to the original quantities? (1 - Yes, 0 - No)\n");
            if (response3 == 1)
            {
                receipe.resetQuantities();
            }

            // Ask user if they want to clear the data for a new recipe
            int response4 = (int)NumberInput("Would you like to clear the data for a new recipe?(1 - Yes, 0 - No)\n");
            if (response4 == 1)
            {
                clearData();
            }
        }
        //============================================================================================================
        public void alaphabeticalOrder()
        {
            allReceipes.Sort((x, y) => string.Compare(x.receipeName, y.receipeName));
            foreach (var item in allReceipes)
            {
                Console.WriteLine(item.receipeName);
            }
        }
        //=============================================================================================================
    }
    //=============================================================================================================
}
