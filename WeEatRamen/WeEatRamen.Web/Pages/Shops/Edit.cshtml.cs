using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeEatRamen.Core.Enums;
using WeEatRamen.Core.Models;
using WeEatRamen.Data.Infrastructure.Contracts;

namespace WeEatRamen.Web
{
    public class EditModel : PageModel
    {
        private readonly IRepository<Shop> _db;
        private readonly IHtmlHelper _helper;

        [BindProperty]
        public Shop Shop { get; set; }
        public IEnumerable<SelectListItem> SoupTypes { get; set; }        

        public EditModel(IRepository<Shop> db, IHtmlHelper helper)
        {
            _db = db;
            _helper = helper;
        }

        public IActionResult OnGet(int? shopId)
        {
            SoupTypes = _helper.GetEnumSelectList<SoupBase>();

            if (shopId.HasValue)
                Shop = _db.GetById(shopId.Value);
            else
                Shop = new Shop();

            return Page();
        }

        public IActionResult OnPost()
        {

            if(!ModelState.IsValid)
            {
                SoupTypes = _helper.GetEnumSelectList<SoupBase>();
                return Page();  
            }

            if (Shop.Id > 0)
            {
                _db.Update(Shop);                
            }
            else
                _db.Create(Shop);

            _db.Commit();

            TempData["Message"] = "Shop saved!";

            return RedirectToPage("./Detail", new { shopId = Shop.Id });

        }
    }
}