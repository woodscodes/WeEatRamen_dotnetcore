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

        public IActionResult OnGet(int shopId)
        {
            SoupTypes = _helper.GetEnumSelectList<SoupBase>();
            Shop = _db.GetById(shopId);

            if (Shop != null)
                return Page();
            else
                return RedirectToPage("./NotFound");
        }

        public IActionResult OnPost()
        {
            SoupTypes = _helper.GetEnumSelectList<SoupBase>();

            if(ModelState.IsValid)
            {
                _db.Update(Shop);
                return RedirectToPage("./Detail", new { shopId = Shop.Id });
            }
            return Page();
        }
    }
}