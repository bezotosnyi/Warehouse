// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaleRepository.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the SaleRepository type.
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
    /// The sale repository.
    /// </summary>
    public class SaleRepository : SqlServerRepositoryBase, IRepository<Sale>
    {
        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int Insert(Sale item)
        {
            var sqlParameters = new DbParameter[4];
            sqlParameters[0] = new SqlParameter("@WarehouseId", SqlDbType.Int) { Value = item.WarehouseId };
            sqlParameters[1] = new SqlParameter("@Amount", SqlDbType.Int) { Value = item.Amount };
            sqlParameters[2] = new SqlParameter("@UserId", SqlDbType.Int) { Value = item.UserId };
            sqlParameters[3] = new SqlParameter("@DateTimeSale", SqlDbType.DateTime) { Value = item.DateTimeSale };

            var id = this.dalManager.InsertProcedureWithOutputInsertedId(new SqlCommand("CreateSale"), sqlParameters);

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
        public void InsertById(Sale item)
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
        public void Update(Sale item)
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
        /// The <see cref="T:Warehouse.Domain.Sale" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public Sale SelectById(int id)
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
        public IEnumerable<Sale> SelectAll()
        {
            var sales = new List<Sale>();
            var command = new SqlCommand("GetAllSales");
            var dataTable = this.dalManager.SelectAllProcedure(command, new SqlDataAdapter(command));

            if (dataTable.Rows.Count > 0)
            {
                sales.AddRange(
                    from DataRow dataRow in dataTable.Rows
                    select new Sale
                              {
                                   SaleId = int.Parse(dataRow["SaleId"].ToString()),
                                   UserId = int.Parse(dataRow["UserId"].ToString()),
                                   WarehouseId = int.Parse(dataRow["WarehouseId"].ToString()),
                                   Amount = int.Parse(dataRow["Amount"].ToString()),
                                   DateTimeSale = DateTime.Parse(dataRow["DateTimeSale"].ToString())
                    });
            }
            else
            {
                return null;
            }

            return sales;
        }
    }
}