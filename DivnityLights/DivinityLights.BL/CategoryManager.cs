using DivinityLights.Entities;
using DivinityLights.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinityLights.BL
{
    public static class CategoryManager
    {        
        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns></returns>
        public static ICollection<Category> GetCategories()
        {
            var allCategories = CategoryDbManager.GetCategories();
            ICollection<Category> categories = allCategories.Where(x => x.Main == true).ToList();

            foreach (var category in categories)
            {
                category.SubCategories = allCategories.Where(x => x.ParentCategoryId == category.Id).ToList();
            }

            return categories;
        }

        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns></returns>
        public static ICollection<Category> GetCategoriesForHome(int count)
        {
            var allCategories = CategoryDbManager.GetCategories();
            ICollection<Category> categories = allCategories.Where(x => x.Main == true).Take(count).ToList();

            return categories;
        }
    }
}
