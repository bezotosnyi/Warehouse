// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoodsOfDeliveryRepository.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the GoodsOfDeliveryRepository type.
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
    /// The goods of delivery repository.
    /// </summary>
    public class GoodsOfDeliveryRepository : SqlServerRepositoryBase, IRepository<GoodsOfDelivery>
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
        public int Insert(GoodsOfDelivery item)
        {
            var sqlParameters = new DbParameter[3];
            sqlParameters[0] = new SqlParameter("@DeliveryId", SqlDbType.Int) { Value = item.DeliveryId };
            sqlParameters[1] = new SqlParameter("@GoodsIdy", SqlDbType.Int) { Value = item.GoodsId };
            sqlParameters[2] = new SqlParameter("@Amount", SqlDbType.Int) { Value = item.Amount };

            var id = this.dalManager.InsertProcedureWithOutputInsertedId(new SqlCommand("CreateGoodsOfDelivery"), sqlParameters);

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
        public void InsertById(GoodsOfDelivery item)
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
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public void Update(GoodsOfDelivery item)
        {
            throw new System.NotImplementedException();
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
        /// The <see cref="T:Warehouse.Domain.GoodsOfDelivery" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public GoodsOfDelivery SelectById(int id)
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
        public IEnumerable<GoodsOfDelivery> SelectAll()
        {
            var goodsOfDeliveries = new List<GoodsOfDelivery>();
            var command = new SqlCommand("GetAllGoodsOfDelivery");
            var dataTable = this.dalManager.SelectAllProcedure(command, new SqlDataAdapter(command));

            if (dataTable.Rows.Count > 0)
            {
                goodsOfDeliveries.AddRange(
                    from DataRow dataRow in dataTable.Rows
                    select new GoodsOfDelivery
                    {
                        GoodsOfDeliveryId = int.Parse(dataRow["GoodsOfDeliveryId"].ToString()),
                        DeliveryId = int.Parse(dataRow["DeliveryId"].ToString()),
                        GoodsId = int.Parse(dataRow["GoodsId"].ToString()),
                        Amount = int.Parse(dataRow["Amount"].ToString())
                    });
            }
            else
            {
                return null;
            }

            return goodsOfDeliveries;
        }
    }
}