﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OrderAndEat.Database
{
    public interface IRepository<Entity> where Entity : BaseEntity
    {
        List<Entity> GetAll();
        bool AddNew(Entity entity);
        bool Delete(Entity entity);
        bool SaveChanges();
    }
}
