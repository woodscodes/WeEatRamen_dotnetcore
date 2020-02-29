using System;
using System.Collections.Generic;
using System.Text;
using WeEatRamen.Core.Models;
using WeEatRamen.Data.Infrastructure.Context;
using WeEatRamen.Data.Infrastructure.Contracts;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WeEatRamen.Data.Infrastructure.Repositories
{
    public class SqlRepository : IRepository<Shop>
    {
        private readonly WeEatRamenDbContext _db;

        public SqlRepository(WeEatRamenDbContext db)
        {
            _db = db;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public int CountAllTs()
        {
            return _db.Shops.Count();
        }

        public Shop Create(Shop newShop)
        {
            _db.Add(newShop);
            return newShop;
        }

        public Shop Delete(int id)
        {
            var shopToDelete = _db.Shops.Find(id);

            if (shopToDelete != null)
                _db.Shops.Remove(shopToDelete);

            return shopToDelete;
        }

        public IEnumerable<Shop> GetAllByName(string name)
        {
            var query = from s in _db.Shops
                        where s.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby s.Name
                        select s;

            return query;
        }

        public Shop GetById(int id)
        {
            return _db.Shops.Find(id);
        }

        public Shop Update(Shop updatedShop)
        {
            var entity = _db.Shops.Attach(updatedShop);
            entity.State = EntityState.Modified;
            return updatedShop;
        }
    }
}
