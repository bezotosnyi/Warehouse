// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoodsDto.cs" company="DNU">
//   DNU
// </copyright>
// <summary>
//   Defines the GoodsDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Warehouse.DTO
{
    /// <summary>
    /// The goods dto.
    /// </summary>
    [System.Serializable]
    public class GoodsDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoodsDto"/> class.
        /// </summary>
        public GoodsDto()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoodsDto"/> class.
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
        /// The goods category.
        /// </param>
        /// <param name="goodsClass">
        /// The goods class.
        /// </param>
        /// <param name="price">
        /// The price.
        /// </param>
        public GoodsDto(
            int goodsId,
            string title,
            ProviderDto provider,
            GoodsCategoryDto goodsCategory,
            GoodsClassDto goodsClass,
            decimal price)
        {
            this.GoodsId = goodsId;
            this.Title = title;
            this.Provider = provider;
            this.GoodsCategory = goodsCategory;
            this.GoodsClass = goodsClass;
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
        public decimal Price { get; set; }
    }
}