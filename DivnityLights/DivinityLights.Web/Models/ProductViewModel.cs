using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DivinityLights.Web.Models
{
    public class ProductViewModel : BaseViewModel
    {
        /// <summary>
        /// Product ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Category ID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        /// <summary>
        /// Product code
        /// </summary>
        [Display(Name = "Product Code")]
        public string Code { get; set; }

        /// <summary>
        /// Product Description
        /// </summary>
        [Display(Name = "Description")]
        public string Desc { get; set; }

        /// <summary>
        /// Product image
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Product image
        /// </summary>
        public string Dimensions { get; set; }

        /// <summary>
        /// Product lights source
        /// </summary>
        [Display(Name = "Light Source")]
        public string LightSource { get; set; }
    }
}