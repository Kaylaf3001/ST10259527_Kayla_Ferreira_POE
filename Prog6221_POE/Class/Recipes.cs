using System;
using System.Collections.Generic;

namespace ST10259527_Kayla_Ferreira_POE.Class
{
    // Delegate definition that returns void and takes no parameters
    public delegate bool TotalCaloriesCheckDelegate();

    //--------------------------------------------------------------------------------------------------------
    // Class to represent a recipe
    //--------------------------------------------------------------------------------------------------------
    public class Recipes
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
        public Recipes()
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
                Ingredients[i].calories = Ingredients[i].orignalCalories;
                Ingredients[i].unitOfMeasurement = Ingredients[i].orignalUnitOfMeasurement;
            }
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
        public string totalCalorieMeaning()
        {
            if (totalCalories() > 500)
            {
               
                return "This recipe has a high calorie count, which is not suitable for those on a low-calorie diet.";
            }
            else if (totalCalories() >= 300 && totalCalories() <= 500)
            {
                return "This meal has a moderate calorie content and is healthy.";
            }
            else
            {         
                return "You might want to consider adding some more calories to this meal.";
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
        public static List<Recipes> getDummyRecipes() {

            List<Recipes> dummyRecipes = new List<Recipes>();
           
            //Beef slider recipe
            Recipes BeefSlider = new Recipes { Ingredients = new List<Ingredients>(), stepDescriptions = new List<string>() };
            BeefSlider.receipeName = "Beef Slider";
            BeefSlider.ingreNo = 1;

            string ingredientName = "Ground Beef";
            int ingredientQuantity = 100;
            int originalQuantity = ingredientQuantity;
            string unitOfMeasurement = "g";
            int calories = 200;
            string foodGroup = "Protein";
            
            Ingredients ingredient = new Ingredients(ingredientName, ingredientQuantity, unitOfMeasurement, calories, foodGroup);
            BeefSlider.Ingredients.Add(ingredient);
            BeefSlider.stepDescriptions.Add("1. Cook the beef");
                
            dummyRecipes.Add(BeefSlider);

            //Tomato Pasta recipe
            Recipes tomatoPasta = new Recipes { Ingredients = new List<Ingredients>(), stepDescriptions = new List<string>() };
            tomatoPasta.receipeName = "Tomato Pasta";
            tomatoPasta.ingreNo = 1;

            string ingredientName1 = "Tomato";
            int ingredientQuantity1 = 100;
            int originalQuantity1 = ingredientQuantity;
            string unitOfMeasurement1 = "g";
            int calories1 = 500;
            string foodGroup1 = "Vegetables";

            Ingredients ingredient1 = new Ingredients(ingredientName1, ingredientQuantity1, unitOfMeasurement1, calories1, foodGroup1);
            tomatoPasta.Ingredients.Add(ingredient1);
            tomatoPasta.stepDescriptions.Add("1. Cook pasta");

            dummyRecipes.Add(tomatoPasta);

            //Simple Green Salad recipe
            Recipes SimpleGreenSalad = new Recipes { Ingredients = new List<Ingredients>(), stepDescriptions = new List<string>() };
            SimpleGreenSalad.receipeName = "Simple Green Salad";
            SimpleGreenSalad.ingreNo = 1;

            string ingredientName2 = "Mixed greens";
            int ingredientQuantity2 = 240;
            int originalQuantity2 = ingredientQuantity;
            string unitOfMeasurement2 = "g";
            int calories2 = 200;
            string foodGroup2 = "Vegetables";

            Ingredients ingredient2 = new Ingredients(ingredientName2, ingredientQuantity2, unitOfMeasurement2, calories2, foodGroup2);
            SimpleGreenSalad.Ingredients.Add(ingredient2);
            SimpleGreenSalad.stepDescriptions.Add("1. In a large bowl, combine the mixed greens, cucumber, cherry tomatoes, and red onion.");

            dummyRecipes.Add(SimpleGreenSalad);

            //Pancakes
            Recipes Pancakes = new Recipes { Ingredients = new List<Ingredients>(), stepDescriptions = new List<string>() };
            Pancakes.receipeName = "Pancakes";
            Pancakes.ingreNo = 1;

            string ingredientName3 = "Butter";
            int ingredientQuantity3 = 240;
            int originalQuantity3 = ingredientQuantity;
            string unitOfMeasurement3 = "ml";
            int calories3 = 400;
            string foodGroup3 = "Dairy";

            Ingredients ingredient3 = new Ingredients(ingredientName3, ingredientQuantity3, unitOfMeasurement3, calories3, foodGroup3);
            Pancakes.Ingredients.Add(ingredient3);
            Pancakes.stepDescriptions.Add("1. In a large bowl, whisk together the flour, sugar, baking powder, baking soda, and salt.");

            dummyRecipes.Add(Pancakes);

            //Grilled Cheese Sandwich recipe
            Recipes GrilledCheeseSandwich = new Recipes { Ingredients = new List<Ingredients>(), stepDescriptions = new List<string>() };
            GrilledCheeseSandwich.receipeName = "Grilled Cheese Sandwich";
            GrilledCheeseSandwich.ingreNo = 1;

            string ingredientName4 = "Cheese";
            int ingredientQuantity4 = 60;
            int originalQuantity4 = ingredientQuantity;
            string unitOfMeasurement4 = "g";
            int calories4 = 250;
            string foodGroup4 = "Dairy";

            Ingredients ingredient4 = new Ingredients(ingredientName4, ingredientQuantity4, unitOfMeasurement4, calories4, foodGroup4);
            GrilledCheeseSandwich.Ingredients.Add(ingredient4);
            GrilledCheeseSandwich.stepDescriptions.Add("1. Heat a skillet over medium heat.");

            dummyRecipes.Add(GrilledCheeseSandwich);

            //Chicken Stir Fry recipe
            Recipes ChickenStirFry = new Recipes { Ingredients = new List<Ingredients>(), stepDescriptions = new List<string>() };
            ChickenStirFry.receipeName = "Chicken Stir Fry";
            ChickenStirFry.ingreNo = 1;

            string ingredientName5 = "Chicken";
            int ingredientQuantity5 = 100;
            int originalQuantity5 = ingredientQuantity;
            string unitOfMeasurement5 = "g";
            int calories5 = 500;
            string foodGroup5 = "Protein";

            Ingredients ingredient5 = new Ingredients(ingredientName5, ingredientQuantity5, unitOfMeasurement5, calories5, foodGroup5);
            ChickenStirFry.Ingredients.Add(ingredient5);
            ChickenStirFry.stepDescriptions.Add("1. Cook the Chicken");

            dummyRecipes.Add(ChickenStirFry);

            //Caprese Salad recipe
            Recipes CapreseSalad = new Recipes { Ingredients = new List<Ingredients>(), stepDescriptions = new List<string>() };
            CapreseSalad.receipeName = "Caprese Salad";
            CapreseSalad.ingreNo = 1;

            string ingredientName6 = "Tomato";
            int ingredientQuantity6 = 100;
            int originalQuantity6 = ingredientQuantity;
            string unitOfMeasurement6 = "g";
            int calories6 = 500;
            string foodGroup6 = "Vegetables";

            Ingredients ingredient6 = new Ingredients(ingredientName6, ingredientQuantity6, unitOfMeasurement6, calories6, foodGroup6);
            CapreseSalad.Ingredients.Add(ingredient6);
            CapreseSalad.stepDescriptions.Add("1. Make Salad");

            dummyRecipes.Add(CapreseSalad);

            //Beef Tacos recipes
            Recipes BeefTacos = new Recipes { Ingredients = new List<Ingredients>(), stepDescriptions = new List<string>() };
            BeefTacos.receipeName = "Beef Tacos";
            BeefTacos.ingreNo = 1;

            string ingredientName7 = "Beef";
            int ingredientQuantity7 = 240;
            int originalQuantity7 = ingredientQuantity;
            string unitOfMeasurement7 = "g";
            int calories7 = 200;
            string foodGroup7 = "Protein";

            Ingredients ingredient7 = new Ingredients(ingredientName7, ingredientQuantity7, unitOfMeasurement7, calories7, foodGroup7);
            BeefTacos.Ingredients.Add(ingredient7);
            BeefTacos.stepDescriptions.Add("1.Cook ground beef in a skillet over medium heat until browned and cooked through.");

            dummyRecipes.Add(BeefTacos);

            //Fruit Smoothie recipe
            Recipes FruitSmoothie = new Recipes { Ingredients = new List<Ingredients>(), stepDescriptions = new List<string>() };
            FruitSmoothie.receipeName = "Fruit Smoothie";
            FruitSmoothie.ingreNo = 1;

            string ingredientName8 = "Butter";
            int ingredientQuantity8 = 240;
            int originalQuantity8 = ingredientQuantity;
            string unitOfMeasurement8 = "ml";
            int calories8 = 400;
            string foodGroup8 = "Dairy";

            Ingredients ingredient8 = new Ingredients(ingredientName8, ingredientQuantity8, unitOfMeasurement8, calories8, foodGroup8);
            FruitSmoothie.Ingredients.Add(ingredient8);
            FruitSmoothie.stepDescriptions.Add("1. Place banana slices, strawberries, blueberries, plain yogurt, honey (if using), and orange juice in a blender.");

            dummyRecipes.Add(FruitSmoothie);
 
            return dummyRecipes;
        }
    }
}