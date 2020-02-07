using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeEatRamen.Core.Models;
using WeEatRamen.Data.Infrastructure.Contracts;

namespace WeEatRamen.Web
{
    public class ListModel : PageModel
    {
        private IRepository<Shop> _db;
        public IEnumerable<Shop> Shops { get; set; }

        public ListModel(IRepository<Shop> db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Shops = _db.GetAll();
        }
    }
}