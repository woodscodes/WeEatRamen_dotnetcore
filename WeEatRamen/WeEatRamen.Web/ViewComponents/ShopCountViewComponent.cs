using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeEatRamen.Core.Models;
using WeEatRamen.Data.Infrastructure.Contracts;

namespace WeEatRamen.Web.ViewComponents
{
    public class ShopCountViewComponent : ViewComponent
    {
        private readonly IRepository<Shop> _db;

        public ShopCountViewComponent(IRepository<Shop> db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            return View(_db.CountAllTs());
        }
    }
}
