// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Delivery.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the Delivery type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.Domain
{
    using System;

    /// <summary>
    /// The delivery.
    /// </summary>
    public class Delivery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Delivery"/> class.
        /// </summary>
        public Delivery()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Delivery"/> class.
        /// </summary>
        /// <param name="deliveryId">
        /// The delivery id.
        /// </param>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="dateTimeDelivery">
        /// The date time delivery.
        /// </param>
        public Delivery(int deliveryId, int userId, DateTime dateTimeDelivery)
        {
            this.DeliveryId = deliveryId;
            this.UserId = userId;
            this.DateTimeDelivery = dateTimeDelivery;
        }

        /// <summary>
        /// Gets or sets the delivery id.
        /// </summary>
        public int DeliveryId { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the date time delivery.
        /// </summary>
        public DateTime DateTimeDelivery { get; set; }
    }
}