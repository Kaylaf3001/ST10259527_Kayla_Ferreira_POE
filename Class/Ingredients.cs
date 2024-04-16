using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10259527_Kayla_Ferreira_POE.Class
{
    internal class Ingredients
    {
        public string ingredientName { get; set;}  
        public double ingredientQuantity { get; set; }
        public double originalQuantity { get; set; }
        public string unitOfMeasurement { get; set; }


        public Ingredients(string ingredientName, double ingredientQuantity, double originalQuantity, string unitOfMeasurement)
        {
            this.ingredientName = ingredientName;
            this.ingredientQuantity = ingredientQuantity;
            this.originalQuantity = originalQuantity;
            this.unitOfMeasurement = unitOfMeasurement;
        }
        public Ingredients(string ingredientName, double ingredientQuantity, double originalQuantity)
        {
            this.ingredientName = ingredientName;
            this.ingredientQuantity = ingredientQuantity;
            this.originalQuantity = originalQuantity;
            this.unitOfMeasurement = "";
        }
        }
}
