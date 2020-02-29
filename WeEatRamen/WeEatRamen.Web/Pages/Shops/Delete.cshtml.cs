using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeEatRamen.Core.Models;
using WeEatRamen.Data.Infrastructure.Contracts;

namespace WeEatRamen.Web
{
    public class DeleteModel : PageModel
    {
        private readonly IRepository<Shop> _db;
        private readonly IHtmlHelper _helper;

        [BindProperty]
        public Shop ShopToDelete { get; set; }
        
        public DeleteModel(IRepository<Shop> db, IHtmlHelper helper)
        {
            _db = db;
            _helper = helper;
        }

        public IActionResult OnGet(int shopId)
        {
            ShopToDelete = _db.GetById(shopId);
            if (ShopToDelete != null)
                return Page();
            else
                return RedirectToPage("NotFound");
        }

        public IActionResult OnPost(int shopId)
        {
            ShopToDelete = _db.GetById(shopId);

            if (ShopToDelete != null)
            {
                _db.Delete(ShopToDelete.Id);
                _db.Commit();
                TempData["Message"] = $"{ShopToDelete.Name} was deleted!";
                return RedirectToPage("List");
            }
            else
                return RedirectToPage("NotFound");
        }
    }
}