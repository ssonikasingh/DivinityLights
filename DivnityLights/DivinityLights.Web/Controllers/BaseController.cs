using DivinityLights.BL;
using DivinityLights.Entities;
using DivinityLights.Web.Common;
using DivinityLights.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DivinityLights.Web.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            var model = filterContext.Controller.ViewData.Model as BaseViewModel;

            if (model != null)
                model.BaseCategories = this.GetHomeViewModel();
        }

        protected List<BaseCategoryModel> GetHomeViewModel()
        {
            int categoryCount = 0;
            int.TryParse(ConfigurationManager.AppSettings[ConfigKeys.HomeCategoryCount].ToString(), out categoryCount);
            List<Category> categories = CategoryManager.GetCategoriesForHome(categoryCount).ToList();
            List<BaseCategoryModel> viewModel = DivinityConverter.ConvertToViewModel(categories);

            return viewModel;
        }
    }
}