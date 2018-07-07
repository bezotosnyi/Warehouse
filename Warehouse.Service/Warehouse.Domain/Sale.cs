// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sale.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the Sale type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.Domain
{
    using System;

    /// <summary>
    /// The sale.
    /// </summary>
    public class Sale
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sale"/> class.
        /// </summary>
        public Sale()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sale"/> class.
        /// </summary>
        /// <param name="saleId">
        /// The sale id.
        /// </param>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="warehouseId">
        /// The warehouse id.
        /// </param>
        /// <param name="amount">
        /// The amount.
        /// </param>
        /// <param name="dateTimeSale">
        /// The date time sale.
        /// </param>
        public Sale(int saleId, int userId, int warehouseId, int amount, DateTime dateTimeSale)
        {
            this.SaleId = saleId;
            this.UserId = userId;
            this.WarehouseId = warehouseId;
            this.Amount = amount;
            this.DateTimeSale = dateTimeSale;
        }

        /// <summary>
        /// Gets or sets the sale id.
        /// </summary>
        public int SaleId { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the warehouse id.
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the date time sale.
        /// </summary>
        public System.DateTime DateTimeSale { get; set; }
    }
}