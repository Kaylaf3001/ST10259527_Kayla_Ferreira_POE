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
        public (double,string) convertUnitOfMeasurement(double quantity, string unitOfMeasurement)
        {
            //________________________________________________________________________________________________________
            // Convert the unit of measurement
            //________________________________________________________________________________________________________
            double newQuantity = quantity;
            string newUnitOfMeasurement = unitOfMeasurement;
            if (unitOfMeasurement == "g" && quantity >= 1000)
            {
                newQuantity = quantity / 1000;
                newUnitOfMeasurement = "kg";
            }
            else if (unitOfMeasurement == "kg" && quantity < 1)
            {
                newQuantity = quantity * 1000;
                newUnitOfMeasurement = "g";
            }
            else if (unitOfMeasurement == "ml" && quantity >= 1000)
            {
                newQuantity = quantity / 1000;
                newUnitOfMeasurement = "l";
            }
            else if (unitOfMeasurement == "l" && quantity < 1)
            {
                newQuantity = quantity * 1000;
                newUnitOfMeasurement = "ml";
            }
            else if (unitOfMeasurement == "tsp" && quantity >= 3)
            {
                newQuantity = quantity / 3;
                newUnitOfMeasurement = "tbsp";
            }
            else if (unitOfMeasurement == "tbsp" && quantity >= 16)
            {
                newQuantity = quantity / 16;
                newUnitOfMeasurement = "cup";
                
            }
            else if (unitOfMeasurement == "tbsp" && quantity < 0.3333)
            {
                newQuantity = quantity * 3;
                newUnitOfMeasurement = "tsp";
            }
            else if (unitOfMeasurement == "cup" && quantity < 1)
            {
                newQuantity = quantity / 0.0625;
                newUnitOfMeasurement = "tbsp";
            }
           
           return (newQuantity, newUnitOfMeasurement);
        }
        
    }
}
