﻿using Dashboard.Domain.Models;
using Domain.Data;

namespace Dashboard.Repository.RepositoryPattern
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public virtual T Get(int id)
        {
            return _context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public virtual T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChangesAsync();
            return entity;
        }
    }
}
