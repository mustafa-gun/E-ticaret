using System.Web;
using Microsoft.AspNetCore.Mvc;
using E_ticaret.Models;
using Microsoft.AspNetCore.Http;

namespace E_ticaret.Controllers
{
    public class MenuController : Controller
    {
        public string List(string id)
        {

            return id;
        }

        [HttpGet]
        [Route("detay")]
        public IActionResult Detay(string id)
        {


            //List<AnaMenu> _anaMenu = new()
            //    {
            //        new AnaMenu { Id = 1, MenuName = "MenuName", MenuLink = "menulink" },
            //        new AnaMenu { Id = 2, MenuName = "MenuName", MenuLink = "menulink" },
            //        new AnaMenu { Id = 3, MenuName = "MenuName", MenuLink = "menulink" },
            //        new AnaMenu { Id = 4, MenuName = "MenuName", MenuLink = "menulink" },
            //    };

            //id = Request.Query["id"];


            //string category = Request.Query["detay"];

            return View();
        }
        //        static readonly List<AnaMenu> _anaMenu = new List<AnaMenu>()
        //        {
        //            new AnaMenu { Id = 1, MenuName = "MenuName", MenuLink = "menulink" },
        //            new AnaMenu { Id = 2, MenuName = "MenuName", MenuLink = "menulink" },
        //            new AnaMenu { Id = 3, MenuName = "MenuName", MenuLink = "menulink" },
        //            new AnaMenu { Id = 4, MenuName = "MenuName", MenuLink = "menulink" },
        //        };

        //        static readonly List<AltMenu> _altMenu = new List<AltMenu>()
        //        {
        //            new AltMenu { Id = 1, DropdownName = "DropdownName", DropdownLink = "dropdownlink", MenuId = 1},
        //            new AltMenu { Id = 2, DropdownName = "DropdownName", DropdownLink = "dropdownlink", MenuId = 1 },
        //            new AltMenu { Id = 3, DropdownName = "DropdownName", DropdownLink = "dropdownlink", MenuId = 2 },
        //            new AltMenu { Id = 4, DropdownName = "DropdownName", DropdownLink = "dropdownlink", MenuId = 3 },
        //        };


        //        
        //        [Route("menu")]
        [HttpGet]
        public IActionResult Index()
        {

            var _anaMenu = new List<AnaMenu>
            {
                new AnaMenu { Id = 1, MenuName = "Elektronik", MenuLink = "elektronik" ,
                    AltMenuler = new List<AltMenu>(){
                        new AltMenu { Id = 1, DropdownName = "Bilgisayar", DropdownLink = "bilgisayar"},
                        new AltMenu { Id = 2, DropdownName = "Akıllı Telefon", DropdownLink = "akilli-telefon"},
                        new AltMenu { Id = 3, DropdownName = "Televizyon", DropdownLink = "televizyon"}
                    }
                },
                new AnaMenu { Id = 2, MenuName = "Moda", MenuLink = "moda", AltMenuler = new List<AltMenu>()},
                new AnaMenu { Id = 3, MenuName = "Ev, Yaşam", MenuLink = "ev-yasam" , AltMenuler = new List<AltMenu>(){
                    new AltMenu { Id = 3, DropdownName = "Televizyon", DropdownLink = "televizyon"},
                    }
                },
                new AnaMenu { Id = 4, MenuName = "Yapı Market", MenuLink = "yapi-market" , AltMenuler = new List<AltMenu>()},
                new AnaMenu { Id = 5, MenuName = "Spor Outdoor", MenuLink = "spor-outdoor" , AltMenuler = new List<AltMenu>()},
            };

            List<MenuItem> navbar = new List<MenuItem>();

            for (int i = 0; i < _anaMenu.Count; i++)
            {
                navbar.Add(new MenuItem(_anaMenu[i]));
            }

            
            //string name = "";
            //if (!String.IsNullOrEmpty(HttpContext.Request.Query["name"]))
                //name = HttpContext.Request.Query["name"];
            //"Name from query string: " + name
            return View(navbar);

            //            List<MenuItem> menus = new();

            //            List<AnaMenu> _anaMenu = new List<AnaMenu>()
            //            {
            //                new AnaMenu { Id = 1, MenuName = "MenuName", MenuLink = "menulink" },
            //                new AnaMenu { Id = 2, MenuName = "MenuName", MenuLink = "menulink" },
            //                new AnaMenu { Id = 3, MenuName = "MenuName", MenuLink = "menulink" },
            //                new AnaMenu { Id = 4, MenuName = "MenuName", MenuLink = "menulink" },
            //            };

            //            List<AltMenu> _altMenu = new List<AltMenu>()
            //            {
            //                new AltMenu { Id = 1, DropdownName = "DropdownName", DropdownLink = "dropdownlink", MenuId = 1},
            //                new AltMenu { Id = 2, DropdownName = "DropdownName", DropdownLink = "dropdownlink", MenuId = 1 },
            //                new AltMenu { Id = 3, DropdownName = "DropdownName", DropdownLink = "dropdownlink", MenuId = 2 },
            //                new AltMenu { Id = 4, DropdownName = "DropdownName", DropdownLink = "dropdownlink", MenuId = 3 },
            //            };

            //return View();
        }

    }
}
