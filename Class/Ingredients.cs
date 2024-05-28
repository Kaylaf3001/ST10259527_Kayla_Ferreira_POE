using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10259527_Kayla_Ferreira_POE.Class
{
    // Class to represent an ingredient
    public class Ingredients
    {
        //________________________________________________________________________________________________________
        // Member variables to store ingredient details
        //________________________________________________________________________________________________________
        public string ingredientName { get; set; } // Name of the ingredient
        public double ingredientQuantity { get; set; } // Quantity of the ingredient
        public double originalQuantity { get; set; } // Original quantity of the ingredient
        public string unitOfMeasurement { get; set; } // Unit of measurement for the ingredient
        public double calories { get; set; } // Calories in the ingredient
        public string foodGroup { get; set; } // Food group of the ingredient

        //________________________________________________________________________________________________________
        // Constructor for the Ingredients class with unit of measurement
        //________________________________________________________________________________________________________
        public Ingredients(string ingredientName, double ingredientQuantity, double originalQuantity, string unitOfMeasurement, double calories, string foodGroup)
        {
            // Initialize member variables
            this.ingredientName = ingredientName;
            this.ingredientQuantity = ingredientQuantity;
            this.originalQuantity = originalQuantity;
            this.unitOfMeasurement = unitOfMeasurement;
            this.calories = calories;
            this.foodGroup = foodGroup;
        }

        //________________________________________________________________________________________________________
        // Constructor for the Ingredients class without unit of measurement
        //________________________________________________________________________________________________________
        public Ingredients(string ingredientName, double ingredientQuantity, double originalQuantity, double calories, string foodGroup)
        {
            // Initialize member variables
            this.ingredientName = ingredientName;
            this.ingredientQuantity = ingredientQuantity;
            this.originalQuantity = originalQuantity;
            this.unitOfMeasurement = ""; // No unit of measurement
            this.calories = calories;
            this.foodGroup = foodGroup;
        }
        //________________________________________________________________________________________________________
    }
    //________________________________________________________________________________________________________
}

