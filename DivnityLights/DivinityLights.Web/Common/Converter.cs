
using DivinityLights.Entities;
using DivinityLights.Web.Models;
using System.Collections.Generic;
using System.Configuration;
using PagedList;

namespace DivinityLights.Web.Common
{
    public static class DivinityConverter
    {
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
                model.Products = Products.ConvertAll<ProductViewModel>(c => new ProductViewModel()
                    {
                        Id = c.Id,
                        CategoryId = c.CategoryId,
                        Name = c.Name,
                        Code = c.Code,
                        Desc = c.Desc,
                        Dimensions = c.Dimensions,
                        LightSource = c.LightSource,
                        Image = ConfigurationManager.AppSettings[ConfigKeys.ImagePath].ToString() + c.Image
                    });
            }
            if (category != null)
            {
                model.CategoryId = category.Id;
                model.CategoryName = category.Name;
            }

            return model;
        }

        internal static ProductViewModel ConvertToViewModel(Product product)
        {
            ProductViewModel model = null;
            if (product != null)
            {
                model = new ProductViewModel()
                {
                    Id = product.Id,
                    CategoryId = product.CategoryId,
                    Name = product.Name,
                    Code = product.Code,
                    Desc = product.Desc,
                    Dimensions = product.Dimensions,
                    LightSource = product.LightSource,
                    Image = ConfigurationManager.AppSettings[ConfigKeys.ImagePath].ToString() + product.Image
                };
            }
            return model;
        }
    }
}