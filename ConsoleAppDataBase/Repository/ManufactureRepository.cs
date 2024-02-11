using ConsoleAppDataBase.Contexts;
using ConsoleAppDataBase.Entities;
using Microsoft.EntityFrameworkCore;
namespace ConsoleAppDataBase.Repository;

internal class ManufactureRepository : Repo<ManufactureEntity>
{
    private readonly DataContext _context;

    public ManufactureRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override ManufactureEntity Create(ManufactureEntity entity)
    {
        var addedEntity = _context.Set<ManufactureEntity>().Add(entity);
        _context.SaveChanges();
        return addedEntity.Entity;
    }
}
