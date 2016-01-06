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
        /// Get Category by id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static Category GetCategory(int categoryId)
        {
            return CategoryDbManager.GetCategory(categoryId);
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
                allCategories = new List<Category>() { new Category() { Id = 1, DisplayImage = "Architectural.jpg", DisplayName = "Architectural", Main = true },
                                                       new Category() { Id = 1, DisplayImage = "Cabletrays.jpg", DisplayName = "Cabletrays" , Main = true},
                 new Category() { Id = 1, DisplayImage = "Designer.jpg", DisplayName = "Designer" , Main = true},
                 new Category() { Id = 1, DisplayImage = "Exit.jpg", DisplayName = "Exit" , Main = true},
                 new Category() { Id = 1, DisplayImage = "Facade.jpg", DisplayName = "Facade" , Main = true},
                 new Category() { Id = 1, DisplayImage = "Outdoor.jpg", DisplayName = "Outdoor" , Main = true},};
            }
            
            ICollection<Category> categories = allCategories.Where(x => x.Main == true).Take(count).ToList();

            return categories;
        }
    }
}
