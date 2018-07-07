// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoodsClassRepository.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   The goods class repository.
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
    /// The goods class repository.
    /// </summary>
    public class GoodsClassRepository : SqlServerRepositoryBase, IRepository<GoodsClass>
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
        public int Insert(GoodsClass item)
        {
            var sqlParameters = new SqlParameter("@Title", SqlDbType.VarChar) { Value = item.Title };
            var id = this.dalManager.InsertProcedureWithOutputInsertedId(new SqlCommand("CreateGoodsClass"), sqlParameters);

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
        public void InsertById(GoodsClass item)
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
        public void Update(GoodsClass item)
        {
            var sqlParameters = new DbParameter[2];
            sqlParameters[0] = new SqlParameter("@GoodsClassId", SqlDbType.Int) { Value = item.GoodsClassId };
            sqlParameters[1] = new SqlParameter("@Title", SqlDbType.VarChar) { Value = item.Title };

            this.dalManager.UpdateProcedure(new SqlCommand("UpdateGoodsClass"), sqlParameters);
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
        /// The <see cref="T:Warehouse.Domain.GoodsClass" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public GoodsClass SelectById(int id)
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
        public IEnumerable<GoodsClass> SelectAll()
        {
            var classes = new List<GoodsClass>();
            var command = new SqlCommand("GetAllGoodsClass");
            var dataTable = this.dalManager.SelectAllProcedure(command, new SqlDataAdapter(command));

            if (dataTable.Rows.Count > 0)
            {
                classes.AddRange(
                    from DataRow dataRow in dataTable.Rows
                    select new GoodsClass
                               {
                                   GoodsClassId = int.Parse(dataRow["GoodsClassId"].ToString()),
                                   Title = dataRow["Title"].ToString()
                               });
            }
            else
            {
                return null;
            }

            return classes;
        }
    }
}