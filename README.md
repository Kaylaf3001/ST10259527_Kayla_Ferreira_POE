# ST10259527_Kayla_Ferreira_POE
## Recipe Management System

This is a console-based Recipe Management System developed in C#. It allows users to create, display, and manage recipes. Each recipe consists of a list of ingredients and a list of step descriptions. The system also provides functionality to scale the quantity of ingredients up or down, reset quantities to their original values, and calculate the total calories in a recipe.

## Classes 
  1. Program.cs
      This is the main class that runs the application. It contains methods for displaying the menu, getting user input, and running the main application loop.
     
  2. Receipes.cs
      This class represents a recipe. It contains properties for the recipe name, number of ingredients, list of ingredients, list of step descriptions, and scale number. It also contains methods for displaying a recipe, scaling a recipe, resetting quantities, calculating total calories, and checking if a recipe is healthy based on its total calories.
     
  3. Ingredients.cs
      This class represents an ingredient. It contains properties for the ingredient name, quantity, original quantity, unit of measurement, calories, and food group. It has two constructors, one with a unit of measurement and one without.
     
  4. UnitConverterMeasure.cs
      This class is used to convert the unit of measurement of an ingredient. It contains a method `convertUnitOfMeasurement` that takes the quantity, current unit of measurement, and new unit of measurement as parameters, and returns the converted quantity.
     
  5. UnitTest1.cs
      This class contains unit tests for the Recipes class. It tests the `totalCalories` and `totalCalorieCheck` methods.
     
  6. **New Implementations**
      - **WPF Implementation:** Introduced a new WPF interface that organizes all previous components into a user-friendly UI format. The WPF version enhances user experience with interactive controls for recipe management.
      - **Recipe Filtering Feature:** Added a new feature to easily filter through all available recipes based on criteria such as name, ingredients, or dietary preferences.

## How to Get Started 

- What You Need
 1. Visual Studio: This is a program that you can use to run and edit the Recipe Management System. You can download it for free from the Visual Studio website.
 2. A copy of the Recipe Management System: You can get this from a website called GitHub, which is where programmers often store their projects. You'll need to download the project onto your computer.

## Steps to Run the Program

Download and install Visual Studio:
- Go to the Visual Studio website and follow the instructions to download and install Visual Studio.
- Get the Recipe Management System from GitHub:

Open your web browser and go to the GitHub page for the Recipe Management System.
- Look for a green button that says "Code", click it, and then click "Download ZIP".
- Save the ZIP file to your computer, and then extract the files from the ZIP file.

Open the project in Visual Studio:
- Look for a file in the extracted files that ends in ".sln".
- Double-click this file to open the project in Visual Studio.

Setting Up the Project:
- After cloning the repository, you may need to set the WPF project as the startup project in Visual Studio. To do this:
  - Open the solution in Visual Studio.
  - In the Solution Explorer, right-click on the WPF project (e.g., MyWpfApp).
    
Select 'Set as Startup Project'.
- Now, you can run the solution, and the WPF application will start.

- How to Test the Program
The Recipe Management System also includes some tests, which are a way for programmers to check that the program is working correctly. To run the tests, you'll need to:
  1. Open the Test Explorer in Visual Studio: In Visual Studio, go to the menu at the top of the screen, click "Test", then "Windows", then "Test Explorer".
  2. Run the tests: In the Test Explorer, click "Run All".
     
If all the tests pass, that means the program is working correctly. If any tests fail, that means there might be a problem with the program.

# Version Notes
## Version 1.0.0 - Initial Release 
This is the first release of the recipe management progam.
#### Features:
- User Input: Implemented functionality for users to input recipe details.
- Users can enter the number of ingredients and their details (name, quantity, and unit of measurement).
- Users can enter the number of steps and their descriptions.
- Recipe Display: Added feature to display the full recipe, including ingredients and steps, in a formatted manner.
- Recipe Scaling: Introduced recipe scaling functionality.
- Users can scale ingredient quantities by 0.5 (half), 2 (double), or 3 (triple).
- Quantity Reset: Added ability to reset ingredient quantities to their original values.
- Data Clearing: Implemented feature to clear all data and enter a new recipe.
- Volatile Data Storage: Ensured that user data is only stored in memory while the software is running and not persisted between sessions.

#### Non-Functional Requirements:
- Followed internationally acceptable coding standards.
- Included comprehensive comments explaining variable names, methods, and programming logic.
- Utilized classes for object-oriented design.
- Stored ingredients and steps in arrays.
  
## Version 2.0.0 - Advanced Features Update
#### New Features:
- Multiple Recipes: Users can now enter and manage an unlimited number of recipes.
- Each recipe can have a unique name.
- Recipe Listing: Implemented a feature to display all recipes in alphabetical order by name.
- Users can choose and display a specific recipe from this list.
- Enhanced Ingredient Details: For each ingredient, users can now enter:
  - The number of calories.
  - The food group to which the ingredient belongs.
  - Total Calories Calculation: The software now calculates and displays the total calories for all ingredients in a recipe.
- A notification is displayed if the total calories exceed 300.

#### Improvements:
- Generic Collections: Replaced arrays with generic collections to store recipes, ingredients, and steps.
- Delegates: Added a delegate to notify users when the total calories of a recipe exceed 300.
- Bug Fixes and Refactoring:
  
#### Testing:
- Added unit tests to verify the total calorie calculation functionality.

#### Non-Functional Requirements:
- Continued adherence to internationally acceptable coding standards.
- Ensured the application maintains a high level of user experience and performance.

### Implemented Lecturer feedback from Part 1:
- Improved exception handling
- Ensured comprehensive comments are included for variable names, methods, and the logic of programming code.

## Version 3.0.0 - Graphical User Interface Update 
#### New Features:
- Graphical User Interface (GUI): Transitioned from a command-line interface to a Windows Presentation Foundation (WPF) based GUI for a more user-friendly experience.
- Utilized Extensible Application Markup Language (XAML) to create the graphical user interfaces.
- Implemented various controls to enhance user interaction and data input.
- Integrated graphics rendering services to visually display data.
- Recipe Filtering: Added functionality to filter the list of recipes based on user criteria.
- Users can filter recipes by entering the name of an ingredient, choosing a food group, or selecting a maximum number of calories.
  
#### Improvements:
- Styles and Themes: Applied consistent styles throughout the application to improve aesthetics and usability.
- Enhanced Data Display: Improved the display of recipe details with graphical views and better formatting.

#### Non-Functional Requirements:
- Continued adherence to internationally acceptable coding standards.
- Maintained comprehensive comments explaining variable names, methods, and the logic of programming code.
  
### Implemented Lecturer feedback from Part 2:
- Enhanced performance and responsiveness of the application.
- Improved my readMe structure.

