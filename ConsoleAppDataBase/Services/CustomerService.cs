using ConsoleAppDataBase.Entities;
using ConsoleAppDataBase.Repository;
using ConsoleAppDataBase.Services;


namespace ConsoleAppDataBase.Services;

internal class CustomerService
{
    private readonly CustomerRepository _customerRepository;
    private readonly AddressService _addressService;
    private readonly RoleService _roleService;

    public CustomerService(CustomerRepository cutomerRepository, AddressService addressService, RoleService roleService)
    {
        _customerRepository = cutomerRepository;
        _addressService = addressService;
        _roleService = roleService;
    }

    public CustomerEntity CreateCustomer(string firstname, string lastname, string email, string city, string streetname, string country, string postalcode, string roleName)
    {
        var adressEntity = _addressService.CreateAdress(city, streetname, postalcode, country);
        var roleEntity = _roleService.CreateRole(roleName);
        var customerEntity = new CustomerEntity
        {
            FirstName = firstname,
            LastName = lastname,
            Email = email,
            AdressId = adressEntity.Id,
            RoleId = roleEntity.Id

        };

        customerEntity = _customerRepository.Create(customerEntity);
        return customerEntity;
    }




    public CustomerEntity GetCustomerByEmail(string customerEmail)
    {
        var customerEntity = _customerRepository.Get(x => x.Email == customerEmail);
        return customerEntity;
    }

    public IEnumerable<CustomerEntity> GetAllCustomers()
    {
        var customers = _customerRepository.GetAll();
        return customers;
    }

    public CustomerEntity GetCustomerById(int id)
    {
        var customerEntity = _customerRepository.Get(x => x.Id == id);
        return customerEntity;
    }

    public CustomerEntity UpdateCustomer(CustomerEntity customerEntity)
    {
        var customerUpdated = _customerRepository.Update(x => x.Id == customerEntity.Id, customerEntity);
        return customerUpdated;
    }

    public void DeleteCustomer(int id)
    {
        _customerRepository.Delete(x => x.Id == id);
    }

}
