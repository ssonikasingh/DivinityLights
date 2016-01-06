using System.Collections.Generic;
namespace DivinityLights.Web.Models
{
    public class HomeViewModel : BaseViewModel
    {
        
    }

    public class BaseViewModel 
    {
        public List<BaseCategoryModel> BaseCategories { get; set; }
    }

    public class BaseCategoryModel
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