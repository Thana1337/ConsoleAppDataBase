using ConsoleAppDataBase.Contexts;
using ConsoleAppDataBase.Entities;
namespace ConsoleAppDataBase.Repository;

internal class RoleRepository : Repo<RoleEntity>
{
    public RoleRepository(DataContext context) : base(context)
    {
    }
}
