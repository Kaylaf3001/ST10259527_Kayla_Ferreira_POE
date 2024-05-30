# ST10259527_Kayla_Ferreira_POE
---- Recipe Management System ----

This is a console-based Recipe Management System developed in C#. It allows users to create, display, and manage recipes. Each recipe consists of a list of ingredients and a list of step descriptions. The system also provides functionality to scale the quantity of ingredients up or down, reset quantities to their original values, and calculate the total calories in a recipe.

~ Classes ~
  1. Program.cs
      This is the main class that runs the application. It contains methods for displaying the menu, getting user input, and running the main application loop.
     
  2. Receipes.cs
      This class represents a recipe. It contains properties for the recipe name, number of ingredients, list of ingredients, list of step descriptions, and scale number. It also contains methods for displaying a       recipe, scaling a recipe, resetting quantities, calculating total calories, and checking if a recipe is healthy based on its total calories.
     
  3. Ingredients.cs
      This class represents an ingredient. It contains properties for the ingredient name, quantity, original quantity, unit of measurement, calories, and food group. It has two constructors, one with a unit of         measurement and one without.
     
  4. UnitConverterMeasure.cs
      This class is used to convert the unit of measurement of an ingredient. It contains a method convertUnitOfMeasurement that takes the quantity, current unit of measurement, and new unit of measurement as           parameters, and returns the converted quantity.
     
  5. UnitTest1.cs
      This class contains unit tests for the Receipes class. It tests the totalCalories and totalCalorieCheck methods.

~ How to Get Started ~

- What You Need
  1.	Visual Studio: This is a program that you can use to run and edit the Recipe Management System. You can download it for free from the Visual Studio website.
  2.	A copy of the Recipe Management System: You can get this from a website called GitHub, which is where programmers often store their projects. You'll need to download the project onto your computer.
     
- Steps to Run the Program
  1.	Download and install Visual Studio: Go to the Visual Studio website and follow the instructions to download and install Visual Studio.
  2.	Get the Recipe Management System from GitHub: Open your web browser and go to the GitHub page for the Recipe Management System. Look for a green button that says "Code", click it, and then click "Download           ZIP". Save the ZIP file to your computer, and then extract the files from the ZIP file.
  3.	Open the project in Visual Studio: Look for a file in the extracted files that ends in ".sln". Double-click this file to open the project in Visual Studio.
  4.	Run the program: In Visual Studio, look for a green arrow at the top of the screen that says "Start Debugging", and click it. This will start the program.
     
Once the program is running, you can follow the prompts in the program to create and manage recipes.

- How to Test the Program
The Recipe Management System also includes some tests, which are a way for programmers to check that the program is working correctly. To run the tests, you'll need to:
  1.	Open the Test Explorer in Visual Studio: In Visual Studio, go to the menu at the top of the screen, click "Test", then "Windows", then "Test Explorer".
  2.	Run the tests: In the Test Explorer, click "Run All".
     
If all the tests pass, that means the program is working correctly. If any tests fail, that means there might be a problem with the program.

