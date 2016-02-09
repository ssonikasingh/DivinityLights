
using DivinityLights.Entities;
using DivinityLights.Web.Models;
using System.Collections.Generic;
using System.Configuration;
using PagedList;
using System.Collections.ObjectModel;
using System.Web;

namespace DivinityLights.Web.Common
{
    public static class DivinityConverter
    {
        public static string ImagePath { get { return ConfigurationManager.AppSettings[ConfigKeys.ImagePath].ToString(); } }

        /// <summary>
        /// Convert Categories to HomeViewModel
        /// </summary>
        /// <param name="categories"></param>
        /// <returns></returns>
        internal static List<BaseCategoryModel> ConvertToViewModel(List<Category> categories)
        {
            List<BaseCategoryModel> baseCategoryModel = null;

            if (categories != null && categories.Count > 0)
            {
                baseCategoryModel = categories.ConvertAll<BaseCategoryModel>(c => new BaseCategoryModel()
                    {
                        CategoryDisplayName = c.DisplayName,
                        CategoryId = c.Id,
                        CategoryImage = ConfigurationManager.AppSettings[ConfigKeys.ImagePath].ToString() + c.DisplayImage
                    });
            }

            return baseCategoryModel;
        }

        /// <summary>
        /// Convert products and category into CatProdViewModel
        /// </summary>
        /// <param name="Products"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        internal static CatProdViewModel ConvertToViewModel(List<Product> Products, Category category)
        {
            CatProdViewModel model = new CatProdViewModel();

            if (Products != null && Products.Count > 0)
            {
                model.Products = Products.ConvertAll<ProductViewModel>(c => ConvertToViewModel(c));
            }
            if (category != null)
            {
                model.CategoryId = category.Id;
                model.CategoryName = category.Name;
            }

            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Products"></param>
        /// <returns></returns>
        internal static ProductListViewModel ConvertToViewModel(List<Product> Products)
        {
            ProductListViewModel model = new ProductListViewModel();

            if (Products != null && Products.Count > 0)
            {
                model.Products = Products.ConvertAll<ProductViewModel>(c => ConvertToViewModel(c));
            }

            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        internal static ProductViewModel ConvertToViewModel(Product product)
        {
            ProductViewModel model = new ProductViewModel();
            if (product != null)
            {
                model = new ProductViewModel()
                {
                    Id = product.Id,
                    CategoryId = product.Category.Id,
                    CategoryName = product.Category.Name,
                    Name = product.Name,
                    Code = product.Code,
                    Desc = product.Desc,
                    Dimensions = product.Dimensions,
                    LightSource = product.LightSource,
                    Material = product.Material,
                    ColorTemperature = product.ColorTemperature,
                    Wattage = product.Wattage,
                    Mounting = product.Mounting,
                    Images = product.Images != null && product.Images.Count > 0 ?
                                product.Images.ConvertAll<ProductImagesViewModel>(c => new ProductImagesViewModel() { Id = c.Id, Image = ImagePath + c.Image })
                                : null,
                    Image = product.Images != null && product.Images.Count > 0 ? ImagePath + product.Images[0].Image : ImagePath + ConfigurationManager.AppSettings[ConfigKeys.NoImage].ToString(),
                };
            }
            return model;
        }

        internal static Product ConvertToEntity(ProductViewModel model, List<ProductImagesViewModel> images)
        {
            Product product = null;

            if (model != null)
            {
                product = new Product()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Code = model.Code,
                    Desc = model.Desc,
                    Dimensions = model.Dimensions,
                    LightSource = model.LightSource,
                    Material = model.Material,
                    ColorTemperature = model.ColorTemperature,
                    Wattage = model.Wattage,
                    Mounting = model.Mounting,
                    Category = new Category() { Id = model.CategoryId },
                };

                if (images != null && images.Count > 0)
                {

                    product.Images = images.ConvertAll<ProductImage>(c => new ProductImage() { Image = c.Image, ProductId = model.Id });
                }
                else
                {
                    if (model.Images != null && model.Images.Count > 0)
                    {
                        product.Images = model.Images.ConvertAll<ProductImage>(c => new ProductImage() { Image = c.Image.Replace(ImagePath, ""), ProductId = model.Id });
                    }                        
                }
            }

            return product;
        }
    }
}