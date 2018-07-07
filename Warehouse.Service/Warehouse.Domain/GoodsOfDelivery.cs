// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoodsOfDelivery.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the GoodsOfDelivery type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.Domain
{
    /// <summary>
    /// The goods of delivery.
    /// </summary>
    public class GoodsOfDelivery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoodsOfDelivery"/> class.
        /// </summary>
        public GoodsOfDelivery()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoodsOfDelivery"/> class.
        /// </summary>
        /// <param name="goodsOfDeliveryId">
        /// The goods of delivery id.
        /// </param>
        /// <param name="deliveryId">
        /// The delivery id.
        /// </param>
        /// <param name="goodsId">
        /// The goods id.
        /// </param>
        /// <param name="amount">
        /// The amount.
        /// </param>
        public GoodsOfDelivery(int goodsOfDeliveryId, int deliveryId, int goodsId, int amount)
        {
            this.GoodsOfDeliveryId = goodsOfDeliveryId;
            this.DeliveryId = deliveryId;
            this.GoodsId = goodsId;
            this.Amount = amount;
        }

        /// <summary>
        /// Gets or sets the goods of delivery id.
        /// </summary>
        public int GoodsOfDeliveryId { get; set; }

        /// <summary>
        /// Gets or sets the delivery id.
        /// </summary>
        public int DeliveryId { get; set; }

        /// <summary>
        /// Gets or sets the goods id.
        /// </summary>
        public int GoodsId { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public int Amount { get; set; }
    }
}