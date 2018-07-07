// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WarehouseGoods.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the WarehouseGoods type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.DTO
{
    using System;

    /// <summary>
    /// The warehouse goods.
    /// </summary>
    [System.Serializable]
    public class WarehouseGoods
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WarehouseGoods"/> class.
        /// </summary>
        public WarehouseGoods()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WarehouseGoods"/> class.
        /// </summary>
        /// <param name="goodsId">
        /// The goods id.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <param name="goodsCategory">
        /// The goods Category.
        /// </param>
        /// <param name="goodsClass">
        /// The goods Class.
        /// </param>
        /// <param name="amount">
        /// The amount.
        /// </param>
        /// <param name="unitPrice">
        /// The unit price.
        /// </param>
        /// <param name="dateTimeDelivery">
        /// The date Time Delivery.
        /// </param>
        /// <param name="state">
        /// The state.
        /// </param>
        public WarehouseGoods(
            int goodsId,
            string title,
            ProviderDto provider,
            GoodsCategoryDto goodsCategory,
            GoodsClassDto goodsClass,
            int amount,
            decimal unitPrice,
            DateTime dateTimeDelivery,
            string state)
        {
            this.GoodsId = goodsId;
            this.Title = title;
            this.Provider = provider;
            this.GoodsCategory = goodsCategory;
            this.GoodsClass = goodsClass;
            this.Amount = amount;
            this.UnitPrice = unitPrice;
            this.DateTimeDelivery = dateTimeDelivery;
            this.State = state;
        }

        /// <summary>
        /// Gets or sets the goods id.
        /// </summary>
        public int GoodsId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the provider.
        /// </summary>
        public ProviderDto Provider { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public GoodsCategoryDto GoodsCategory { get; set; }

        /// <summary>
        /// Gets or sets the class.
        /// </summary>
        public GoodsClassDto GoodsClass { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the date time delivery.
        /// </summary>
        public DateTime DateTimeDelivery { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public string State { get; set; }
    }
}