// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoodsRepository.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the GoodsRepository type.
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
    /// The goods repository.
    /// </summary>
    public class GoodsRepository : SqlServerRepositoryBase, IRepository<Goods>
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
        public int Insert(Goods item)
        {
            var sqlParameters = new DbParameter[5];
            sqlParameters[0] = new SqlParameter("@Title", SqlDbType.VarChar) { Value = item.Title };
            sqlParameters[1] = new SqlParameter("@ProviderId", SqlDbType.Int) { Value = item.ProviderId };
            sqlParameters[2] = new SqlParameter("@GoodsCategoryId", SqlDbType.Int) { Value = item.GoodsCategoryId };
            sqlParameters[3] = new SqlParameter("@GoodsClassId", SqlDbType.Int) { Value = item.GoodsClassId };
            sqlParameters[4] = new SqlParameter("@Price", SqlDbType.Money) { Value = item.Price };

            var id = this.dalManager.InsertProcedureWithOutputInsertedId(new SqlCommand("CreateGoods"), sqlParameters);

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
        public void InsertById(Goods item)
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
        public void Update(Goods item)
        {
            var sqlParameters = new DbParameter[6];
            sqlParameters[0] = new SqlParameter("@GoodsId", SqlDbType.Int) { Value = item.GoodsId };
            sqlParameters[1] = new SqlParameter("@Title", SqlDbType.VarChar) { Value = item.Title };
            sqlParameters[2] = new SqlParameter("@ProviderId", SqlDbType.Int) { Value = item.ProviderId };
            sqlParameters[3] = new SqlParameter("@GoodsCategoryId", SqlDbType.Int) { Value = item.GoodsCategoryId };
            sqlParameters[4] = new SqlParameter("@GoodsClassId", SqlDbType.Int) { Value = item.GoodsClassId };
            sqlParameters[4] = new SqlParameter("@Price", SqlDbType.Money) { Value = item.Price };

            this.dalManager.UpdateProcedure(new SqlCommand("UpdateGoods"), sqlParameters);
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
        /// The <see cref="T:Warehouse.Domain.Goods" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public Goods SelectById(int id)
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
        public IEnumerable<Goods> SelectAll()
        {
            var userList = new List<Goods>();
            var command = new SqlCommand("GetAllGoods");
            var dataTable = this.dalManager.SelectAllProcedure(command, new SqlDataAdapter(command));

            if (dataTable.Rows.Count > 0)
            {
                userList.AddRange(
                    from DataRow dataRow in dataTable.Rows
                    select new Goods
                               {
                                   GoodsId = int.Parse(dataRow["GoodsId"].ToString()),
                                   Title = dataRow["Title"].ToString(),
                                   ProviderId = int.Parse(dataRow["ProviderId"].ToString()),
                                   GoodsCategoryId = int.Parse(dataRow["GoodsCategoryId"].ToString()),
                                   GoodsClassId = int.Parse(dataRow["GoodsClassId"].ToString()),
                                   Price = decimal.Parse(dataRow["Price"].ToString())
                               });
            }
            else
            {
                return null;
            }

            return userList;
        }
    }
}