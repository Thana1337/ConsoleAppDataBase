﻿using ConsoleAppDataBase.Contexts;
using ConsoleAppDataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace ConsoleAppDataBase.Repository;

internal class ProductRepository : Repo<ProductEntity>
{
    private readonly DataContext _context;
    public ProductRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override ProductEntity Get(Expression<Func<ProductEntity, bool>> expression)
    {
        var entity = _context.Products
            .
            Include(i => i.Category).
            FirstOrDefault(expression);
        return entity!;
    }

    public override IEnumerable<ProductEntity> GetAll()
    {
        return _context.Products.Include(i => i.Category).ToList();
    }

    public ProductEntity GetById(int id)
    {
        return _context.Products.FirstOrDefault(i =>i.Id == id)!;
    }
}
