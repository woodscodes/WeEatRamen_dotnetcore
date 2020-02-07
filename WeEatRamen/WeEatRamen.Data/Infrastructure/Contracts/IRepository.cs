using System;
using System.Collections.Generic;
using System.Text;

namespace WeEatRamen.Data.Infrastructure.Contracts
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
