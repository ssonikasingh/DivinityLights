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
            ICollection<Category> allCategories = null;
            try
            {
                allCategories = CategoryDbManager.GetCategories();
            }
            catch
            {
                allCategories = new List<Category>() { new Category() { Id = 1, DisplayImagePath = "Architectural.jpg", DisplayName = "Architectural", Main = true },
                                                       new Category() { Id = 1, DisplayImagePath = "Cabletrays.jpg", DisplayName = "Cabletrays" , Main = true},
                 new Category() { Id = 1, DisplayImagePath = "Designer.jpg", DisplayName = "Designer" , Main = true},
                 new Category() { Id = 1, DisplayImagePath = "Exit.jpg", DisplayName = "Exit" , Main = true},
                 new Category() { Id = 1, DisplayImagePath = "Facade.jpg", DisplayName = "Facade" , Main = true},
                 new Category() { Id = 1, DisplayImagePath = "Outdoor.jpg", DisplayName = "Outdoor" , Main = true},};
            }
            
            ICollection<Category> categories = allCategories.Where(x => x.Main == true).Take(count).ToList();

            return categories;
        }
    }
}
