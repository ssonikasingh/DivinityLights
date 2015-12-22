using System.Collections.Generic;
namespace DivinityLights.Web.Models
{
    public class HomeViewModel 
    {
        public List<HomeCategoryModel> HomeCategories { get; set; }
    }

    public class HomeCategoryModel
    {
        /// <summary>
        /// Category Id
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Category Display name to be shown on home page
        /// </summary>
        public string CategoryDisplayName { get; set; }
        
        /// <summary>
        /// Category image path to be shown on home page
        /// </summary>        
        public string CategoryImage { get; set; }
    }
}