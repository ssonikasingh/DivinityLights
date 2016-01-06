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
                            var catId = reader[StoredProcedures.GetProduct.ColumnNames.CategoryId];
                            var name = reader[StoredProcedures.GetProduct.ColumnNames.Name];
                            var code = reader[StoredProcedures.GetProduct.ColumnNames.Code];
                            var desc = reader[StoredProcedures.GetProduct.ColumnNames.Desc];
                            var image = reader[StoredProcedures.GetProduct.ColumnNames.Image];
                            var lightSource = reader[StoredProcedures.GetProduct.ColumnNames.LightSource];
                            var dimensions = reader[StoredProcedures.GetProduct.ColumnNames.Dimensions];

                            product = new Product
                            {

                                Id = id != DBNull.Value
                                          ? Convert.ToInt32(id, CultureInfo.InvariantCulture)
                                          : 0,
                                CategoryId = catId != DBNull.Value
                                          ? Convert.ToInt32(catId, CultureInfo.InvariantCulture)
                                          : 0,
                                Name = name != DBNull.Value
                                          ? Convert.ToString(name, CultureInfo.InvariantCulture)
                                          : String.Empty,
                                Code = code != DBNull.Value
                                          ? Convert.ToString(code, CultureInfo.InvariantCulture)
                                          : string.Empty,
                                Image = image != DBNull.Value
                                          ? Convert.ToString(image, CultureInfo.InvariantCulture)
                                          : String.Empty,
                                Desc = desc != DBNull.Value
                                           ? Convert.ToString(desc, CultureInfo.InvariantCulture)
                                           : String.Empty,
                                LightSource = lightSource != DBNull.Value
                                          ? Convert.ToString(lightSource, CultureInfo.InvariantCulture)
                                          : String.Empty,
                                Dimensions = dimensions != DBNull.Value
                                          ? Convert.ToString(dimensions, CultureInfo.InvariantCulture)
                                          : String.Empty,

                            };
                        }
                    }
                }
            }

            return product;
        }

        /// <summary>
        /// Get products by category id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static ICollection<Product> GetProductsByCategory(int categoryId)
        {
            ICollection<Product> products = null;

            using (var dbCommand = dbManager.GetStoredProcCommand(StoredProcedures.GetProducts.SpName))
            {

                dbManager.AddInParameter(dbCommand, StoredProcedures.GetProducts.Params.CategoryId, DbType.Int32, categoryId);


                using (IDataReader reader = dbManager.ExecuteReaderWithRetry(dbCommand))
                {
                    if (reader != null)
                    {
                        products = new Collection<Product>();
                        while (reader.Read())
                        {
                            var id = reader[StoredProcedures.GetProducts.ColumnNames.Id];
                            var catId = reader[StoredProcedures.GetProducts.ColumnNames.CategoryId];
                            var name = reader[StoredProcedures.GetProducts.ColumnNames.Name];
                            var code = reader[StoredProcedures.GetProducts.ColumnNames.Code];
                            var desc = reader[StoredProcedures.GetProducts.ColumnNames.Desc];
                            var image = reader[StoredProcedures.GetProducts.ColumnNames.Image];
                            var lightSource = reader[StoredProcedures.GetProducts.ColumnNames.LightSource];

                            products.Add(new Product()
                              {

                                  Id = id != DBNull.Value
                                            ? Convert.ToInt32(id, CultureInfo.InvariantCulture)
                                            : 0,
                                  CategoryId = catId != DBNull.Value
                                            ? Convert.ToInt32(catId, CultureInfo.InvariantCulture)
                                            : 0,
                                  Name = name != DBNull.Value
                                            ? Convert.ToString(name, CultureInfo.InvariantCulture)
                                            : String.Empty,
                                  Code = code != DBNull.Value
                                            ? Convert.ToString(code, CultureInfo.InvariantCulture)
                                            : string.Empty,
                                  Image = image != DBNull.Value
                                            ? Convert.ToString(image, CultureInfo.InvariantCulture)
                                            : String.Empty,
                                  Desc = desc != DBNull.Value
                                             ? Convert.ToString(desc, CultureInfo.InvariantCulture)
                                             : String.Empty,
                                  LightSource = lightSource != DBNull.Value
                                            ? Convert.ToString(lightSource, CultureInfo.InvariantCulture)
                                            : String.Empty,

                              });
                        }
                    }
                }
            }

            return products;
        }

    }
}
