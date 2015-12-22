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
    }
}
