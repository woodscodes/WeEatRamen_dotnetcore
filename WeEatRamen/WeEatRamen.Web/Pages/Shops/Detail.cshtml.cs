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
    public class DetailModel : PageModel
    {
        private readonly IRepository<Shop> _db;

        public Shop Shop { get; set; }
        [TempData]
        public string Message { get; set; }

        public DetailModel(IRepository<Shop> db)
        {
            _db = db;
        }

        public IActionResult OnGet(int shopId)
        {
            Shop = _db.GetById(shopId);
            if (Shop != null)
                return Page();
            else
                return RedirectToPage("./NotFound");
        }
    }
}