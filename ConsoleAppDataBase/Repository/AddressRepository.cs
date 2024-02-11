using ConsoleAppDataBase.Contexts;
using ConsoleAppDataBase.Entities;
namespace ConsoleAppDataBase.Repository;

internal class AddressRepository : Repo<AddressEntity>
{
    public AddressRepository(DataContext context) : base(context)
    {
    }
}
