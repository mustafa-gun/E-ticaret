﻿using E_ticaret.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Dynamic;

namespace E_ticaret.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //static readonly IList<AnaMenu> menuList = new List<AnaMenu>
        //{
        //    new AnaMenu { Id = 1, MenuName = "Elektronik", MenuLink = "elektronik" ,
        //            AltMenuler = new List<AltMenu>(){
        //                new AltMenu { Id = 1, DropdownName = "Bilgisayar", DropdownLink = "bilgisayar"},
        //                new AltMenu { Id = 2, DropdownName = "Akıllı Telefon", DropdownLink = "akilli-telefon"},
        //                new AltMenu { Id = 3, DropdownName = "Televizyon", DropdownLink = "televizyon"}
        //            }
        //        },
        //        new AnaMenu { Id = 2, MenuName = "Moda", MenuLink = "moda", AltMenuler = new List<AltMenu>()},
        //        new AnaMenu { Id = 3, MenuName = "Ev, Yaşam", MenuLink = "ev-yasam" , AltMenuler = new List<AltMenu>(){
        //            new AltMenu { Id = 3, DropdownName = "Televizyon", DropdownLink = "televizyon"},
        //            }
        //        },
        //        new AnaMenu { Id = 4, MenuName = "Yapı Market", MenuLink = "yapi-market" , AltMenuler = new List<AltMenu>()},
        //        new AnaMenu { Id = 5, MenuName = "Spor Outdoor", MenuLink = "spor-outdoor" , AltMenuler = new List<AltMenu>()},
        //};
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

        public ExpandoObject GetAllMenu()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Menu = GetMenus();
            mymodel.AltMenu = GetAltMenus();
            return mymodel;
        }
        public IActionResult Index()
        {
            Random rnd = new();
            ViewBag.Rnd1 = rnd.Next(1, 13);
            ViewBag.Rnd2 = rnd.Next(1, 13);

            DateTime CurrentDate = DateTime.Now;
            ViewBag.CurrentDate = CurrentDate.ToString("ddMMyyyy");


            //var _anaMenu = new List<AnaMenu>
            //{
            //    new AnaMenu { Id = 1, MenuName = "Elektronik", MenuLink = "elektronik" ,
            //        AltMenuler = new List<AltMenu>(){
            //            new AltMenu { Id = 1, DropdownName = "Bilgisayar", DropdownLink = "bilgisayar"},
            //            new AltMenu { Id = 2, DropdownName = "Akıllı Telefon", DropdownLink = "akilli-telefon"},
            //            new AltMenu { Id = 3, DropdownName = "Televizyon", DropdownLink = "televizyon"}
            //        }
            //    },
            //    new AnaMenu { Id = 2, MenuName = "Moda", MenuLink = "moda", AltMenuler = new List<AltMenu>()},
            //    new AnaMenu { Id = 3, MenuName = "Ev, Yaşam", MenuLink = "ev-yasam" , AltMenuler = new List<AltMenu>(){
            //        new AltMenu { Id = 3, DropdownName = "Televizyon", DropdownLink = "televizyon"}
            //        }
            //    },
            //    new AnaMenu { Id = 4, MenuName = "Yapı Market", MenuLink = "yapi-market" , AltMenuler = new List<AltMenu>()},
            //    new AnaMenu { Id = 5, MenuName = "Spor Outdoor", MenuLink = "spor" , AltMenuler = new List<AltMenu>()},
            //};
            //List<MenuItem> navbar = new List<MenuItem>();

            //for (int i = 0; i < _anaMenu.Count; i++)
            //{
            //    navbar.Add(new MenuItem(_anaMenu[i]));
            //}

            //var _altMenu = new List<AltMenu>
            //{

            //    //new AltMenu { DropdownId = 4, DropdownName = "Televizyon", DropdownLink = "/Elektronik/Televizyon", MenuId = 1},
            //    //new AltMenu { DropdownId = 5, DropdownName = "Televizyon", DropdownLink = "/Elektronik/Televizyon", MenuId = 1},
            //};

            //MenuItems navbar = new MenuItems { AnaMenuItem = _anaMenu, AltMenuItem = _altMenu };

            //MenuItems item = new MenuItems(new AnaMenu(), new AltMenu());


            var getMenu = GetAllMenu();
            return View(getMenu);
        }

        public IActionResult Privacy()
        {
            var getMenu = GetAllMenu();
            return View(getMenu);   
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}