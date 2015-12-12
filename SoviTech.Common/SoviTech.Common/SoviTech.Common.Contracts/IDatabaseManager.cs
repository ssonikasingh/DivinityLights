
using System.Data;
using System.Data.Common;
namespace SoviTech.Common.Contracts
{
    public interface IDatabaseManager
    {
        #region "Database"

        /// <summary>
        /// Initialize database
        /// </summary>
        /// <param name="dbKey"></param>
        /// <param name="commandTimeout"></param>
        void InitializeDatabase(string dbKey, int commandTimeout);

        /// <summary>
        /// <para>Creates a <see cref="DbCommand"/> for a stored procedure.</para>
        /// </summary>
        /// <param name="spName"><para>The name of the stored procedure.</para></param>
        /// <returns><para>The <see cref="DbCommand"/> for the stored procedure.</para></returns>   
        DbCommand GetStoredProcCommand(string spName);

        /// <summary>
        /// Adds a new In <see cref="DbParameter"/> object to the given <paramref name="command"/>.
        /// </summary>
        /// <param name="command">The commmand to add the parameter.</param>
        /// <param name="name"><para>The name of the parameter.</para></param>
        /// <param name="dbType"><para>One of the <see cref="DbType"/> values.</para></param>                
        /// <param name="value"><para>The value of the parameter.</para></param>    
        void AddInParameter(DbCommand command,
                                   string name,
                                   DbType dbType,
                                   object value);


        /// Adds a new In <see cref="DbParameter"/> object to the given <paramref name="command"/>.
        /// </summary>
        /// <param name="command">The commmand to add the parameter.</param>
        /// <param name="name"><para>The name of the parameter.</para></param>
        /// <param name="dbType"><para>One of the <see cref="SqlDbType"/> values.</para></param>                
        /// <param name="value"><para>The value of the parameter.</para></param>    
    
        void AddInParameter(DbCommand command,
            string name,
            SqlDbType dbType,
            object value);

        /// <summary>
        /// Adds a new Out <see cref="DbParameter"/> object to the given <paramref name="command"/>.
        /// </summary>
        /// <param name="command">The command to add the out parameter.</param>
        /// <param name="name"><para>The name of the parameter.</para></param>
        /// <param name="dbType"><para>One of the <see cref="DbType"/> values.</para></param>        
        /// <param name="size"><para>The maximum size of the data within the column.</para></param>        
        void AddOutParameter(DbCommand command,
                                    string name,
                                    DbType dbType,
                                    int size);

        
        
        /// <summary>
        /// Gets a parameter value.
        /// </summary>
        /// <param name="command">The command that contains the parameter.</param>
        /// <param name="name">The name of the parameter.</param>
        /// <returns>The value of the parameter.</returns>
        object GetParameterValue(DbCommand command,
                                                string name);
        
        #endregion "Database"

        #region "Query Execution"

        /// <summary>
        /// Execute Non Query With Retry
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        int ExecuteNonQueryWithRetry(DbCommand command);


        /// <summary>
        /// Execute Reader With Retry
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        IDataReader ExecuteReaderWithRetry(DbCommand command);

        #endregion "Query Execution"
    }
}
