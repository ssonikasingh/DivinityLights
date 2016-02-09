using DivinityLights.DAL;
using DivinityLights.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinityLights.BL
{
    public class ProductManager
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static Product GetProduct(int productId)
        {
            return ProductDbManager.GetProduct(productId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static ICollection<Product> GetProductsByCategory(int categoryId)
        {
            return ProductDbManager.GetProductsByCategory(categoryId);
        }

        /// <summary>
        /// Get All products
        /// </summary>
        /// <returns></returns>
        public static ICollection<Product> GetProducts()
        {
            return ProductDbManager.GetProducts();
        }

        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static string AddEditProduct(Product product)
        {
            return ProductDbManager.AddEditProduct(product);
        }
    }
}
