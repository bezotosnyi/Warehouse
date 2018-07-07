// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoodsCategoryRepository.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the GoodsCategoryRepository type.
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
    /// The goods category repository.
    /// </summary>
    public class GoodsCategoryRepository : SqlServerRepositoryBase, IRepository<GoodsCategory>
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
        public int Insert(GoodsCategory item)
        {
            var sqlParameters = new SqlParameter("@Title", SqlDbType.VarChar) { Value = item.Title };
            var id = this.dalManager.InsertProcedureWithOutputInsertedId(new SqlCommand("CreateGoodsCategory"), sqlParameters);

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
        public void InsertById(GoodsCategory item)
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
        public void Update(GoodsCategory item)
        {
            var sqlParameters = new DbParameter[2];
            sqlParameters[0] = new SqlParameter("@GoodsCategoryId", SqlDbType.Int) { Value = item.GoodsCategoryId };
            sqlParameters[1] = new SqlParameter("@Title", SqlDbType.VarChar) { Value = item.Title };

            this.dalManager.UpdateProcedure(new SqlCommand("UpdateGoodsCategory"), sqlParameters);

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
        /// The <see cref="T:Warehouse.Domain.GoodsCategory" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public GoodsCategory SelectById(int id)
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
        public IEnumerable<GoodsCategory> SelectAll()
        {
            var categories = new List<GoodsCategory>();
            var command = new SqlCommand("GetAllGoodsCategory");
            var dataTable = this.dalManager.SelectAllProcedure(command, new SqlDataAdapter(command));

            if (dataTable.Rows.Count > 0)
            {
                categories.AddRange(
                    from DataRow dataRow in dataTable.Rows
                    select new GoodsCategory
                               {
                                   GoodsCategoryId = int.Parse(dataRow["GoodsCategoryId"].ToString()),
                                   Title = dataRow["Title"].ToString()
                               });
            }
            else
            {
                return null;
            }

            return categories;
        }
    }
}