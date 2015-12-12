using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinityLights.Entities
{
    public class Category
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DisplayImagePath { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Main { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ParentCategoryId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public ICollection<Category> SubCategories { get; set; }
    }
}
