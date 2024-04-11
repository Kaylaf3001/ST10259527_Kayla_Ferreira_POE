﻿using System;
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
        }
        //============================================================================================
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
    }
}
