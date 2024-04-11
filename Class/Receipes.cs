using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10259527_Kayla_Ferreira_POE.Class
{
    internal class Receipes
    {
        private string receipeName = "";
        private string[] ingredientNames = { };
        private string[] stepDescriptions = { };
        private double[] ingredQuantity = { };
        private double[] originalQuantities = { };
        private double scaleNumber = 0;
        private string[] unitOfMeasurement = { };
        private int repSteps = 0;
        private int ingreNo = 0;
        public void userInput()
        {

            Console.WriteLine("What is the name of the recipe?");
            receipeName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("How many Ingredients does your recipe have?");
            ingreNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            // Arrays to store the data
            ingredientNames = new string[ingreNo];
            ingredQuantity = new double[ingreNo];
            originalQuantities = new double[ingreNo];
            unitOfMeasurement = new string[ingreNo];

            Console.WriteLine("Name and Quantity of your ingredients:");
            nameQuanUnit();

            Console.WriteLine();
            Console.WriteLine("How many steps are there?");
            repSteps = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("******************************************************************************");
            Console.WriteLine();
            Console.WriteLine("Please enter a description for each step: ");
            steps();
            Console.WriteLine("******************************************************************************");
            Console.WriteLine();

            Console.WriteLine("Would you like to view the recipe? (1 - Yes and 0 - No)");
            int response = Convert.ToInt32(Console.ReadLine());

            if (response == 1)
            {
                displayReceipe();
            }

            Console.WriteLine("Would you like to change the scale of your recipe? (1 - Yes, 0 - No)");
            int response2 = Convert.ToInt32(Console.ReadLine());

            if (response2 == 1)
            {
                Console.WriteLine("What would you like to scale down to?");
                string scaleInput = Console.ReadLine();
                scaleNumber = double.Parse(scaleInput, System.Globalization.CultureInfo.InvariantCulture);
                scale();
            }

            Console.WriteLine("Would you like to revert back to the orginal quantities? (1 - Yes, 0 - No)");
            int response3 = Convert.ToInt32(Console.ReadLine());

            if (response3 == 1)
            {
                resetQuantities();
            }

            Console.WriteLine("Would you like to clear the data for a new receipe?(1 - Yes, 0 - No)");
            int response4 = Convert.ToInt32(Console.ReadLine());

            if (response2 == 1)
            {
                Console.WriteLine();
                Console.WriteLine("Data cleared");
                clearData();
            }
        }
        //========================================================================================================
        // Input ingredient names, quantities, and units
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

            }
        }
        //========================================================================================================
        // Input instructions on how to make the dish.
        public void steps()
        {
            stepDescriptions = new string[repSteps];
            for (int i = 0; i < repSteps; i++)
            {
                Console.WriteLine($"Step {i + 1}: ");
                stepDescriptions[i] = Console.ReadLine();
                Console.WriteLine();
            }
        }
        //========================================================================================================
        // Display recipe
        public void displayReceipe()
        {
            Console.WriteLine("******************************************************************************");
            Console.WriteLine("Receipe name: " + receipeName);
            Console.WriteLine();
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < ingredientNames.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {ingredientNames[i]}: {ingredQuantity[i]} {unitOfMeasurement[i]}");
            }
            Console.WriteLine();
            Console.WriteLine("Steps:");
            for (int i = 0; i < stepDescriptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {stepDescriptions[i]} ");
            }
            Console.WriteLine("******************************************************************************");
        }
        //========================================================================================================
        // Scale the recipe up or down.
        public void scale()
        {
            for (int i = 0; i < ingredQuantity.Length; i++)
            {
                double newQuantity = originalQuantities[i] * scaleNumber;
                Console.WriteLine("Old: " + ingredQuantity[i] + " New: " + newQuantity);
                ingredQuantity[i] = newQuantity;
            }
            displayReceipe();
        }

        //========================================================================================================
        // Reset quantities to the orginal amount that was inputed by the user.
        public void resetQuantities()
        {
            // Iterate through ingredQuantity and reset each quantity to its original value
            for (int i = 0; i < ingredQuantity.Length; i++)
            {
                ingredQuantity[i] = originalQuantities[i];
            }
            Console.WriteLine("Quantities reverted to original values.");
            displayReceipe();
        }
        //========================================================================================================
        // Clear data for new recipe
        public void clearData()
        {
            receipeName = "";
            ingredientNames = new string[] { };
            stepDescriptions = new string[] { };
            ingredQuantity = new double[] { };
            originalQuantities = new double[] { };
            scaleNumber = 0;
            unitOfMeasurement = new string[] { };

            userInput();
        }
        //========================================================================================================
    }
}
