﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderAndEat.Database
{
    public abstract class BaseRepository<Entity> : IRepository<Entity> where Entity : BaseEntity
    {
        protected OrderAndEatDbContext _dbContext;

        protected abstract DbSet<Entity> DbSet { get; }

        public BaseRepository(OrderAndEatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Entity> GetAll()
        {
            var list = new List<Entity>();

            var entities = DbSet;

            foreach (var entity in entities)
            {
                list.Add(entity);
            }

            return list;
        }

        public bool AddNew(Entity entity)
        {
            DbSet.Add(entity);

            return SaveChanges();
        }

        public bool Edit(Entity entity)
        {
            var foundEntity = DbSet.FirstOrDefault(x => x.Id == entity.Id);
            if (foundEntity != null)
            {
                foundEntity.Name = entity.Name;

                return SaveChanges();
            }
            return false;
        }

        public bool Delete(Entity entity)
        {
            var foundEntity = DbSet.FirstOrDefault(x => x.Id == entity.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);

                return SaveChanges();
            }

            return false;

        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() > 0;
        }
    }
}
