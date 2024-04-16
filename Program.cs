using ST10259527_Kayla_Ferreira_POE.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10259527_Kayla_Ferreira_POE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program worker = new Program();
            worker.Run();
        }
        private void Run()
        {
            Receipes receipe = new Receipes();
            Console.WriteLine("Welcome to the Recipe Application");
            Console.WriteLine("Please select an option");
            Console.WriteLine("1. Add a Recipe");
            Console.WriteLine("2. View Recipe");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Please enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    receipe.nameQuanUnit();// Method to input ingredient names, quantities, and units

                    Console.WriteLine("\nHow many steps are there?");
                    receipe.repSteps = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter a description for each step: ");
                    receipe.steps(); // Method to input instructions on how to make the dish

                    break;
                case 2:
                    
                    receipe.displayReceipe(); // Method to display recipe

                    break;
                case 3:
                    Exit();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
