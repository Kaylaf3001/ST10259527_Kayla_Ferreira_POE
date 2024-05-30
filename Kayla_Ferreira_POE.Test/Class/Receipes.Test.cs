using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST10259527_Kayla_Ferreira_POE.Class;
using System;

namespace Kayla_Ferreira_POE.Test
{
    [TestClass]
    public class ReceipesTest
    {
        // Test the totalCalories method for a null recipe
        //--------------------------------------------------------------------------------------------------------
        [TestMethod]
        public void TestTotalCaloriesForNull()
        {
            // Arrange
            Receipes receipe = new Receipes();

            // Act
            double totalCalories = receipe.totalCalories();

            // Assert
            Assert.AreEqual(0, totalCalories);
        }
        //--------------------------------------------------------------------------------------------------------
        // Test the totalCalories method for a recipe over 1000 calories
        //--------------------------------------------------------------------------------------------------------
        [TestMethod]
        public void TestTotalCalorieCheckForFalse()
        {
            // Arrange
            Receipes receipe = new Receipes();
            // Add some ingredients to the recipe
            receipe.Ingredients.Add(new Ingredients("Eggs", 1, 1, 100, "Protein"));
            receipe.Ingredients.Add(new Ingredients("Bread", 2, 2, 200, "Starch"));
            receipe.Ingredients.Add(new Ingredients("Butter", 1, 1, 100, "Fats"));

            // Act
            bool overThree = receipe.totalCalorieCheck();

            // Assert
            Assert.IsFalse(overThree);
        }
        //--------------------------------------------------------------------------------------------------------
        // Test the totalCalories method for a recipe below 300 calories
        //--------------------------------------------------------------------------------------------------------
        [TestMethod]
        public void TestTotalCalorieCheckForHealthyRecipe()
        {
            // Arrange
            Receipes receipe = new Receipes();
            // Add some ingredients to the recipe
            receipe.Ingredients.Add(new Ingredients("Eggs", 1, 1, 100, "Protein")); // Low calorie ingredient
            receipe.Ingredients.Add(new Ingredients("Bread", 2, 2, 100, "Starch")); // Low calorie ingredient
            receipe.Ingredients.Add(new Ingredients("Butter", 1, 1, 50, "Fats")); // Low calorie ingredient

            // Act
            bool belowThree = receipe.totalCalorieCheck();

            // Assert
            Assert.IsTrue(belowThree); // The recipe is healthy because it has low calorie ingredients
        }
        //--------------------------------------------------------------------------------------------------------
    }
}
