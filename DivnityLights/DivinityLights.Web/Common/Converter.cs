
using DivinityLights.Entities;
using DivinityLights.Web.Models;
using System.Collections.Generic;
using System.Configuration;

namespace DivinityLights.Web.Common
{
    public static class Converter
    {
        internal static HomeViewModel ConvertToViewModel(List<Category> categories)
        {
            HomeViewModel homeViewModel = null;

            if (categories != null && categories.Count > 0)
            {
                homeViewModel = new HomeViewModel()
                {
                    HomeCategories = categories.ConvertAll<HomeCategoryModel>(c => new HomeCategoryModel()
                    {
                        CategoryDisplayName = c.DisplayName,
                        CategoryId = c.Id,
                        CategoryImagePath = ConfigurationManager.AppSettings[ConfigKeys.ImagePath].ToString() + c.DisplayImagePath
                    })
                };
            }

            return homeViewModel;
        }
    }
}