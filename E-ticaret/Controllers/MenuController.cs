using E_ticaret.Data;
using E_ticaret.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Text.Json;

namespace E_ticaret.Controllers
{
    public class MenuController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MenuController(ApplicationDbContext db)
        {
            _db = db;
        }
        //private static List<Menu> GetMenus()
        //{
        //    List<Menu> menu = new()
        //    {
        //        new Menu { MenuId = 1, MenuName = "Elektronik" },
        //        new Menu { MenuId = 2, MenuName = "Moda" },
        //        new Menu { MenuId = 3, MenuName = "Ev Tekstil" },
        //        new Menu { MenuId = 4, MenuName = "Outdooe" }
        //    };
        //    return menu;
        //}

        //public List<AltMenu> GetAltMenus()
        //{
        //    List<AltMenu> altMenus = new()
        //    {
        //        new AltMenu { AltMenuId = 1, AltMenuName = "Televizyon", AnaMenuId = 1 },
        //        new AltMenu { AltMenuId = 2, AltMenuName = "Giyim", AnaMenuId = 2 },
        //        new AltMenu { AltMenuId = 3, AltMenuName = "Alt Menu", AnaMenuId = 2 },
        //        new AltMenu { AltMenuId = 4, AltMenuName = "Alt Menu", AnaMenuId = 3 },
        //        new AltMenu { AltMenuId = 5, AltMenuName = "Alt Menu 1", AnaMenuId = 3 },
        //        new AltMenu { AltMenuId = 6, AltMenuName = "Alt Menu", AnaMenuId = 4 }
        //    };
        //    return altMenus;
        //}

        [HttpPost]
        public ExpandoObject GetAllMenu()
        {
            //dynamic mymodel = new ExpandoObject();
            //mymodel.Menu = GetMenus();
            //mymodel.AltMenu = GetAltMenus();

            //string serilizedAnaMenu = JsonSerializer.Serialize(mymodel.Menu);
            //ViewData["AnaMenuler"] = serilizedAnaMenu;

            //string serilizedAltMenu = JsonSerializer.Serialize(mymodel.AltMenu);
            //ViewData["AltMenuler"] = serilizedAltMenu;

            IEnumerable<Kategori> objKategori = _db.tblKategori.ToList();
            IEnumerable<AltKategori> altKategoris = _db.tblAltKategori.ToList();

            dynamic mymodel = new ExpandoObject();
            mymodel.Menu = objKategori;
            mymodel.AltMenu = altKategoris;

            //var dataMenu = JsonSerializer.Deserialize<List<Menu>>(TempData["AnaMenuler"].ToString());
            //var dataAltMenu = JsonSerializer.Deserialize<List<AltMenu>>(TempData["AltMenuler"].ToString());


            //dynamic mymodel = new ExpandoObject();
            //mymodel.Menu = dataMenu;
            //mymodel.AltMenu = dataAltMenu;

            return mymodel;
        }

        public IActionResult Index()
        {

            var getMenu = GetAllMenu();
            return View(getMenu);
        }
        public IActionResult Detay()
        {
            var getMenu = GetAllMenu();
            return View(getMenu);
        }


        //public ActionResult Index()
        //{
        //    var _anaMenu = new List<AnaMenu>()
        //    {
        //        new AnaMenu { Id = 1, MenuName = "Elektronik", MenuLink = "elektronik" ,
        //            AltMenuler = new List<AltMenu>(){
        //                new AltMenu { Id = 1, DropdownName = "Bilgisayar", DropdownLink = "bilgisayar"},
        //                new AltMenu { Id = 2, DropdownName = "Akıllı Telefon", DropdownLink = "akilli-telefon"},
        //                new AltMenu { Id = 3, DropdownName = "Televizyon", DropdownLink = "televizyon"}
        //            }
        //        },
        //        new AnaMenu { Id = 2, MenuName = "Moda", MenuLink = "moda", AltMenuler = new List<AltMenu>()},
        //        new AnaMenu { Id = 3, MenuName = "Ev, Yaşam", MenuLink = "ev-yasam" , AltMenuler = new List<AltMenu>(){
        //            new AltMenu { Id = 3, DropdownName = "Televizyon", DropdownLink = "televizyon"}
        //            }
        //        },
        //        new AnaMenu { Id = 4, MenuName = "Yapı Market", MenuLink = "yapi-market" , AltMenuler = new List<AltMenu>()},
        //        new AnaMenu { Id = 5, MenuName = "Spor Outdoor", MenuLink = "spor" , AltMenuler = new List<AltMenu>()},
        //    };
        //    List<MenuItem> navbar = new List<MenuItem>();

        //    for (int i = 0; i < _anaMenu.Count; i++)
        //    {
        //        navbar.Add(new MenuItem(_anaMenu[i]));
        //    }

        //    string jsonString = System.Text.Json.JsonSerializer.Serialize(_anaMenu).ToString();
        //    Console.WriteLine(jsonString);

        //    //TempData["MenuList"] = navbar;

        //    TempData["data1"] = "test data";

        //    TempData["message"] = "Welcome to TutorialsPanel.com!";
        //    return RedirectToAction("Index", "Home", jsonString);

        //}
    }
}