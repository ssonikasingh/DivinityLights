using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivinityLights.DAL
{
    /// <summary>
    /// Contains all databases
    /// </summary>
    internal struct Databases
    {
        /// <summary>
        /// PMS Test Database
        /// </summary>
        internal const string DivnityLights = "DivinityLights";
    }
     /// <summary>
    /// Contains all stored procedures
    /// </summary>
    internal struct StoredProcedures
    {
        /// <summary>
        /// struct for usp_GetCategories StoredProcedure
        /// </summary>
        internal struct GetCategories
        {
            /// <summary>
            /// Stored Procedure name.
            /// </summary>
            internal const string SpName = "usp_GetCategories";


            /// <summary>
            /// Reperesents column names in the resultset.
            /// </summary>
            internal struct ColumnNames
            {
                internal const string Id = "Id";
                internal const string Name = "Name";
                internal const string DisplayName = "DisplayName";
                internal const string DisplayImage = "DisplayImage";
                internal const string ParentId = "ParentId";
                internal const string Main = "Main";
            }
        }

        /// <summary>
        /// struct for usp_GetCategory StoredProcedure
        /// </summary>
        internal struct GetCategory
        {
            /// <summary>
            /// Stored Procedure name.
            /// </summary>
            internal const string SpName = "usp_GetCategory";

            /// <summary>
            /// Input parameters
            /// </summary>
            internal struct Params
            {
                internal const string Id = "@id";
            }

            /// <summary>
            /// Reperesents column names in the resultset.
            /// </summary>
            internal struct ColumnNames
            {
                internal const string Id = "Id";
                internal const string Name = "Name";
                internal const string DisplayName = "DisplayName";
                internal const string DisplayImage = "DisplayImage";
                internal const string ParentId = "ParentId";
                internal const string Main = "Main";

            }
        }

        /// <summary>
        /// struct for usp_GetProducts StoredProcedure
        /// </summary>
        internal struct GetProducts
        {
            /// <summary>
            /// Stored Procedure name for get the products for category.
            /// </summary>
            internal const string SpNameProductsByCategory = "usp_GetProductsByCategory";

            /// <summary>
            /// Stored Procedure name for get the products
            /// </summary>
            internal const string SpNameProducts = "usp_GetProducts";

            /// <summary>
            /// Reperesents parameters
            /// </summary>
            internal struct Params
            {
                internal const string CategoryId = "@catId";
            }

            /// <summary>
            /// Reperesents column names in the resultset.
            /// </summary>
            internal struct ColumnNames
            {
                internal const string Id = "Id";
                internal const string CategoryId = "CategoryId";
                internal const string Name = "Name";
                internal const string Code = "Code";
                internal const string Desc = "Desc";
                internal const string Image = "Image";
                internal const string Dimensions = "Dimensions";
                internal const string LightSource = "LightSource";
                internal const string Material = "Material";
                internal const string ColorTemperature = "ColorTemperature";
                internal const string Wattage = "Wattage";
                internal const string Mounting = "Mounting";
            }

        }

         /// <summary>
        /// struct for usp_GetProductImages StoredProcedure
        /// </summary>
        internal struct GetProductImages
        {
            /// <summary>
            /// Stored Procedure name.
            /// </summary>
            internal const string SpName = "usp_GetProductImages";

            /// <summary>
            /// Reperesents parameters
            /// </summary>
            internal struct Params
            {
                internal const string ProductId = "@productId";
            }

            /// <summary>
            /// Reperesents column names in the resultset.
            /// </summary>
            internal struct ColumnNames
            {
                internal const string Id = "Id";
                internal const string ProductId = "ProductId";
                internal const string Image = "Image";
            }

        }        

        /// <summary>
        /// struct for usp_GetProduct StoredProcedure
        /// </summary>
        internal struct GetProduct
        {
            /// <summary>
            /// Stored Procedure name.
            /// </summary>
            internal const string SpName = "usp_GetProduct";

            /// <summary>
            /// Reperesents parameters
            /// </summary>
            internal struct Params
            {
                internal const string Id = "@id";

            }

            /// <summary>
            /// Reperesents column names in the resultset.
            /// </summary>
            internal struct ColumnNames
            {
                internal const string Id = "Id";
                internal const string CategoryId = "CategoryId";
                internal const string Name = "Name";
                internal const string Code = "Code";
                internal const string Desc = "Desc";
                internal const string Images = "Images";
                internal const string Dimensions = "Dimensions";
                internal const string LightSource = "LightSource";
                internal const string Material = "Material";
                internal const string ColorTemperature = "ColorTemperature";
                internal const string Wattage = "Wattage";
                internal const string Mounting = "Mounting";
                internal const string CatDisplayName = "catDisplayName";
                internal const string CatDisplayImage = "catDisplayImage";
                internal const string CatName = "catName";
                internal const string CatParentId = "catParentId";
                internal const string CatMain = "catMain";
            }

        }

        /// <summary>
        /// struct for usp_AddProduct StoredProcedure
        /// </summary>
        internal struct AddProduct
        {
            /// <summary>
            /// Stored Procedure name.
            /// </summary>
            internal const string SpName = "usp_AddProduct";

            /// <summary>
            /// 
            /// </summary>
            internal const string DataTableName = "Images";

            /// <summary>
            /// Reperesents parameters
            /// </summary>
            internal struct DataTableColumns
            {
                public const string Image = "image";

            }

            /// <summary>
            /// Reperesents parameters
            /// </summary>
            internal struct Params
            {
                internal const string Pid = "@pId";
                internal const string Id = "@id";
                internal const string CategoryId = "@categoryId";
                internal const string Name = "@name";
                internal const string Code = "@code";
                internal const string Desc = "@desc";
                internal const string Dimensions = "@dimensions";
                internal const string LightSource = "@lightSource";
                internal const string Images = "@images";
                internal const string Material = "@material";
                internal const string ColorTemperature = "@colorTemperature";
                internal const string Wattage = "@wattage";
                internal const string Mounting = "@mounting";
            }

        }

    }
}
