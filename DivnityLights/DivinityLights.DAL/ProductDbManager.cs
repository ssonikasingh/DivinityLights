using DivinityLights.Entities;
using SoviTech.Common.Contracts;
using SoviTech.Common.DatabaseHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinityLights.DAL
{
    public static class ProductDbManager
    {
        private static readonly IDatabaseManager dbManager;

        static ProductDbManager()
        {
            dbManager = new DatabaseManager();
            dbManager.InitializeDatabase(Databases.DivnityLights, 5000);
        }
        
        /// <summary>
        /// Get products by category id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static ICollection<Product> GetProducts()
        {
            ICollection<Product> products = null;

            using (var dbCommand = dbManager.GetStoredProcCommand(StoredProcedures.GetProducts.SpNameProducts))
            {
                using (IDataReader reader = dbManager.ExecuteReaderWithRetry(dbCommand))
                {
                    if (reader != null)
                    {
                        products = GetProducts(reader);
                    }
                }
            }

            return products;
        }

        private static ICollection<Product> GetProducts(IDataReader reader)
        {
            ICollection<Product>  products = new Collection<Product>();
            while (reader.Read())
            {
                var id = reader[StoredProcedures.GetProducts.ColumnNames.Id];
                var catId = reader[StoredProcedures.GetProducts.ColumnNames.CategoryId];
                var name = reader[StoredProcedures.GetProducts.ColumnNames.Name];
                var code = reader[StoredProcedures.GetProducts.ColumnNames.Code];
                var desc = reader[StoredProcedures.GetProducts.ColumnNames.Desc];
                var image = reader[StoredProcedures.GetProducts.ColumnNames.Image];
                var lightSource = reader[StoredProcedures.GetProducts.ColumnNames.LightSource];
                var dimensions = reader[StoredProcedures.GetProducts.ColumnNames.Dimensions];
                var material = reader[StoredProcedures.GetProducts.ColumnNames.Material];
                var colorTemperature = reader[StoredProcedures.GetProducts.ColumnNames.ColorTemperature];
                var wattage = reader[StoredProcedures.GetProducts.ColumnNames.Wattage];
                var mounting = reader[StoredProcedures.GetProducts.ColumnNames.Mounting];

                products.Add(new Product()
                {

                    Id = Convert.ToInt32(id, CultureInfo.InvariantCulture),
                    Category = GetCategory(reader),
                    Name = name != DBNull.Value
                              ? Convert.ToString(name, CultureInfo.InvariantCulture)
                              : String.Empty,
                    Code = code != DBNull.Value
                              ? Convert.ToString(code, CultureInfo.InvariantCulture)
                              : string.Empty,
                    Images = image != DBNull.Value
                               ? new List<ProductImage>() { new ProductImage() { Image = Convert.ToString(image, CultureInfo.InvariantCulture) } }
                               : null,
                    Desc = desc != DBNull.Value
                               ? Convert.ToString(desc, CultureInfo.InvariantCulture)
                               : String.Empty,
                    LightSource = lightSource != DBNull.Value
                              ? Convert.ToString(lightSource, CultureInfo.InvariantCulture)
                              : String.Empty,
                    Dimensions = dimensions != DBNull.Value
                              ? Convert.ToString(dimensions, CultureInfo.InvariantCulture)
                              : String.Empty,
                    Material = material != DBNull.Value
                              ? Convert.ToString(material, CultureInfo.InvariantCulture)
                              : String.Empty,
                    ColorTemperature = colorTemperature != DBNull.Value
                              ? Convert.ToString(colorTemperature, CultureInfo.InvariantCulture)
                              : String.Empty,
                    Wattage = wattage != DBNull.Value
                              ? Convert.ToString(wattage, CultureInfo.InvariantCulture)
                              : String.Empty,
                    Mounting = mounting != DBNull.Value
                              ? Convert.ToString(mounting, CultureInfo.InvariantCulture)
                              : String.Empty,

                });
            }
            return products;
        }

        /// <summary>
        /// Get product by product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static Product GetProduct(int productId)
        {
            Product product = null;

            using (var dbCommand = dbManager.GetStoredProcCommand(StoredProcedures.GetProduct.SpName))
            {

                dbManager.AddInParameter(dbCommand, StoredProcedures.GetProduct.Params.Id, DbType.Int32, productId);


                using (IDataReader reader = dbManager.ExecuteReaderWithRetry(dbCommand))
                {
                    if (reader != null)
                    {
                        while (reader.Read())
                        {
                            var id = reader[StoredProcedures.GetProduct.ColumnNames.Id];
                            var name = reader[StoredProcedures.GetProduct.ColumnNames.Name];
                            var code = reader[StoredProcedures.GetProduct.ColumnNames.Code];
                            var desc = reader[StoredProcedures.GetProduct.ColumnNames.Desc];
                            var images = reader[StoredProcedures.GetProduct.ColumnNames.Images];
                            var lightSource = reader[StoredProcedures.GetProduct.ColumnNames.LightSource];
                            var dimensions = reader[StoredProcedures.GetProduct.ColumnNames.Dimensions];
                            var material = reader[StoredProcedures.GetProducts.ColumnNames.Material];
                            var colorTemperature = reader[StoredProcedures.GetProducts.ColumnNames.ColorTemperature];
                            var wattage = reader[StoredProcedures.GetProducts.ColumnNames.Wattage];
                            var mounting = reader[StoredProcedures.GetProducts.ColumnNames.Mounting];
                            

                            product = new Product
                            {

                                Id = id != DBNull.Value
                                          ? Convert.ToInt32(id, CultureInfo.InvariantCulture)
                                          : 0,
                                Category = GetCategory(reader),
                                Name = name != DBNull.Value
                                          ? Convert.ToString(name, CultureInfo.InvariantCulture)
                                          : String.Empty,
                                Code = code != DBNull.Value
                                          ? Convert.ToString(code, CultureInfo.InvariantCulture)
                                          : string.Empty,
                                Desc = desc != DBNull.Value
                                           ? Convert.ToString(desc, CultureInfo.InvariantCulture)
                                           : String.Empty,
                                Images = images != DBNull.Value
                                           ? GetProductImages(Convert.ToString(images, CultureInfo.InvariantCulture))
                                           : null,
                                LightSource = lightSource != DBNull.Value
                                          ? Convert.ToString(lightSource, CultureInfo.InvariantCulture)
                                          : String.Empty,
                                Dimensions = dimensions != DBNull.Value
                                          ? Convert.ToString(dimensions, CultureInfo.InvariantCulture)
                                          : String.Empty,
                                Material = material != DBNull.Value
                                          ? Convert.ToString(material, CultureInfo.InvariantCulture)
                                          : String.Empty,
                                ColorTemperature = colorTemperature != DBNull.Value
                                          ? Convert.ToString(colorTemperature, CultureInfo.InvariantCulture)
                                          : String.Empty,
                                Wattage = wattage != DBNull.Value
                                          ? Convert.ToString(wattage, CultureInfo.InvariantCulture)
                                          : String.Empty,
                                Mounting = mounting != DBNull.Value
                                          ? Convert.ToString(mounting, CultureInfo.InvariantCulture)
                                          : String.Empty,

                            };
                        }
                    }
                }
            }

            return product;
        }

        /// <summary>
        /// Get Product Category
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Category GetCategory(IDataReader reader)
        {
            Category category = null;
            var catId = reader[StoredProcedures.GetProduct.ColumnNames.CategoryId];
            var catDisplayName = reader[StoredProcedures.GetProduct.ColumnNames.CatDisplayName];
            var catDisplayImage = reader[StoredProcedures.GetProduct.ColumnNames.CatDisplayImage];
            var catName = reader[StoredProcedures.GetProduct.ColumnNames.CatName];
            var catParentId = reader[StoredProcedures.GetProduct.ColumnNames.CatParentId];
            var catMain = reader[StoredProcedures.GetProduct.ColumnNames.CatMain];

            category = new Category()
            {
                Id = Convert.ToInt32(catId),
                DisplayName = catDisplayName != DBNull.Value
                                          ? Convert.ToString(catDisplayName, CultureInfo.InvariantCulture)
                                          : String.Empty,
                DisplayImage = catDisplayImage != DBNull.Value
                                           ? Convert.ToString(catDisplayImage, CultureInfo.InvariantCulture)
                                           : String.Empty,
                Name = catName != DBNull.Value
                                           ? Convert.ToString(catName, CultureInfo.InvariantCulture)
                                           : String.Empty,
                ParentCategoryId = catParentId != DBNull.Value
                                           ? Convert.ToInt32(catParentId, CultureInfo.InvariantCulture)
                                           : 0,
                Main = catMain != DBNull.Value
                                          ? Convert.ToBoolean(catMain, CultureInfo.InvariantCulture)
                                          : false,
            };

            return category;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static List<ProductImage> GetProductImages(string images)
        {
            List<ProductImage> productImages = null;

            string[] imgs = images.Split(',');
            if (imgs != null && imgs.Length > 0)
            {
                productImages = new List<ProductImage>();
                foreach (string img in imgs)
                {
                    productImages.Add(new ProductImage() { Image = img });
                }
            }

            return productImages;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public static List<ProductImage> GetProductImages(int productId)
        {
            List<ProductImage> productImages = null;

            using (var dbCommand = dbManager.GetStoredProcCommand(StoredProcedures.GetProductImages.SpName))
            {

                dbManager.AddInParameter(dbCommand, StoredProcedures.GetProductImages.Params.ProductId, DbType.Int32, productId);


                using (IDataReader reader = dbManager.ExecuteReaderWithRetry(dbCommand))
                {
                    if (reader != null)
                    {
                        productImages = new List<ProductImage>();
                        while (reader.Read())
                        {
                            var id = reader[StoredProcedures.GetProductImages.ColumnNames.Id];
                            var prodId = reader[StoredProcedures.GetProductImages.ColumnNames.ProductId];
                            var image = reader[StoredProcedures.GetProductImages.ColumnNames.Image];

                            productImages.Add(new ProductImage()
                            {

                                Id = id != DBNull.Value
                                          ? Convert.ToInt32(id, CultureInfo.InvariantCulture)
                                          : 0,
                                ProductId = prodId != DBNull.Value
                                          ? Convert.ToInt32(prodId, CultureInfo.InvariantCulture)
                                          : 0,
                                Image = image != DBNull.Value
                                          ? Convert.ToString(image, CultureInfo.InvariantCulture)
                                          : String.Empty,

                            });
                        }
                    }
                }
            }

            return productImages;
        }

        /// <summary>
        /// Get products by category id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static ICollection<Product> GetProductsByCategory(int categoryId)
        {
            ICollection<Product> products = null;

            using (var dbCommand = dbManager.GetStoredProcCommand(StoredProcedures.GetProducts.SpNameProductsByCategory))
            {

                dbManager.AddInParameter(dbCommand, StoredProcedures.GetProducts.Params.CategoryId, DbType.Int32, categoryId);


                using (IDataReader reader = dbManager.ExecuteReaderWithRetry(dbCommand))
                {
                    if (reader != null)
                    {
                        products = GetProducts(reader);
                    }
                }
            }

            return products;
        }
        
        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static string AddEditProduct(Product product)
        {
            if (product == null)
                return null;

            object dbCount;

            var dt = new DataTable(StoredProcedures.AddProduct.DataTableName);
            dt.Columns.Add(StoredProcedures.AddProduct.DataTableColumns.Image, typeof(string));
            if (product.Images != null && product.Images.Count > 0)
            {
                foreach (ProductImage pImage in product.Images)
                {
                    var dr = dt.NewRow();
                    dr[StoredProcedures.AddProduct.DataTableColumns.Image] = pImage.Image;
                    dt.Rows.Add(dr);
                }
            }

            using (var dbCommand = dbManager.GetStoredProcCommand(StoredProcedures.AddProduct.SpName))
            {
                dbManager.AddInParameter(dbCommand, StoredProcedures.AddProduct.Params.Pid, DbType.Int32, product.Id);
                dbManager.AddInParameter(dbCommand, StoredProcedures.AddProduct.Params.Name, DbType.String, product.Name);
                dbManager.AddInParameter(dbCommand, StoredProcedures.AddProduct.Params.CategoryId, DbType.Int32, product.Category.Id);
                dbManager.AddInParameter(dbCommand, StoredProcedures.AddProduct.Params.Desc, DbType.String, product.Desc);
                dbManager.AddInParameter(dbCommand, StoredProcedures.AddProduct.Params.Code, DbType.String, product.Code);
                dbManager.AddInParameter(dbCommand, StoredProcedures.AddProduct.Params.Dimensions, DbType.String, product.Dimensions);
                dbManager.AddInParameter(dbCommand, StoredProcedures.AddProduct.Params.LightSource, DbType.String, product.LightSource);
                dbManager.AddInParameter(dbCommand, StoredProcedures.AddProduct.Params.Images, SqlDbType.Structured, dt);
                dbManager.AddInParameter(dbCommand, StoredProcedures.AddProduct.Params.Material, DbType.String, product.Material);
                dbManager.AddInParameter(dbCommand, StoredProcedures.AddProduct.Params.ColorTemperature, DbType.String, product.ColorTemperature);
                dbManager.AddInParameter(dbCommand, StoredProcedures.AddProduct.Params.Wattage, DbType.String, product.Wattage);
                dbManager.AddInParameter(dbCommand, StoredProcedures.AddProduct.Params.Mounting, DbType.String, product.Mounting);
                dbManager.AddOutParameter(dbCommand, StoredProcedures.AddProduct.Params.Id, DbType.Int32, Int32.MaxValue);


                dbManager.ExecuteNonQueryWithRetry(dbCommand);

                dbCount = dbManager.GetParameterValue(dbCommand, StoredProcedures.AddProduct.Params.Id);
            }

            return !DBNull.Value.Equals(dbCount) ? dbCount.ToString() : "Failed";
        }

    }
}
