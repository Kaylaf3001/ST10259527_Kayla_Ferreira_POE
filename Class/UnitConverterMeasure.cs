using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10259527_Kayla_Ferreira_POE.Class
{
    internal class UnitConverterMeasure
    {   
        //________________________________________________________________________________________________________
        // Method to convert the unit of measurement
        //________________________________________________________________________________________________________
        public double convertUnitOfMeasurement(double quantity, string unitOfMeasurement, string newUnitOfMeasurement)
        {
            //________________________________________________________________________________________________________
            // Convert the unit of measurement
            //________________________________________________________________________________________________________
            double newQuantity = 0;
            if (unitOfMeasurement == "g" && newUnitOfMeasurement == "kg")
            {
                newQuantity = quantity / 1000;
            }
            else if (unitOfMeasurement == "kg" && newUnitOfMeasurement == "g")
            {
                newQuantity = quantity * 1000;
            }
            else if (unitOfMeasurement == "ml" && newUnitOfMeasurement == "l")
            {
                newQuantity = quantity / 1000;
            }
            else if (unitOfMeasurement == "l" && newUnitOfMeasurement == "ml")
            {
                newQuantity = quantity * 1000;
            }
            else if (unitOfMeasurement == "tsp" && newUnitOfMeasurement == "tbsp")
            {
                newQuantity = quantity / 3;
            }
            else if (unitOfMeasurement == "tbsp" && newUnitOfMeasurement == "tsp")
            {
                newQuantity = quantity * 3;
            }
            else if (unitOfMeasurement == "cup" && newUnitOfMeasurement == "ml")
            {
                newQuantity = quantity * 250;
            }
            else if (unitOfMeasurement == "ml" && newUnitOfMeasurement == "cup")
            {
                newQuantity = quantity / 250;
            }
            else if (unitOfMeasurement == "cup" && newUnitOfMeasurement == "l")
            {
                newQuantity = quantity / 4;
            }
            else if (unitOfMeasurement == "l" && newUnitOfMeasurement == "cup")
            {
                newQuantity = quantity * 4;
            }
            else if (unitOfMeasurement == "g" && newUnitOfMeasurement == "ml")
            {
                newQuantity = quantity;
            }
            else if (unitOfMeasurement == "ml" && newUnitOfMeasurement == "g")
            {
                newQuantity = quantity;
            }
            else if (unitOfMeasurement == "kg" && newUnitOfMeasurement == "l")
            {
                newQuantity = quantity;         
            }
        }

    }
}
