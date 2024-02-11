﻿using ConsoleAppDataBase.Contexts;
using System.Linq.Expressions;


namespace ConsoleAppDataBase.Repository;

internal class Repo<TEntity> where TEntity : class

{
    private readonly DataContext _context;

    public Repo(DataContext context)
    {
        _context = context;
    }

    public virtual TEntity Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public virtual TEntity Get(Expression<Func<TEntity, bool>> expression)
    {
        var entity = _context.Set<TEntity>().FirstOrDefault(expression);
        return entity!;
    }

    public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
    {
        var toUpdate = _context.Set<TEntity>().FirstOrDefault(expression);
        _context.Entry(toUpdate!).CurrentValues.SetValues(entity);
        _context.SaveChanges();
        return toUpdate!;
    }

    public virtual void Delete(Expression<Func<TEntity, bool>> expression)
    {
        var entity = _context.Set<TEntity>().FirstOrDefault(expression);
        _context.Remove(entity!);
        _context.SaveChanges();
    }

}
