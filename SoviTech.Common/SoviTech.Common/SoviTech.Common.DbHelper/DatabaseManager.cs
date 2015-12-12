using SoviTech.Common.Contracts;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;

using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SoviTech.Common.DatabaseHelper
{
    public class DatabaseManager : IDatabaseManager
    {

        static DatabaseManager()
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory());
            RetryPolicyFactory.CreateDefault();
        }

        #region Fields

        /// <summary>
        /// Command timeout for authdb
        /// </summary>
        private int _commandTimeout;

        /// <summary>
        /// Ent Lib Database 
        /// </summary>
        private Database _db; //= DatabaseFactory.CreateDatabase(Constants.ConfigKeys.AuthDBKey);

        //private DbTransaction transaction;
        //private IDbConnection DbConn;

        #endregion Fields

        #region "Public Methods"

        #region "Database"
        /// <summary>
        /// Initialize database
        /// </summary>
        /// <param name="dbKey"></param>
        /// <param name="commandTimeout"></param>
        public void InitializeDatabase(string dbKey, int commandTimeout)
        {
            _commandTimeout = commandTimeout;

            _db = DatabaseFactory.CreateDatabase(dbKey);
        }

        /// <summary>
        /// <para>Creates a <see cref="DbCommand"/> for a stored procedure.</para>
        /// </summary>
        /// <param name="spName"><para>The name of the stored procedure.</para></param>
        /// <returns><para>The <see cref="DbCommand"/> for the stored procedure.</para></returns>   
        public DbCommand GetStoredProcCommand(string spName)
        {
            return _db.GetStoredProcCommand(spName);
        }

        /// <summary>
        /// Adds a new In <see cref="DbParameter"/> object to the given <paramref name="command"/>.
        /// </summary>
        /// <param name="command">The commmand to add the parameter.</param>
        /// <param name="name"><para>The name of the parameter.</para></param>
        /// <param name="dbType"><para>One of the <see cref="DbType"/> values.</para></param>                
        /// <param name="value"><para>The value of the parameter.</para></param>    
        public void AddInParameter(DbCommand command,
                                   string name,
                                   DbType dbType,
                                   object value)
        {
            _db.AddInParameter(command, name, dbType, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="name"></param>
        /// <param name="dbType"></param>
        /// <param name="value"></param>
        public void AddInParameter(DbCommand command,
                                   string name,
                                   SqlDbType dbType,
                                   object value)
        {
            ((SqlDatabase)_db).AddInParameter(command, name, dbType, value);
        }

        /// <summary>
        /// Adds a new Out <see cref="DbParameter"/> object to the given <paramref name="command"/>.
        /// </summary>
        /// <param name="command">The command to add the out parameter.</param>
        /// <param name="name"><para>The name of the parameter.</para></param>
        /// <param name="dbType"><para>One of the <see cref="DbType"/> values.</para></param>        
        /// <param name="size"><para>The maximum size of the data within the column.</para></param>        
        public void AddOutParameter(DbCommand command,
                                    string name,
                                    DbType dbType,
                                    int size)
        {
            _db.AddOutParameter(command, name, dbType, size);
        }


      
        #endregion "Database"

        #region "Query Execution"

        /// <summary>
        /// Execute Non Query With Retry
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public int ExecuteNonQueryWithRetry(DbCommand command)
        {
            ValidateCommand(command);
            command.CommandTimeout = _commandTimeout;
            DbConnection conn = _db.CreateConnection();
            ValidateConnection(conn);
            command.Connection = conn;
            return ((SqlCommand)command).ExecuteNonQueryWithRetry();
        }

        /// <summary>
        /// Execute Reader With Retry
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public IDataReader ExecuteReaderWithRetry(DbCommand command)
        {
            ValidateCommand(command);
            command.CommandTimeout = _commandTimeout;
            DbConnection conn = _db.CreateConnection();
            using (DatabaseConnectionWrapper wrapper = new DatabaseConnectionWrapper(conn))
            {
                ValidateConnection(conn);
                command.Connection = conn;
                var reader = ((SqlCommand)command).ExecuteReaderWithRetry();
                return new RefCountingDataReader(wrapper, reader);
            }
        }

        /// <summary>
        /// Gets a parameter value.
        /// </summary>
        /// <param name="command">The command that contains the parameter.</param>
        /// <param name="name">The name of the parameter.</param>
        /// <returns>The value of the parameter.</returns>
        public object GetParameterValue(DbCommand command,
                                                string name)
        {
            return _db.GetParameterValue(command, name);
        }

        #endregion "Query Execution"

        #endregion

        #region "Private Methods"


        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        private void ValidateCommand(DbCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            if (command.GetType() != typeof(SqlCommand))
            {
                throw new ArgumentException("Invalid command object.A valid SQL command object is required.", "command");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        private static void ValidateConnection(DbConnection conn)
        {
            if (conn == null)
            {
                throw new ArgumentNullException("conn");
            }

            if (conn.GetType() != typeof(SqlConnection))
            {
                throw new ArgumentException("Invalid connecting object.A valid SQL connection object is required.", "conn");
            }
        }
        #endregion
    }
}
