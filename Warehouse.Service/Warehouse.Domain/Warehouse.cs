// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Warehouse.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the Warehouse type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.Domain
{
    /// <summary>
    /// The warehouse.
    /// </summary>
    public class Warehouse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Warehouse"/> class.
        /// </summary>
        public Warehouse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Warehouse"/> class.
        /// </summary>
        /// <param name="warehouseId">
        /// The warehouse id.
        /// </param>
        /// <param name="goodsOfDeliveryId">
        /// The goods of delivery id.
        /// </param>
        /// <param name="unitPriceOfGoods">
        /// The unit price of goods.
        /// </param>
        /// <param name="stateId">
        /// The state id.
        /// </param>
        public Warehouse(int warehouseId, int goodsOfDeliveryId, decimal unitPriceOfGoods, int stateId)
        {
            this.WarehouseId = warehouseId;
            this.GoodsOfDeliveryId = goodsOfDeliveryId;
            this.UnitPriceOfGoods = unitPriceOfGoods;
            this.StateId = stateId;
        }

        /// <summary>
        /// Gets or sets the warehouse id.
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the goods of delivery id.
        /// </summary>
        public int GoodsOfDeliveryId { get; set; }

        /// <summary>
        /// Gets or sets the unit price of goods.
        /// </summary>
        public decimal UnitPriceOfGoods { get; set; }

        /// <summary>
        /// Gets or sets the state id.
        /// </summary>
        public int StateId { get; set; }
    }
}