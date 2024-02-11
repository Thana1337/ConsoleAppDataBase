using ConsoleAppDataBase.Services;
using Microsoft.Extensions.Logging;

namespace ConsoleAppDataBase
{
    internal class ConsoleUI
    {
        private readonly ProductService _productService;
        private readonly CustomerService _customerService;

        internal ConsoleUI(ProductService productService, CustomerService customerService)
        {
            _productService = productService;
            _customerService = customerService;
        }

        public void AddProduct()
        {
            Console.Clear();
            Console.WriteLine("-----Add Product-----");

            Console.WriteLine("Title:");
            var title = Console.ReadLine()!;

            Console.WriteLine("Product Description:");
            var description = Console.ReadLine()!;

            Console.WriteLine("Product Price:");
            var price = decimal.Parse(Console.ReadLine()!);

            Console.WriteLine("Product Category:");
            var categoryName = Console.ReadLine()!;


            var result = _productService.CreateProduct(title, description, price, categoryName);
            if (result != null)
            {
                Console.Clear();
                Console.WriteLine("Product Added!");
                Console.ReadKey();
            }
        }

        public void ShowProduct()
        {
            Console.Clear();
            var products = _productService.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Title}-{product.Description}-{product.Category.CategoryName}-{product.Price} SEK");
            }
            Console.ReadKey();

        }

        public void DeleteProduct()
        {
            Console.Clear();
            Console.WriteLine("-----Delete Product-----");

            var products = _productService.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}-{product.Title}-{product.Price} SEK");
            }

            Console.WriteLine("Enter the ID of the product you want to delete:");
            var productId = int.Parse(Console.ReadLine()!);

            _productService.DeleteProduct(productId);
            Console.WriteLine("Product Deleted!");
            Console.ReadKey();
        }

        public void UpdateProduct()
        {
            Console.Clear();
            Console.WriteLine("-----Update Product-----");

            var products = _productService.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id} - {product.Title}-{product.Description}-{product.Category.CategoryName}-{product.Price} SEK");
            }

            Console.WriteLine("Enter the ID of the product you want to update:");
            var productId = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Choose the attribute to update:");
            Console.WriteLine("1. Title");
            Console.WriteLine("2. Description");
            Console.WriteLine("3. Price");
            Console.WriteLine("4. Category");

            var choice = int.Parse(Console.ReadLine()!);

            string newValue;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter new title:");
                    newValue = Console.ReadLine()!;
                    _productService.UpdateProductTitle(productId, newValue);
                    break;
                case 2:
                    Console.WriteLine("Enter new description:");
                    newValue = Console.ReadLine()!;
                    _productService.UpdateProductDescription(productId, newValue);
                    break;
                case 3:
                    Console.WriteLine("Enter new price:");
                    newValue = Console.ReadLine()!;
                    _productService.UpdateProductPrice(productId, decimal.Parse(newValue));
                    break;
                case 4:
                    Console.WriteLine("Enter new category:");
                    newValue = Console.ReadLine()!;
                    _productService.UpdateProductCategory(productId, newValue);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine("Product Updated!");
            Console.ReadKey();
        }

        public void AddCustomer()
        {
            Console.Clear();
            Console.WriteLine("-----Add Customer-----");

            Console.WriteLine("First Name:");
            var firstName = Console.ReadLine()!;

            Console.WriteLine("Last Name:");
            var lastName = Console.ReadLine()!;

            Console.WriteLine("Email:");
            var email = Console.ReadLine()!;

            Console.WriteLine("City:");
            var city = Console.ReadLine()!;

            Console.WriteLine("Street Name:");
            var streetName = Console.ReadLine()!;

            Console.WriteLine("Country:");
            var country = Console.ReadLine()!;

            Console.WriteLine("Postal Code:");
            var postalCode = Console.ReadLine()!;

            Console.WriteLine("Role Name:");
            var roleName = Console.ReadLine()!;

            var result = _customerService.CreateCustomer(firstName, lastName, email, city, streetName, country, postalCode, roleName);
            if (result != null)
            {
                Console.Clear();
                Console.WriteLine("Customer Added!");
                Console.ReadKey();
            }

        }

        public void ShowCustomers()
        {
            Console.Clear();
            Console.WriteLine("----- All Customers -----");

            var customers = _customerService.GetAllCustomers();

            if (customers.Any())
            {
                foreach (var customer in customers)
                {
                    Console.WriteLine($"ID: {customer.Id}, Name: {customer.FirstName} {customer.LastName}, Email: {customer.Email}, Role: {customer.Role.RoleName}");
                }
            }
            else
            {
                Console.WriteLine("No customers found.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void UpdateCustomer()
        {
            Console.Clear();
            Console.WriteLine("----- Update Customer -----");

            Console.WriteLine("Choose a customer to update:");
            var customers = _customerService.GetAllCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.Id}, Email: {customer.Email}");
            }

            Console.Write("Enter the ID of the customer you want to update: ");
            int customerId;
            while (!int.TryParse(Console.ReadLine(), out customerId))
            {
                Console.WriteLine("Invalid input. Please enter a valid ID:");
                Console.Write("Enter the ID of the customer you want to update: ");
            }

            var customerToUpdate = _customerService.GetCustomerById(customerId);
            if (customerToUpdate != null)
            {
                Console.WriteLine($"Updating customer with ID: {customerToUpdate.Id} and Email: {customerToUpdate.Email}");

                Console.WriteLine("Choose what you want to update:");
                Console.WriteLine("1. First Name");
                Console.WriteLine("2. Last Name");
                Console.WriteLine("3. Email");

                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Invalid input. Please choose 1, 2, or 3:");
                }

                string newValue;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter new first name:");
                        newValue = Console.ReadLine()!;
                        customerToUpdate.FirstName = newValue;
                        break;
                    case 2:
                        Console.WriteLine("Enter new last name:");
                        newValue = Console.ReadLine()!;
                        customerToUpdate.LastName = newValue;
                        break;
                    case 3:
                        Console.WriteLine("Enter new email:");
                        newValue = Console.ReadLine()!;
                        customerToUpdate.Email = newValue;
                        break;
                }

                _customerService.UpdateCustomer(customerToUpdate);
                Console.WriteLine("Customer updated successfully!");
            }
            else
            {
                Console.WriteLine($"Customer with ID {customerId} not found.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void DeleteCustomer()
        {
            Console.Clear();
            Console.WriteLine("----- Delete Customer -----");

            Console.WriteLine("Choose a customer to delete:");
            var customers = _customerService.GetAllCustomers();
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.Id}, Email: {customer.Email}");
            }

            Console.Write("Enter the ID of the customer you want to delete: ");
            int customerId;
            while (!int.TryParse(Console.ReadLine(), out customerId))
            {
                Console.WriteLine("Invalid input. Please enter a valid ID:");
                Console.Write("Enter the ID of the customer you want to delete: ");
            }

            var customerToDelete = _customerService.GetCustomerById(customerId);
            if (customerToDelete != null)
            {
                _customerService.DeleteCustomer(customerId);
                Console.WriteLine("Customer deleted successfully!");
            }
            else
            {
                Console.WriteLine($"Customer with ID {customerId} not found.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}



