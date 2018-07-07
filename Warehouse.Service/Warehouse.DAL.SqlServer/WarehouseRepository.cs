// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WarehouseRepository.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the WarehouseRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.DAL.SqlServer
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;

    using Warehouse.DAL.Contract;
    using Warehouse.Domain;

    /// <inheritdoc />
    /// <summary>
    /// The warehouse repository.
    /// </summary>
    public class WarehouseRepository : SqlServerRepositoryBase, IRepository<Warehouse>
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
        public int Insert(Warehouse item)
        {
            var sqlParameters = new DbParameter[3];
            sqlParameters[0] = new SqlParameter("@GoodsOfDeliveryId", SqlDbType.Int) { Value = item.GoodsOfDeliveryId };
            sqlParameters[1] = new SqlParameter("@UnitPriceOfGoods", SqlDbType.Money) { Value = item.UnitPriceOfGoods };
            sqlParameters[2] = new SqlParameter("@StateId", SqlDbType.Int) { Value = item.StateId };

            var id = this.dalManager.InsertProcedureWithOutputInsertedId(new SqlCommand("CreateWarehouse"), sqlParameters);
 
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
        public void InsertById(Warehouse item)
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
        public void Update(Warehouse item)
        {
            var sqlParameters = new DbParameter[3];
            sqlParameters[0] = new SqlParameter("@WarehouseId", SqlDbType.Int) { Value = item.WarehouseId };
            sqlParameters[1] = new SqlParameter("@GoodsOfDeliveryId", SqlDbType.Int) { Value = item.GoodsOfDeliveryId };
            sqlParameters[2] = new SqlParameter("@UnitPriceOfGoods", SqlDbType.Money) { Value = item.UnitPriceOfGoods };
            sqlParameters[3] = new SqlParameter("@StateId", SqlDbType.Int) { Value = item.StateId };
            this.dalManager.UpdateProcedure(new SqlCommand("UpdateWarehouse"), sqlParameters);
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
        /// The <see cref="T:Warehouse.Domain.Warehouse" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public Warehouse SelectById(int id)
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
        public IEnumerable<Warehouse> SelectAll()
        {
            var warehouses = new List<Warehouse>();
            var command = new SqlCommand("GetAllWarehouse");
            var dataTable = this.dalManager.SelectAllProcedure(command, new SqlDataAdapter(command));

            if (dataTable.Rows.Count > 0)
            {
                warehouses.AddRange(
                    from DataRow dataRow in dataTable.Rows
                    select new Warehouse
                               {
                                   WarehouseId = int.Parse(dataRow["WarehouseId"].ToString()),
                                   GoodsOfDeliveryId = int.Parse(dataRow["GoodsOfDeliveryId"].ToString()),
                                   UnitPriceOfGoods = decimal.Parse(dataRow["UnitPriceOfGoods"].ToString()),
                                   StateId = int.Parse(dataRow["StateId"].ToString())
                               });
            }
            else
            {
                return null;
            }

            return warehouses;
        }
    }
}