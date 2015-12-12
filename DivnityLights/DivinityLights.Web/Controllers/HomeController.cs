using DivinityLights.BL;
using DivinityLights.Entities;
using DivinityLights.Web.Models;
using DivinityLights.Web.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DivinityLights.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int categoryCount = 0;
            int.TryParse(ConfigurationManager.AppSettings[ConfigKeys.HomeCategoryCount].ToString(), out categoryCount);
            List<Category> categories = CategoryManager.GetCategoriesForHome(categoryCount).ToList();
            HomeViewModel viewModel = Converter.ConvertToViewModel(categories);
            
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}