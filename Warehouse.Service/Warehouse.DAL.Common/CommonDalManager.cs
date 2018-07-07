// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DalManager.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the DalManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.DAL.Common
{
    using System;
    using System.Data;
    using System.Data.Common;

    /// <summary>
    /// The dal manager.
    /// </summary>
    public class CommonDalManager
    {
        /// <summary>
        /// The db connection.
        /// </summary>
        private readonly DbConnection dbConnection;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommonDalManager"/> class.
        /// </summary>
        /// <param name="dbConnection">
        /// The db connection.
        /// </param>
        public CommonDalManager(DbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="CommonDalManager"/> class. 
        /// </summary>
        ~CommonDalManager()
        {
            this.CloseConnection();
        }

        /// <summary>
        /// The insert procedure.
        /// </summary>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        /// <param name="dbParametrs">
        /// The db parametrs.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Null dbParametrs
        /// </exception>
        /// <exception cref="Exception">
        /// Error - Connection.InsertProcedure
        /// </exception>
        public virtual void InsertProcedure(DbCommand dbCommand, params DbParameter[] dbParametrs)
        {
            if (dbParametrs.Length == 0) throw new ArgumentNullException();

            using (var sqlCommand = dbCommand)
            {
                try
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(dbParametrs);
                    sqlCommand.Connection = this.OpenConnection();
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception(
                        "Error - Connection.InsertProcedure : " + exception.StackTrace);
                }
                finally
                {
                    this.CloseConnection();
                }
            }
        }

        /// <summary>
        /// The insert procedure with output inserted id.
        /// </summary>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        /// <param name="dbParametrs">
        /// The db parametrs.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Null dbParametrs
        /// </exception>
        /// <exception cref="Exception">
        /// Error - Connection.InsertProcedureWithOutputInsertedId
        /// </exception>
        public virtual int InsertProcedureWithOutputInsertedId(DbCommand dbCommand, params DbParameter[] dbParametrs)
        {
            int id;
            if (dbParametrs.Length == 0) throw new ArgumentNullException();

            using (var sqlCommand = dbCommand)
            {
                try
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(dbParametrs);
                    sqlCommand.Connection = this.OpenConnection();
                    id = (int)sqlCommand.ExecuteScalar();
                }
                catch (Exception exception)
                {
                    throw new Exception(
                        "Error - Connection.InsertProcedureWithOutputInsertedId : " + exception.StackTrace);
                }
                finally
                {
                    this.CloseConnection();
                }
            }

            return id;
        }

        /// <summary>
        /// The update procedure.
        /// </summary>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        /// <param name="dbParametrs">
        /// The db parametrs.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Null dbParametrs
        /// </exception>
        /// <exception cref="Exception">
        /// Error - Connection.UpdateProcedur
        /// </exception>
        public virtual void UpdateProcedure(DbCommand dbCommand, params DbParameter[] dbParametrs)
        {
            if (dbParametrs.Length == 0) throw new ArgumentNullException();

            using (var cmd = dbCommand)
            {
                try
                {
                    cmd.Connection = this.OpenConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(dbParametrs);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    throw new Exception("Error - Connection.UpdateProcedure : " + exception);
                }
                finally
                {
                    this.CloseConnection();
                }
            }
        }

        /// <summary>
        /// The delete procedure.
        /// </summary>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        /// <param name="dbParametrs">
        /// The db parametrs.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Null dbParametrs
        /// </exception>
        /// <exception cref="Exception">
        /// Error - Connection.DeleteProcedure
        /// </exception>
        public virtual void DeleteProcedure(DbCommand dbCommand, params DbParameter[] dbParametrs)
        {
            if (dbParametrs.Length == 0) throw new ArgumentNullException();

            using (var sqlCommand = dbCommand)
            {
                try
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(dbParametrs);
                    sqlCommand.Connection = this.OpenConnection();
                    var rowAffected = sqlCommand.ExecuteNonQuery();
                    if (rowAffected == 0)
                    {
                        throw new Exception("Not has been deleted Item from DB");
                    }
                }
                catch (Exception exception)
                {
                    throw new Exception(
                        "Error - Connection.DeleteProcedure : " + exception.StackTrace);
                }
                finally
                {
                    this.CloseConnection();
                }
            }
        }

        /// <summary>
        /// The select procedure.
        /// </summary>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        /// <param name="dbDataAdapter">
        /// The db data adapter.
        /// </param>
        /// <param name="dbParametrs">
        /// The db parametrs.
        /// </param>
        /// <returns>
        /// The <see cref="DataTable"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Null dbParametrs
        /// </exception>
        /// <exception cref="Exception">
        /// Error - Connection.SelectProcedure
        /// </exception>
        public virtual DataTable SelectProcedure(DbCommand dbCommand, DbDataAdapter dbDataAdapter, params DbParameter[] dbParametrs)
        {
            if (dbParametrs.Length == 0) throw new ArgumentNullException();

            using (var sqlCommand = dbCommand)
            {
                DataTable dataTable;
                var dataSet = new DataSet();
                try
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(dbParametrs);
                    sqlCommand.Connection = this.OpenConnection();
                    var dataAdapter = dbDataAdapter;
                    dataAdapter.Fill(dataSet);
                    dataTable = dataSet.Tables[0];
                }
                catch (Exception exception)
                {
                    throw new Exception(
                        "Error - Connection.SelectProcedure : " + exception.StackTrace);
                }
                finally
                {
                    this.CloseConnection();
                }

                return dataTable;
            }
        }

        /// <summary>
        /// The select all procedure.
        /// </summary>
        /// <param name="dbCommand">
        /// The db command.
        /// </param>
        /// <param name="dbDataAdapter">
        /// The db data adapter.
        /// </param>
        /// <returns>
        /// The <see cref="DataTable"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Error - Connection.SelectAllProcedure
        /// </exception>
        public virtual DataTable SelectAllProcedure(DbCommand dbCommand, DbDataAdapter dbDataAdapter)
        {
            using (var sqlCommand = dbCommand)
            {
                DataTable dataTable;
                var dataSet = new DataSet();
                try
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = this.OpenConnection();
                    var dataAdapter = dbDataAdapter;
                    dataAdapter.Fill(dataSet);
                    dataTable = dataSet.Tables[0];
                }
                catch (Exception exception)
                {
                    throw new Exception(
                        "Error - Connection.SelectAllProcedure : " + exception);
                }
                finally
                {
                    this.CloseConnection();
                }

                return dataTable;
            }
        }

        /// <summary>
        /// The open connection.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Data.Common.DbConnection" />.
        /// </returns>
        private DbConnection OpenConnection()
        {
            if (this.dbConnection.State == ConnectionState.Closed || this.dbConnection.State == ConnectionState.Broken)
            {
                this.dbConnection.Open();
            }

            return this.dbConnection;
        }

        /// <summary>
        /// The close connetcion.
        /// </summary>
        private void CloseConnection()
        {
            if (this.dbConnection.State == ConnectionState.Open || this.dbConnection.State == ConnectionState.Broken)
                this.dbConnection.Close();
        }
    }
}