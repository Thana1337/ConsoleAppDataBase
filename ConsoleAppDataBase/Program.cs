using ConsoleAppDataBase;
using ConsoleAppDataBase.Contexts;
using ConsoleAppDataBase.Repository;
using ConsoleAppDataBase.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services => {

    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Projects\ConsoleAppDataBase\ConsoleAppDataBase\Data\database.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<AddressRepository>();
    services.AddScoped<CategoryRepository>();
    services.AddScoped<CustomerRepository>();
    services.AddScoped<ManufactureRepository>();
    services.AddScoped<ProductRepository>();
    services.AddScoped<RoleRepository>();

    services.AddScoped<AddressService>();
    services.AddScoped<CategoryService>();
    services.AddScoped<CustomerService>();
    services.AddScoped<ManufactureService>();
    services.AddScoped<ProductService>();
    services.AddScoped<RoleService>();

    services.AddSingleton<ConsoleUI>();
    //services.AddSingleton<MenuService>();


}).Build();
var serviceProvider = builder.Services;
var productService = serviceProvider.GetRequiredService<ProductService>();
var customerService = serviceProvider.GetRequiredService<CustomerService>();
ConsoleUI consoleUI = new ConsoleUI(productService, customerService);
//var menuService = serviceProvider.GetRequiredService<MenuService>();

//menuService.ShowMenu();
//consoleUI.AddProduct();
//consoleUI.ShowProduct();
//consoleUI.UpdateProduct();
//consoleUI.DeleteProduct();

//consoleUI.AddCustomer();
//consoleUI.ShowCustomers();
//consoleUI.UpdateCustomer();
//consoleUI.DeleteCustomer();