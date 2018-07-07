// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Goods.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the Goods type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.Domain
{
    /// <summary>
    /// The goods.
    /// </summary>
    public class Goods
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Goods"/> class.
        /// </summary>
        public Goods()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Goods"/> class.
        /// </summary>
        /// <param name="goodsId">
        /// The goods id.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="providerId">
        /// The provider id.
        /// </param>
        /// <param name="goodsCategoryId">
        /// The goods category id.
        /// </param>
        /// <param name="goodsClassId">
        /// The goods class id.
        /// </param>
        /// <param name="price">
        /// The price.
        /// </param>
        public Goods(int goodsId, string title, int providerId, int goodsCategoryId, int goodsClassId, decimal price)
        {
            this.GoodsId = goodsId;
            this.Title = title;
            this.ProviderId = providerId;
            this.GoodsCategoryId = goodsCategoryId;
            this.GoodsClassId = goodsClassId;
            this.Price = price;
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
        /// Gets or sets the provider id.
        /// </summary>
        public int ProviderId { get; set; }

        /// <summary>
        /// Gets or sets the goods category id.
        /// </summary>
        public int GoodsCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the goods class id.
        /// </summary>
        public int GoodsClassId { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price { get; set; }
    }
}