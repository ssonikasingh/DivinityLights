using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DivinityLights.Web.Models
{
    public class CategoryViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Display Image")]
        public string DisplayImage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "Is Main Category")]
        public bool Main { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        [Display(Name = "Parent Category")]
        public int ParentCategoryId { get; set; }
    }
}