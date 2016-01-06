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
    public static class CategoryDbManager
    {
        private static readonly IDatabaseManager dbManager;

        static CategoryDbManager()
        {
            dbManager = new DatabaseManager();
            dbManager.InitializeDatabase(Databases.DivnityLights, 5000);
        }

        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns></returns>
        public static ICollection<Category> GetCategories()
        {
            ICollection<Category> categories = null;

            using (var dbCommand = dbManager.GetStoredProcCommand(StoredProcedures.GetCategories.SpName))
            {
                using (IDataReader reader = dbManager.ExecuteReaderWithRetry(dbCommand))
                {
                    if (reader != null)
                    {
                        categories = new Collection<Category>();
                        while (reader.Read())
                        {
                            var id = reader[StoredProcedures.GetCategories.ColumnNames.Id];
                            var name = reader[StoredProcedures.GetCategories.ColumnNames.Name];
                            var displayName = reader[StoredProcedures.GetCategories.ColumnNames.DisplayName];
                            var displayImage = reader[StoredProcedures.GetCategories.ColumnNames.DisplayImage];
                            var parentId = reader[StoredProcedures.GetCategories.ColumnNames.ParentId];
                            var main = reader[StoredProcedures.GetCategories.ColumnNames.Main];

                            categories.Add(new Category
                            {

                                Id = id != DBNull.Value
                                          ? Convert.ToInt32(id, CultureInfo.InvariantCulture)
                                          : 0,
                                Name = name != DBNull.Value
                                          ? Convert.ToString(name, CultureInfo.InvariantCulture)
                                          : String.Empty,
                                DisplayName = displayName != DBNull.Value
                                            ? Convert.ToString(displayName, CultureInfo.InvariantCulture)
                                            : String.Empty,
                                DisplayImage = displayImage != DBNull.Value
                                          ? Convert.ToString(displayImage, CultureInfo.InvariantCulture)
                                          : String.Empty,
                                ParentCategoryId = parentId != DBNull.Value
                                          ? Convert.ToInt32(parentId, CultureInfo.InvariantCulture)
                                          : 0,
                                Main = main != DBNull.Value && Convert.ToBoolean(main, CultureInfo.InvariantCulture),

                            });
                        }
                    }
                }
            }

            return categories;
        }


        /// <summary>
        /// Get Category By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Category GetCategory(int categoryId)
        {
            Category category = null;

            using (var dbCommand = dbManager.GetStoredProcCommand(StoredProcedures.GetCategory.SpName))
            {
                dbManager.AddInParameter(dbCommand, StoredProcedures.GetCategory.Params.Id, DbType.Int32, categoryId);

                using (IDataReader reader = dbManager.ExecuteReaderWithRetry(dbCommand))
                {
                    if (reader != null)
                    {
                        category = new Category();
                        while (reader.Read())
                        {
                            var id = reader[StoredProcedures.GetCategory.ColumnNames.Id];
                            var name = reader[StoredProcedures.GetCategory.ColumnNames.Name];
                            var displayName = reader[StoredProcedures.GetCategory.ColumnNames.DisplayName];
                            var displayImage = reader[StoredProcedures.GetCategory.ColumnNames.DisplayImage];
                            var parentId = reader[StoredProcedures.GetCategory.ColumnNames.ParentId];
                            var main = reader[StoredProcedures.GetCategory.ColumnNames.Main];

                            category = new Category
                            {

                                Id = id != DBNull.Value
                                          ? Convert.ToInt32(id, CultureInfo.InvariantCulture)
                                          : 0,
                                Name = name != DBNull.Value
                                          ? Convert.ToString(name, CultureInfo.InvariantCulture)
                                          : String.Empty,
                                DisplayName = displayName != DBNull.Value
                                          ? Convert.ToString(displayName, CultureInfo.InvariantCulture)
                                          : String.Empty,
                                DisplayImage = displayImage != DBNull.Value
                                          ? Convert.ToString(displayImage, CultureInfo.InvariantCulture)
                                          : String.Empty,
                                ParentCategoryId = parentId != DBNull.Value
                                          ? Convert.ToInt32(parentId, CultureInfo.InvariantCulture)
                                          : 0,
                                Main = main != DBNull.Value && Convert.ToBoolean(main, CultureInfo.InvariantCulture),

                            };
                        }
                    }
                }
            }

            return category;
        }
    }
}
