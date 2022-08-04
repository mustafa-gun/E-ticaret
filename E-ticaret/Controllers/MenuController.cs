using Microsoft.AspNetCore.Mvc;
using E_ticaret.Models;
using System.Dynamic;

namespace E_ticaret.Controllers
{
    public class MenuController : Controller
    {
        private static List<Menu> GetMenus()
        {
            List<Menu> menu = new()
            {
                new Menu { MenuId = 1, MenuName = "Elektronik" },
                new Menu { MenuId = 2, MenuName = "Moda" },
                new Menu { MenuId = 3, MenuName = "Ev Tekstil" },
                new Menu { MenuId = 4, MenuName = "Outdooe" }
            };
            return menu;
        }

        public List<AltMenu> GetAltMenus()
        {
            List<AltMenu> altMenus = new()
            {
                new AltMenu { AltMenuId = 1, AltMenuName = "Televizyon", AnaMenuId = 1 },
                new AltMenu { AltMenuId = 2, AltMenuName = "Giyim", AnaMenuId = 2 },
                new AltMenu { AltMenuId = 3, AltMenuName = "Alt Menu", AnaMenuId = 2 },
                new AltMenu { AltMenuId = 4, AltMenuName = "Alt Menu", AnaMenuId = 3 },
                new AltMenu { AltMenuId = 5, AltMenuName = "Alt Menu", AnaMenuId = 3 },
                new AltMenu { AltMenuId = 6, AltMenuName = "Alt Menu", AnaMenuId = 4 }
            };
            return altMenus;
        }

        public IActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Menu = GetMenus();
            mymodel.AltMenu = GetAltMenus();
            return View(mymodel);
        }
        public IActionResult Detay(int id)
        {
            id.ToString();
            dynamic mymodel = new ExpandoObject();
            mymodel.Menu = GetMenus();
            mymodel.AltMenu = GetAltMenus();
            return View(mymodel);
        }
    }
}
