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
        // List to store all recipes
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
            // Main loop
            while (true)
            {
                try
                {
                    // Display menu options
                    DisplayMenu();
                    // Get user choice
                    int choice = (int)NumberInput("Please enter your choice: ");

                    // Process user choice
                    switch (choice)
                    {
                        case 1:
                            // User chose to add a recipe
                            receipe = UserGetsReceipe();
                            break;
                        case 2:
                            // User chose to view all recipes
                            alaphabeticalOrder();
                            break;
                        case 3:
                            // User chose to exit the application
                            Console.WriteLine("Exiting the Recipe Application...");
                            Environment.Exit(0);
                            break;
                        default:
                            // Invalid choice
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // An error occurred
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An error occurred. Please try again.");
                    Console.ResetColor();
                }
            }
        }
        //=============================================================================================================
        // Display menu options
        //=============================================================================================================
        private void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Welcome to the Recipe Application!!");
            Console.WriteLine("________________________________________________________________________");
            Console.ResetColor();
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Add a Recipe");
            Console.WriteLine("2. View All Recipes");
            Console.WriteLine("3. Exit");
            Console.WriteLine("________________________________________________________________________");

        }
        //=============================================================================================================
        // Method to create and get a recipe from the user
        //=============================================================================================================
        private Receipes UserGetsReceipe()
        {
            Receipes tempReceipe = new Receipes();
            try
            {
                Console.WriteLine("What is the name of the recipe?");
                tempReceipe.receipeName = Console.ReadLine();

                tempReceipe.ingreNo = (int)NumberInput("How many ingredients does your recipe have? ");
                Console.WriteLine("Name, Quantity, Calories and Food Group:");
                for (int i = 0; i < tempReceipe.ingreNo; i++)
                {
                    Ingredients newIngredient = UserGetsIngredient(i);
                    tempReceipe.Ingredients.Add(newIngredient);
                    tempReceipe.totalCaloriesCheckDelegate();
                }

                tempReceipe.repSteps = (int)NumberInput("How many steps are there? ");
                Console.WriteLine("Please enter a description for each step:");
                Console.WriteLine("________________________________________________________________________");
                for (int i = 0; i < tempReceipe.repSteps; i++)
                {
                    Console.WriteLine($"Step {i + 1}: ");
                    tempReceipe.stepDescriptions.Add(Console.ReadLine());
                }

                Console.WriteLine("________________________________________________________________________");
                Console.WriteLine("Total Calories: " + tempReceipe.totalCalories());
                tempReceipe.totalCaloriesCheckDelegate();
                Console.WriteLine("________________________________________________________________________");

                allReceipes.Add(tempReceipe);
                receipe = tempReceipe;
                UserInputDisplay();

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            return tempReceipe;
        }

        //=============================================================================================================
        // Method to get an ingredient from the user
        //=============================================================================================================
        private Ingredients UserGetsIngredient(int i)
        {
            Console.WriteLine($"Ingredient {i + 1}:");
            Console.Write("Name: ");
            string ingredientName = Console.ReadLine();

            double ingredientQuantity = NumberInput("Quantity: ");
            double originalQuantity = ingredientQuantity;

            Console.Write("Calories: ");
            double calories = double.Parse(Console.ReadLine());

            Console.WriteLine("Food Group:");
            Console.WriteLine("1. Fruits");
            Console.WriteLine("2. Vegetables");
            Console.WriteLine("3. Grains");
            Console.WriteLine("4. Proteins");
            Console.WriteLine("5. Dairy");
            Console.WriteLine("6. Fats and Oils");
            Console.Write("Select the food group (1-6): ");
            int foodGroupIndex = int.Parse(Console.ReadLine());
            string foodGroup = "";
            switch (foodGroupIndex)
            {
                case 1:
                    foodGroup = "Fruits";
                    break;
                case 2:
                    foodGroup = "Vegetables";
                    break;
                case 3:
                    foodGroup = "Grains";
                    break;
                case 4:
                    foodGroup = "Proteins";
                    break;
                case 5:
                    foodGroup = "Dairy";
                    break;
                case 6:
                    foodGroup = "Fats and Oils";
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid food group selection. Defaulting to Other.");
                    Console.ResetColor();
                    foodGroup = "Other";
                    break;
            }

            int hasUnitOfMeasurement = (int)NumberInput("Is there a unit of measurement? (1 - Yes, 0 - No)\n");

            Ingredients newIngredient;
            if (hasUnitOfMeasurement == 1)
            {
                Console.WriteLine("What is the unit of measurement?");
                string unitOfMeasurement = Console.ReadLine();
                newIngredient = new Ingredients(ingredientName, ingredientQuantity, originalQuantity, unitOfMeasurement, calories, foodGroup);
            }
            else
            {
                newIngredient = new Ingredients(ingredientName, ingredientQuantity, originalQuantity, calories, foodGroup);
            }
            return newIngredient;
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
            
        }
        //============================================================================================================
        public void alaphabeticalOrder()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("________________________________________________________________________");
            Console.WriteLine($"******* Cook Book *******");
            Console.ResetColor();

            allReceipes.Sort((x, y) => string.Compare(x.receipeName, y.receipeName));
            foreach (var item in allReceipes)
            {
                Console.WriteLine(item.receipeName);
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("________________________________________________________________________\n");
            Console.ResetColor();

            int viewResponse = (int)NumberInput("Would you like to view a recipe? (1 - Yes, 0 - No)\n");
            if (viewResponse == 1)
            {
                Console.WriteLine("Enter the name of the recipe you want to view:");
                string recipeName = Console.ReadLine();
                Receipes recipeToView = allReceipes.FirstOrDefault(r => r.receipeName == recipeName);
                if (recipeToView != null)
                {

                    recipeToView.displayReceipe();

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
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Recipe not found.");
                    Console.ResetColor();
                }
            }
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
                receipe = new Receipes(); // Create a new instance of Receipes

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
    }
    //=============================================================================================================
}
