// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryRepository.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the DeliveryRepository type.
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
    /// The delivery repository.
    /// </summary>
    public class DeliveryRepository : SqlServerRepositoryBase, IRepository<Delivery>
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
        public int Insert(Delivery item)
        {
            var sqlParameters = new DbParameter[2];
            sqlParameters[0] = new SqlParameter("@UserId", SqlDbType.Int) { Value = item.UserId };
            sqlParameters[1] = new SqlParameter("@DateTimeDelivery", SqlDbType.DateTime) { Value = item.DateTimeDelivery };

            var id = this.dalManager.InsertProcedureWithOutputInsertedId(new SqlCommand("CreateDelivery"), sqlParameters);

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
        public void InsertById(Delivery item)
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
        public void Update(Delivery item)
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
        /// The <see cref="T:Warehouse.Domain.Delivery" />.
        /// </returns>
        /// <exception cref="T:System.NotImplementedException">
        /// </exception>
        public Delivery SelectById(int id)
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
        public IEnumerable<Delivery> SelectAll()
        {
            var deliveries = new List<Delivery>();
            var command = new SqlCommand("GetAllDelivery");
            var dataTable = this.dalManager.SelectAllProcedure(command, new SqlDataAdapter(command));

            if (dataTable.Rows.Count > 0)
            {
                deliveries.AddRange(
                    from DataRow dataRow in dataTable.Rows
                    select new Delivery
                               {
                                   DeliveryId = int.Parse(dataRow["DeliveryId"].ToString()),
                                   UserId = int.Parse(dataRow["UserId"].ToString()),
                                   DateTimeDelivery = DateTime.Parse(dataRow["DateTimeDelivery"].ToString())
                               });
            }
            else
            {
                return null;
            }

            return deliveries;
        }
    }
}