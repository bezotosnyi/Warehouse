// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProviderRepository.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the ProviderRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.DAL.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;

    using Warehouse.DAL.Contract;
    using Warehouse.Domain;

    /// <inheritdoc />
    /// <summary>
    /// The provider repository.
    /// </summary>
    public class ProviderRepository : SqlServerRepositoryBase, IRepository<Provider>
    {
        /// <inheritdoc />
        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Int32" />.
        /// </returns>
        public int Insert(Provider item)
        {
            var sqlParameters = new DbParameter[3];
            sqlParameters[0] = new SqlParameter("@Name", SqlDbType.VarChar) { Value = item.Name };
            sqlParameters[1] = new SqlParameter("@Address", SqlDbType.VarChar) { Value = item.Address };
            sqlParameters[2] = new SqlParameter("@Phone", SqlDbType.VarChar) { Value = item.Phone };

            var id = this.dalManager.InsertProcedureWithOutputInsertedId(new SqlCommand("CreateProvider"), sqlParameters);

            return id;
        }

        /// <inheritdoc />
        /// <summary>
        /// The insert by id.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public void InsertById(Provider item)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void Update(Provider item)
        {
            var sqlParameters = new DbParameter[4];
            sqlParameters[0] = new SqlParameter("@ProviderId", SqlDbType.VarChar) { Value = item.ProviderId };
            sqlParameters[1] = new SqlParameter("@Name", SqlDbType.VarChar) { Value = item.Name };
            sqlParameters[2] = new SqlParameter("@Address", SqlDbType.VarChar) { Value = item.Address };
            sqlParameters[3] = new SqlParameter("@Phone", SqlDbType.VarChar) { Value = item.Phone };
            this.dalManager.UpdateProcedure(new SqlCommand("UpdateProvider"), sqlParameters);
        }

        /// <inheritdoc />
        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The select by id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="T:Warehouse.Domain.Provider" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public Provider SelectById(int id)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        /// <summary>
        /// The select all.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.IEnumerable`1" />.
        /// </returns>
        public IEnumerable<Provider> SelectAll()
        {
            var providers = new List<Provider>();
            var command = new SqlCommand("GetAllProvider");
            var dataTable = this.dalManager.SelectAllProcedure(command, new SqlDataAdapter(command));

            if (dataTable.Rows.Count > 0)
            {
                providers.AddRange(
                    from DataRow dataRow in dataTable.Rows
                    select new Provider
                               {
                                   ProviderId = int.Parse(dataRow["ProviderId"].ToString()),
                                   Name = dataRow["Name"].ToString(),
                                   Address = dataRow["Address"].ToString(),
                                   Phone = dataRow["Phone"].ToString()
                               });
            }
            else
            {
                return null;
            }

            return providers;
        }
    }
}