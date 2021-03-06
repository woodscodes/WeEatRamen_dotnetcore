﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WeEatRamen.Data.Infrastructure.Contracts
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAllByName(string name);
        T GetById(int id);
        T Update(T updated);
        T Create(T newT);
        T Delete(int id);
        int Commit();
    }
}
