using System;
using System.Collections.Generic;
using System.Text;
using WeEatRamen.Core.Models;
using WeEatRamen.Data.Infrastructure.Contracts;
using System.Linq;

namespace WeEatRamen.Data.Infrastructure.Repositories
{
    public class InMemoryRepository : IRepository<Shop>
    {
        private readonly List<Shop> _db;

        public InMemoryRepository()
        {
            _db = new List<Shop>()
            {
                new Shop { Id = 1, ImgUrl = "", Name = "Itabashiya", Location = "Utsunomiya, TCG", Soup = Core.Enums.SoupBase.Tonkotsu, Rating = 5, Description = ""},
                new Shop { Id = 2, ImgUrl = "", Name = "Nikko Miso Ramen", Location = "Utsunomiya, TCG", Soup = Core.Enums.SoupBase.Miso, Rating = 4, Description = ""},
                new Shop { Id = 3, ImgUrl = "", Name = "Nakiriryu", Location = "Toshima, TKY", Soup = Core.Enums.SoupBase.Shio, Rating = 5},
                new Shop { Id = 4, ImgUrl = "", Name = "Tsuta", Location = "Toshima, TKY", Soup= Core.Enums.SoupBase.Shoyu, Rating = 5, Description = ""}
            };
        }

        public IEnumerable<Shop> GetAll()
        {
            return from s in _db
                   orderby s.Name
                   select s;
        }

        public Shop GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
