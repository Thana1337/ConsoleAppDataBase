using ConsoleAppDataBase.Contexts;
using ConsoleAppDataBase.Entities;
namespace ConsoleAppDataBase.Repository;

internal class CategoryRepository : Repo<CategoryEntity>
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}


