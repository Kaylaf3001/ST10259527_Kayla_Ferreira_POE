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
        public string receipeName = "";
        public int ingreNo = 0;
        public List<Ingredients> Ingredients { get; set; }
        public List<string> stepDescriptions { get; set; }
        public int repSteps = 0;
        public double scaleNumber = 0;

        public Receipes()
        {
            Ingredients = new List<Ingredients>();
            stepDescriptions = new List<string>();
        }

        //=======================================================================================================================================================================
        // Method to display recipe
        //=======================================================================================================================================================================
        public void displayReceipe()
        {
            Console.WriteLine("\n________________________________________________________________________");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("******* " + receipeName + " *******");
            Console.ResetColor();
            Console.WriteLine("Ingredients: ");
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Ingredients[i].ingredientName}: {Ingredients[i].ingredientQuantity} {Ingredients[i].unitOfMeasurement}");
            }
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < stepDescriptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {stepDescriptions[i]} ");
            }
            Console.WriteLine("________________________________________________________________________\n");
        }
        //=======================================================================================================================================================================
        // Method to scale the recipe up or down
        //=======================================================================================================================================================================
        public void scale(double scaleNumber)
        {
            Console.WriteLine("\n________________________________________________________________________");
            for (int i = 0; i < Ingredients.Count; i++)
            {
                double newQuantity = Ingredients[i].originalQuantity * scaleNumber;
                Console.WriteLine("Old: " + Ingredients[i].ingredientQuantity + " New: " + newQuantity);
                Ingredients[i].ingredientQuantity = newQuantity;
            }
            Console.WriteLine("________________________________________________________________________\n");
            displayReceipe();
        }
        //=======================================================================================================================================================================
        // Method to reset quantities to the original amount input by the user
        //=======================================================================================================================================================================
        public void resetQuantities()
        {
            // Iterate through ingredQuantity and reset each quantity to its original value
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Ingredients[i].ingredientQuantity = Ingredients[i].originalQuantity;
            }
            Console.WriteLine("\nQuantities reverted to original values.");
            displayReceipe();
        }   
        //=======================================================================================================================================================================
        }
    }
