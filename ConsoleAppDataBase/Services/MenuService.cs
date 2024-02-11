using System;

namespace ConsoleAppDataBase.Services
{
    internal class MenuService
    {
        private readonly ConsoleUI _consoleUI;

        public MenuService(ConsoleUI consoleUI)
        {
            _consoleUI = consoleUI;
        }

        public void ShowMenu()
        {
            while (true) // Continuous loop until user chooses to exit
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Product Management System");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Show Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Exit");

                Console.WriteLine("Choose an option:");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _consoleUI.AddProduct();
                        break;
                    case "2":
                        _consoleUI.ShowProduct();
                        break;
                    case "3":
                        _consoleUI.UpdateProduct();
                        break;
                    case "4":
                        _consoleUI.DeleteProduct();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose a valid option.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
    }

