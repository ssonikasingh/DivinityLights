using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DivinityLights.Web.Models
{
    public class ProductListViewModel : BaseViewModel
    {
        public List<ProductViewModel> Products { get; set; } 

        public PagedList.IPagedList<ProductViewModel> ProductsPaged { get; set; }
    }

    public class ProductViewModel : BaseViewModel
    {
        /// <summary>
        /// Product ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Select list for Category
        /// </summary>
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please select Category.")]
        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        /// <summary>
        /// Category select list
        /// </summary>
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please select Category.")]
        public SelectList CategoryList { get; set; } 

        /// <summary>
        /// Product name
        /// </summary>
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Please enter product name.")]
        public string Name { get; set; }

        /// <summary>
        /// Product code
        /// </summary>
        [Display(Name = "Product Code")]
        [Required(ErrorMessage = "Please enter product code.")]
        public string Code { get; set; }

        /// <summary>
        /// Product Description
        /// </summary>
        [Display(Name = "Description")]
        [AllowHtml]
        public string Desc { get; set; }

        /// <summary>
        /// Product Image
        /// </summary>
        [Display(Name = "One of many Image")]
        public string Image { get; set; }

        /// <summary>
        /// Product images
        /// </summary>
        [Display(Name = "Product Images")]
        public List<ProductImagesViewModel> Images { get; set; }

        /// <summary>
        /// Product Dimensions
        /// </summary>
        [Required(ErrorMessage = "Please enter product dimensions.")]
        public string Dimensions { get; set; }

        /// <summary>
        /// Product lights source
        /// </summary>
        [Display(Name = "Light Source")]
        [Required(ErrorMessage = "Please enter product light source.")]
        public string LightSource { get; set; }

        /// <summary>
        /// Product Material
        /// </summary>
        [Required(ErrorMessage = "Please enter product material.")]
        public string Material { get; set; }

        /// <summary>
        /// Product Color Temperature
        /// </summary>
        [Display(Name = "Color Temperature")]
        [Required(ErrorMessage = "Please enter product color temperature.")]
        public string ColorTemperature { get; set; }

        /// <summary>
        /// Product Wattage
        /// </summary>
        [Required(ErrorMessage = "Please enter product wattage.")]
        public string Wattage { get; set; }

        /// <summary>
        /// Product Mounting
        /// </summary>
        [Required(ErrorMessage = "Please enter product mounting.")]
        public string Mounting { get; set; }

    }

    public class ProductImagesViewModel
    {
        /// <summary>
        /// Image ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product image
        /// </summary>
        public string Image { get; set; }
    }
}